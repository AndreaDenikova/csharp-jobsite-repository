namespace MyJobSite.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class JobPostingInputModel
    {
        [Required]
        [MinLength(3)]
        public string JobTitle { get; set; }

        [Required]
        [MinLength(3)]
        public string Location { get; set; }

        [Required]
        [MinLength(20)]
        public string Requirements { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        [MinLength(20)]
        public string Benefits { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string JobPostingCategoryId { get; set; }

        [Required]
        public string CompanyInfoId { get; set; }

        [Required]
        public string VacancyType { get; set; }

        public string Instructions { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }
    }
}
