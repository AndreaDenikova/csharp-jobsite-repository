namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Web.ViewModels.InputModels;

    public class JobPostingsService : IJobPostingsService
    {
        private readonly IDeletableEntityRepository<JobPosting> jobRepository;

        public JobPostingsService(IDeletableEntityRepository<JobPosting> jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public async Task PostCompanyInfoAsync(JobPostingInputModel input)
        {
            var jobPosting = new JobPosting
            {
                Title = input.JobTitle,
                Address = input.Location,
                Requirements = input.Requirements,
                Type = input.VacancyType,
                JobPostingCategoryId = input.Category,
                Instructions = input.Instructions,
                CompanyInfoId = input.CompanyInfoId,
            };

            //// TODO: Insert Logo in JobPosting

            await this.jobRepository.AddAsync(jobPosting);
            await this.jobRepository.SaveChangesAsync();
        }
    }
}
