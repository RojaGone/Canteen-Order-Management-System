using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class FeedbackMaster
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public string Feedback { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        public UserMaster User { get; set; }
    }
}
