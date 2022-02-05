using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.ViewModel
{
    public class ReservationViewModel
    {
        public string CustName { get; set; }
        public int? RoomNo { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime OccupancyDate { get; set; }
        public int? NoOfDays { get; set; }
        public int? Advance { get; set; }
       
    }
}
