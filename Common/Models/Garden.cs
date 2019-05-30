using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Garden
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public virtual Location Location { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
