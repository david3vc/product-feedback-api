using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Core.Security.Services.Abstractions;
using Domain;
using Infraestructure.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper, IUserRepository userRepository, ISecurityService securityService, IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _securityService = securityService;
            _configuration = configuration;
        }

        public async Task<UserDto> Create(UserFormDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            var response = await _userRepository.Create(entity);

            return _mapper.Map<UserDto>(response);
        }

        public Task<UserDto?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> Find(int id)
        {
            var response = await _userRepository.Find(id);

            return _mapper.Map<UserDto>(response);
        }

        public async Task<IList<UserDto>> FindAll()
        {
            var response = await _userRepository.FindAll();

            return _mapper.Map<IList<UserDto>>(response);
        }

        public async Task<UserTokenDto?> LoginAsync(UserLoginDto dto)
        {
            var response = await _userRepository.LoginAsync(dto.Username, dto.Password);
            var usuario = _mapper.Map<UserTokenDto>(response);

            var jwtSecrectKey = _configuration.GetSection("Security:JwtSecrectKey").Get<string>();
            usuario.Security = _securityService.JwtSecurity(jwtSecrectKey);

            return usuario;
        }

        public async Task<UserDto?> Update(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            var response = await _userRepository.Update(entity);

            return _mapper.Map<UserDto>(response);
        }
    }
}
