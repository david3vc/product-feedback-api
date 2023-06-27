using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Implementations
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> Create(Feedback entity)
        {
            _context.Feedbacks.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Feedback?> Delete(int id)
        {
            var model = await _context.Feedbacks.FindAsync(id);

            if (model != null)
            {
                model.Status = 0;

                _context.Feedbacks.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Feedback?> Find(int id)
            => await _context.Feedbacks.Include(f => f.Category)
                                       .Include(f => f.FeedbackStatus)
                                       .Where(f => f.Id == id).FirstOrDefaultAsync();

        public async Task<IList<Feedback>> FindAll()
            => await _context.Feedbacks.Where(f => f.Status == 1).ToListAsync();

        public async Task<Feedback?> Update(Feedback entity)
        {
            var model = await _context.Feedbacks.FindAsync(entity.Id);

            if (model != null)
            {
                model.Title = entity.Title;
                model.Detail = entity.Detail;
                model.CountVotes = entity.CountVotes;
                model.IdFeedbackStatus = entity.IdFeedbackStatus;
                model.IdCategory = entity.IdCategory;

                _context.Feedbacks.Update(model);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
