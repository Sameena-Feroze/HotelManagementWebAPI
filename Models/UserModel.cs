using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Models
{
    public class UserModel
    {

        //public string CustName { get; set; }
        //public int? RoomNo { get; set; }
        //public DateTime BookDate { get; set; }
        //public DateTime OccupancyDate { get; set; }
        //public int? NoOfDays { get; set; }
        //public int? Advance { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Role { get; set; }
    }
}
