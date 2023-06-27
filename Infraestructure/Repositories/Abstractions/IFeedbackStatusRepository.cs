using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Abstractions
{
    public interface IFeedbackStatusRepository
    {
        Task<IList<FeedbackStatus>> FindAll();
    }
}
