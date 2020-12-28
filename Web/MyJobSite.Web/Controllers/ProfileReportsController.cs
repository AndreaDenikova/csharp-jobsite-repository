using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyJobSite.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJobSite.Web.Controllers
{
    public class ProfileReportsController : BaseController
    {
        private readonly IAccountTypeService accountTypeService;
        private readonly IReportsCompanyProfileService reportsCompanyProfileService;
        private readonly IReportsCandidateProfileService reportsCandidateProfileService;
        private readonly ICompanyInfoService companyInfoService;

        public ProfileReportsController(IAccountTypeService accountTypeService, IReportsCompanyProfileService reportsCompanyProfileService, IReportsCandidateProfileService reportsCandidateProfileService, ICompanyInfoService companyInfoService)
        {
            this.accountTypeService = accountTypeService;
            this.reportsCompanyProfileService = reportsCompanyProfileService;
            this.reportsCandidateProfileService = reportsCandidateProfileService;
            this.companyInfoService = companyInfoService;
        }

        [Authorize]
        public async Task<IActionResult> AddNewCompanyProfileReport(string id) //// id == userId
        {
            var checkIfAlreadyReported = this.reportsCompanyProfileService.CheckIfProfileAlreadyReported(id);

            var companyInfoId = this.companyInfoService.GetCompanyInfoId(id);

            if (checkIfAlreadyReported == true)
            {

                await this.reportsCompanyProfileService.IncreaseCount(id);

                return this.RedirectToAction("CompanyProfile", "CompanyProfile", new { id = companyInfoId });
            }

            await this.reportsCompanyProfileService.AddNewReportedProfile(id);
            return this.RedirectToAction("CompanyProfile", "CompanyProfile", new { id = companyInfoId });
        }

        [Authorize]
        public async Task<IActionResult> AddNewCandidateProfileReport(string id) //// id == userId
        {
            var checkIfAlreadyReported = this.reportsCandidateProfileService.CheckIfProfileAlreadyReported(id);

            if (checkIfAlreadyReported == true)
            {
                await this.reportsCandidateProfileService.IncreaseCount(id);

                return this.RedirectToAction("CandidateProfile", "CandidateProfile", new { id });
            }

            await this.reportsCandidateProfileService.AddNewReportedProfile(id);
            return this.RedirectToAction("CandidateProfile", "CandidateProfile", new { id });
        }
    }
}
