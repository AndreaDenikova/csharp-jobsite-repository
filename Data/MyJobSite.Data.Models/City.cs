namespace MyJobSite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyJobSite.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
    }
}
