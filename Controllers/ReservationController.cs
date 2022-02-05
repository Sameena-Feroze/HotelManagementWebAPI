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
    public class ReservationController : ControllerBase
    {
        //data fields
        private readonly IReservationRepository  _reservationRepository;

        //constructor injection
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }


        #region  get all Reservation Details
        //api/roomno/reservationdetails
        [HttpGet]
        [Route("reservationdetails")]
        public async Task<IActionResult> GetReservationDetails()
        {
            try
            {
                var room = await _reservationRepository.GetReservationDetails();

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

    }
}
