using MyJobSite.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyJobSite.Data.Models
{
    public class UserInfo : BaseDeletableModel<string>
    {
        public UserInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        [Required]
        public string CV { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
