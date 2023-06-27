using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;
using Infraestructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(
                                IMapper mapper,
                                ICommentRepository commentRepository
                              )
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> Create(CommentFormDto dto)
        {
            var entity = new Comment();

            entity.Detail = dto.Detail;
            entity.IdFeedback = dto.IdFeedback;
            entity.IdCommentParent = dto.CommentParent != null ? dto.CommentParent.Id : null;

            var response = await _commentRepository.Create(entity);

            return _mapper.Map<CommentDto>(response);
        }

        public async Task<CommentDto?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentDto?> Find(int id)
        {
            var response = await _commentRepository.Find(id);

            return _mapper.Map<CommentDto>(response);
        }

        public async Task<IList<CommentDto>> FindAll()
        {
            var response = await _commentRepository.FindAll();

            return _mapper.Map<IList<CommentDto>>(response);
        }

        public async Task<CommentDto?> Update(CommentDto dto)
        {
            var feedback = await _commentRepository.Find(dto.Id);

            if (feedback == null) throw new Exception("Feedback not found");

            feedback.Detail = dto.Detail;
            feedback.IdFeedback = dto.IdFeedback;
            feedback.IdCommentParent = dto.CommentParent != null ? dto.CommentParent.Id : null;

            var response = await _commentRepository.Update(feedback);

            return _mapper.Map<CommentDto>(response);
        }
    }
}
