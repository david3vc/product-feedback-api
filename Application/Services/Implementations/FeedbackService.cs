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
    public class FeedbackService : IFeedbackService
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(
                                IMapper mapper,
                                IFeedbackRepository feedbackRepository
                              ) 
        {
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
        }

        public async Task<FeedbackDto> Create(FeedbackFormDto dto)
        {
            var entity = new Feedback();

            entity.Title = dto.Title;
            entity.Detail = dto.Detail;
            entity.CountVotes = dto.CountVotes;
            entity.IdCategory = dto.Category != null ? dto.Category.Id : null;
            //entity.IdFeedbackStatus = dto.FeedbackStatus != null ? dto.FeedbackStatus.Id : null;

            var response = await _feedbackRepository.Create( entity );

            return _mapper.Map<FeedbackDto>( response );
        }

        public async Task<FeedbackDto?> Delete(int id)
        {
            var response = await _feedbackRepository.Delete(id);

            return _mapper.Map<FeedbackDto>(response);
        }

        public async Task<FeedbackDto?> Find(int id)
        {
            var response = await _feedbackRepository.Find(id);

            return _mapper.Map<FeedbackDto>(response);
        }

        public async Task<IList<FeedbackDto>> FindAll()
        {
            var response = await _feedbackRepository.FindAll();

            return _mapper.Map<IList<FeedbackDto>>(response);
        }

        public async Task<FeedbackDto?> Update(FeedbackDto dto)
        {
            var feedback = await _feedbackRepository.Find(dto.Id);

            if (feedback == null) throw new Exception("Feedback not found");

            feedback.Title = dto.Title;
            feedback.Detail = dto.Detail;
            feedback.CountVotes = dto.CountVotes;
            feedback.IdCategory = dto.Category != null ? dto.Category.Id : null;
            feedback.IdFeedbackStatus = dto.FeedbackStatus != null ? dto.FeedbackStatus.Id : null;

            var response = await _feedbackRepository.Update(feedback);

            return _mapper.Map<FeedbackDto>(response);
        }
    }
}
