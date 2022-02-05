using System;
using System.Collections.Generic;

namespace HotelManagementWebAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; }
        public int CustPh { get; set; }
        public string CustEmail { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
