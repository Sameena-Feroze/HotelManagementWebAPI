using HotelManagementWebAPI.Models;
using HotelManagementWebAPI.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class CustomerController : ControllerBase
    {
        //Data fields
        private readonly ICustomerRepository _customerRepository;

        //Constructor injection
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #region get all Customers
        [HttpGet]
        //[Route("getallcustomers")]
        //[Authorize]
       
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }
        #endregion

        #region Add Customer
        [HttpPost]
        //[Route("addcustomer")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var custId = await _customerRepository.AddCustomer(customer);
                    if (custId > 0)
                    {
                        return Ok(custId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Update Customer
        [HttpPut]
        //[Route("update")]
        //https://localhost:44385/api/customer/updatecustomer
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerRepository.UpdateCustomer(customer);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion




        #region Delete Customer
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _customerRepository.DeleteCustomer(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
