﻿namespace MyJobSite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using MyJobSite.Web.ViewModels.InputModels;

    public interface IUserInfoService
    {
        string UploadImageToCloudinary(Stream imageFileStream);

        Task PostUserInfoAsync(UserInfoInputModel input);
    }
}
