﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FeedbackStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Feedback>? Feedbacks { get; set; }
    }
}
