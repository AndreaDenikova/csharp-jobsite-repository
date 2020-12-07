namespace MyJobSite.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class UserInfoInputModel
    {
        public string UserId { get; set; }

        public string Description { get; set; }

        [Required]
        public IFormFile ProfilePicture { get; set; }

        [Required]
        public IFormFile Cv { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
    }
}
