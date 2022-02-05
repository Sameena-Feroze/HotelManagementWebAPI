using HotelManagementWebAPI.Models;
using HotelManagementWebAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Repository
{
    public class ReservationRepository:IReservationRepository
    {
        //data fields
        private readonly HotelManagementContext _context;

        //default constructor
        //constructor based dependency injection
        public ReservationRepository(HotelManagementContext context)
        {
            _context = context;
        }



        public async Task<List<ReservationViewModel>> GetReservationDetails()
        {
            if (_context != null)
            //linq
            {    
                return await (from res in _context.Reservation
                              from c in _context.Customer
                              from r in _context.RoomNo
                              where r.RoomNoId==res.RoomNoId
                              where c.CustId == res.CustId
                              select new ReservationViewModel
                              {
                                  RoomNo = r.RoomNoId,
                                  CustName = c.CustName,
                                  BookDate=res.BookDate,
                                  OccupancyDate=res.OccupancyDate,
                                  NoOfDays=res.NoOfDays,
                                  Advance=res.Advance

                              }
                             ).ToListAsync();
            }
            return null;
        }
    }
}
