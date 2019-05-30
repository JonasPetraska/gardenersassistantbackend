using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }

        public virtual List<Permission> Permissions { get; set; }

        public UserTypeEnum UserType { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string SecurityStamp { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
