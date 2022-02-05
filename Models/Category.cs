using System;
using System.Collections.Generic;

namespace HotelManagementWebAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            RoomNo = new HashSet<RoomNo>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string RatingType { get; set; }
        public int? MiscId { get; set; }

        public virtual Miscellaneous Misc { get; set; }
        public virtual ICollection<RoomNo> RoomNo { get; set; }
    }
}
