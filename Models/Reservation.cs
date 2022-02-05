using System;
using System.Collections.Generic;

namespace HotelManagementWebAPI.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? CustId { get; set; }
        public int? RoomNoId { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime OccupancyDate { get; set; }
        public int? NoOfDays { get; set; }
        public int? Advance { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual RoomNo RoomNo { get; set; }
    }
}
