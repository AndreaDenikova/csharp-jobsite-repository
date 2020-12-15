﻿namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Services.Mapping;
    using MyJobSite.Web.ViewModels.InputModels;

    public class JobPostingsService : IJobPostingsService
    {
        private readonly IDeletableEntityRepository<JobPosting> jobRepository;

        public JobPostingsService(IDeletableEntityRepository<JobPosting> jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public T GetJobPostingInformation<T>(string id)
        {
            var jobPosting = this.jobRepository.All().Where(j => j.Id == id).To<T>().FirstOrDefault();

            return jobPosting;
        }

        public string GetJobPostingId(string companyInfoId)
        {
            var jobPosting = this.jobRepository.All().Where(j => j.CompanyInfoId == companyInfoId).FirstOrDefault();
            var id = jobPosting.CompanyInfoId;

            return id;
        }

        public async Task PostJobPostingAsync(JobPostingInputModel input)
        {
            var jobPosting = new JobPosting
            {
                Title = input.JobTitle,
                Address = input.Location,
                Requirements = input.Requirements,
                Skills = input.Skills,
                Responsibilities = input.Responsibilities,
                Description = input.Description,
                Benefits = input.Benefits,
                Type = input.VacancyType,
                JobPostingCategoryId = input.JobPostingCategoryId,
                Instructions = input.Instructions,
                CompanyInfoId = input.CompanyInfoId,
                MinSalary = input.MinSalary,
                MaxSalary = input.MaxSalary,
                CityId = input.CityId,
            };

            //// TODO: Insert Logo in JobPosting

            await this.jobRepository.AddAsync(jobPosting);
            await this.jobRepository.SaveChangesAsync();
        }
    }
}
