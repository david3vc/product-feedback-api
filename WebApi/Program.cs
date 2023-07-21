using Autofac.Extensions.DependencyInjection;
using Autofac;
using Infraestructure.Context;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Security.Services.Abstractions;
using Core.Security.Services.Implementations;
using Microsoft.OpenApi.Models;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// RouteOptions
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// PasswordHasherOptions
builder.Services.Configure<PasswordHasherOptions>(options =>
{
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

// JwtSecrectKey
var jwtSecrectKey = builder.Configuration.GetSection("Security:JwtSecrectKey").Get<string>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecrectKey)),
        ValidateLifetime = true,
        ValidIssuer = "",
        ValidAudience = "",
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true
    };
});

// Data base context
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<ISecurityService, SecurityService>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterAssemblyTypes(Assembly.Load("Infraestructure"))
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

        options.RegisterAssemblyTypes(Assembly.Load("Application"))
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    });

builder.Services.AddAutoMapper(Assembly.Load("Application"));

builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AuthorizeOperationFilter>();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Bearer",
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Specify the authorization token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
    });
});

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .Build();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
