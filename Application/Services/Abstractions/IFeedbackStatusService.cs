using Application.Dtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IFeedbackStatusService
    {
        Task<IList<FeedbackStatusDto>> FindAll();
    }
}
