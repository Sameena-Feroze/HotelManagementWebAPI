using System;
using System.Collections.Generic;

namespace HotelManagementWebAPI.Models
{
    public partial class Miscellaneous
    {
        public Miscellaneous()
        {
            Category = new HashSet<Category>();
        }

        public int MiscId { get; set; }
        public int? Servicetax { get; set; }
        public int? HomeService { get; set; }
        public int? Charity { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}
