using Application.Dtos;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackStatusController : ControllerBase
    {
        private readonly IFeedbackStatusService _feedbackStatusService;

        public FeedbackStatusController(IFeedbackStatusService feedbackStatusService)
        {
            _feedbackStatusService = feedbackStatusService;
        }

        [HttpGet]
        public async Task<IEnumerable<FeedbackStatusDto>> Get()
            => await _feedbackStatusService.FindAll();
    }
}
