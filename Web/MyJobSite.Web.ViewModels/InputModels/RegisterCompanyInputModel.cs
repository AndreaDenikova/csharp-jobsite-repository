using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobSite.Web.ViewModels.InputModels
{
    public class RegisterCompanyInputModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
