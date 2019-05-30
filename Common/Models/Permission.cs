using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Controller { get; set; }
        public string Actions { get; set; }

        public void SetActions(List<string> actions)
        {
            Actions = string.Join(";", actions);
        }
    }
}
