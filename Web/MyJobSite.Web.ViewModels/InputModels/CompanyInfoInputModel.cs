namespace MyJobSite.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class CompanyInfoInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public IFormFile Logo { get; set; }

        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        [MinLength(5)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }
    }
}
