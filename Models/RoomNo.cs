using System;
using System.Collections.Generic;

namespace HotelManagementWebAPI.Models
{
    public partial class RoomNo
    {
        public RoomNo()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int RoomNoId { get; set; }
        public int Rate { get; set; }
        public int? CategoryId { get; set; }
        public int? RoomStatusId { get; set; }

        public virtual Category Category { get; set; }
        public virtual RoomStatus RoomStatus { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
