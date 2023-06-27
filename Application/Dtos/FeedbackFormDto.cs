using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class FeedbackFormDto
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string CountVotes { get; set; }
        public int Status { get; set; }

        public CategoryDto? Category { get; set; }
        public FeedbackStatusDto? FeedbackStatus { get; set; }
    }
}
