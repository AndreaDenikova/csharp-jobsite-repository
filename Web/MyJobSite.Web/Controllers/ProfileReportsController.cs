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
        private readonly IReportsProfileService reportsProfileService;
        private readonly IAccountTypeService accountTypeService;

        public ProfileReportsController(IReportsProfileService reportsProfileService, IAccountTypeService accountTypeService)
        {
            this.reportsProfileService = reportsProfileService;
            this.accountTypeService = accountTypeService;
        }

        [Authorize]
        public async Task<IActionResult> AddNewProfileReport(string id) //// id == userId
        {
            var checkIfAlreadyReported = this.reportsProfileService.CheckIfProfileAlreadyReported(id);
            var accounType = this.accountTypeService.GetAccountTypeController(id);

            if (checkIfAlreadyReported == true)
            {
                await this.reportsProfileService.IncreaseCount(id);

                if (accounType == "Candidate")
                {
                    return this.RedirectToAction("CandidateProfile", "CandidateProfile", new { id });
                }

                return this.RedirectToAction("CompanyProfile", "CompanyProfile", new { id });
            }

            await this.reportsProfileService.AddNewReportedProfile(id);
            if (accounType == "Candidate")
            {
                return this.RedirectToAction("CandidateProfile", "CandidateProfile", new { id });
            }

            return this.RedirectToAction("CompanyProfile", "CompanyProfile");
        }
    }
}
