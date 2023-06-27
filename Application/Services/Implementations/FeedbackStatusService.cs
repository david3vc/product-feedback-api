using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class FeedbackStatusService : IFeedbackStatusService
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackStatusRepository _feedbackStatusRepository;

        public FeedbackStatusService(IFeedbackStatusRepository feedbackStatusRepository, IMapper mapper)
        {
            _feedbackStatusRepository = feedbackStatusRepository;
            _mapper = mapper;
        }

        public async Task<IList<FeedbackStatusDto>> FindAll()
        {
            var response = await _feedbackStatusRepository.FindAll();

            return _mapper.Map<IList<FeedbackStatusDto>>(response);
        }
    }
}
