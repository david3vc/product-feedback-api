using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CommentFormDto
    {
        public string Detail { get; set; }
        public int? IdFeedback { get; set; }
        public CommentDto? CommentParent { get; set; }
    }
}
