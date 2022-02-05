using HotelManagementWebAPI.Models;
using HotelManagementWebAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Repository
{
    public class RoomNoRepository : IRoomNoRepository
    {

        //data fields
        private readonly HotelManagementContext _context;

        //default constructor
        //constructor based dependency injection
        public RoomNoRepository(HotelManagementContext context)
        {
            _context = context;
        }

       

        public async Task<List<RoomDetailsViewModel>> GetRoomDetails()
        {
            if (_context!= null)
            //linq
            {    
                return await(from r in _context.RoomNo
                             from c in _context.Category
                             where r.CategoryId == c.CategoryId
                             select new RoomDetailsViewModel
                             {
                                 RoomNo = r.RoomNoId,
                                                                CategoryName = c.CategoryName,
                                 Rate= r.Rate

                             }
                             ).ToListAsync();
            }
            return null;
        }

    }

        
    

    
}
   
   

