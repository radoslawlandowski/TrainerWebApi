using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;


namespace TrainerWebApi.Models
{
    public class User : IdentityUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName cannot be empty")]
        [StringLength(20, ErrorMessage = "FirstName cannot exceed {0} characters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName cannot be empty")]
        [StringLength(50, ErrorMessage = "LastName cannot exceed {0} characters")]
        public string LastName { get; set; }

        public string About { get; set; }

        public User Trainer { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}