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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> Create(Comment entity)
        {
            _context.Comments.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Comment?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment?> Find(int id)
            => await _context.Comments.Include(f => f.Feedback)
                                      .Include(f => f.Replys)
                                      .Where(f => f.Id == id).FirstOrDefaultAsync();

        public async Task<IList<Comment>> FindAll()
            => await _context.Comments.ToListAsync();

        public async Task<Comment?> Update(Comment entity)
        {
            var model = await _context.Comments.FindAsync(entity.Id);

            if (model != null)
            {
                model.Detail = entity.Detail;
                model.IdFeedback = entity.IdFeedback;
                model.IdCommentParent = entity.IdCommentParent;

                _context.Comments.Update(model);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
