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
    public class FeedbackStatusRepository : IFeedbackStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<FeedbackStatus>> FindAll()
        => await _context.FeedbackStatuses.ToListAsync();
    }
}
