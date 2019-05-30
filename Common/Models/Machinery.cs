using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Machinery
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual Location Location { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
