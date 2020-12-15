using MyJobSite.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyJobSite.Data.Models
{
    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
    }
}
