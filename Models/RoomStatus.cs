using System;
using System.Collections.Generic;

namespace HotelManagementWebAPI.Models
{
    public partial class RoomStatus
    {
        public RoomStatus()
        {
            RoomNo = new HashSet<RoomNo>();
        }

        public int RoomStatusId { get; set; }
        public string OccupationStatus { get; set; }

        public virtual ICollection<RoomNo> RoomNo { get; set; }
    }
}
