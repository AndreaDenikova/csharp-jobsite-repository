namespace MyJobSite.Data.Models
{
    using System;

    using MyJobSite.Data.Common.Models;

    public class FavoriteJobPosting : BaseDeletableModel<string>
    {
        public FavoriteJobPosting()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public virtual JobPosting JobPosting { get; set; }

        public string JobPostingId { get; set; }
    }
}
