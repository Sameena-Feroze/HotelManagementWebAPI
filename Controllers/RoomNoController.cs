using HotelManagementWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomNoController : ControllerBase
    {
        //data fields
        private readonly IRoomNoRepository _roomNoRepository;

        //constructor injection
        public RoomNoController(IRoomNoRepository roomNoRepository)
        {
            _roomNoRepository = roomNoRepository;
        }


        #region  get all Room Details--view model
        //api/roomno/roomdetails
        [HttpGet]
        [Route("roomdetails")]
        public async Task<IActionResult> GetRoomDetails()
        {
            try
            {
                var room = await _roomNoRepository.GetRoomDetails();

                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        //Add Roomdetails



    }
}
