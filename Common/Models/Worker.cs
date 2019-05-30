using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Worker
    {
        public Worker()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}
