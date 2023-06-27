using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Maps
{
    public class FeedbackFormProfile : Profile
    {
        public FeedbackFormProfile()
        {
            CreateMap<Feedback, FeedbackFormDto>().ReverseMap();
        }
    }
}
