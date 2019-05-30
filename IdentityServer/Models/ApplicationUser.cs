using Common.Enums;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "User type")]
        public UserTypeEnum UserType { get; set; }

        public virtual List<Permission> Permissions { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }

        [Display(Name = "Created on")]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Username")]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        [Required]
        [Display(Name = "Email address")]
        public override string Email { get => base.Email; set => base.Email = value; }

        [Display(Name = "Phone number")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        public static implicit operator ApplicationUser(Common.Models.ApplicationUser user)
        {
            return new ApplicationUser()
            {
                CreationDate = user.CreationDate,
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                PasswordHash = user.PasswordHash,
                Permissions = user.Permissions,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                SecurityStamp = user.SecurityStamp,
                UserType = user.UserType,
                UserName = user.UserName
            };
        }

        public static implicit operator Common.Models.ApplicationUser(ApplicationUser user)
        {
            return new Common.Models.ApplicationUser()
            {
                CreationDate = user.CreationDate,
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                PasswordHash = user.PasswordHash,
                Permissions = user.Permissions,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                SecurityStamp = user.SecurityStamp,
                UserType = user.UserType,
                UserName = user.UserName
            };

        }

    }
}
