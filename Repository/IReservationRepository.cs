using HotelManagementWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Repository
{
    public interface IReservationRepository
    {
        Task<List<ReservationViewModel>> GetReservationDetails();
    }
}
