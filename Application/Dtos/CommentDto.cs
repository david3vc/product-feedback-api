using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int? IdCommentParent { get; set; }
        public int? IdFeedback { get; set; }

        public FeedbackDto? Feedback { get; set; }
        public CommentDto? CommentParent { get; set; }
        public List<CommentDto>? Replys { get; set; }
    }
}
