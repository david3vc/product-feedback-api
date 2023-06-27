using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string CountVotes { get; set; }
        public int? IdCategory { get; set; }
        public int? IdFeedbackStatus { get; set; }
        public int Status { get; set; }

        public virtual FeedbackStatus? FeedbackStatus { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
