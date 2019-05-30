using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Change
    {
        public DateTime Date { get; set; }
        public string Field { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string EntityId { get; set; }
        public string EntityType { get; set; }
        public ApplicationUser User { get; set; }
    }
}
