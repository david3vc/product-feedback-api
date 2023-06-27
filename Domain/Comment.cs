using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int? IdCommentParent { get; set; }
        public int? IdFeedback { get; set; }

        public virtual Feedback? Feedback { get; set; }
        public virtual Comment? CommentParent { get; set; }
        public virtual ICollection<Comment>? Replys { get; set; }
    }
}
