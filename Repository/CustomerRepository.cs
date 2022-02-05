using HotelManagementWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Repository
{
    public class CustomerRepository :ICustomerRepository
    {

        private readonly HotelManagementContext _context;

        public CustomerRepository(HotelManagementContext context)
        {
            _context = context;
        }



        // GetAllCustomers
        #region  GetAllCustomers

        public async Task<List<Customer>> GetAllCustomers()
        {
            if (_context != null)
            {
                return await _context.Customer.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Customer
        public async Task<int> AddCustomer(Customer customer)
        {
            if (_context != null)
            {
                await _context.Customer.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer.CustId;
            }
            return 0;
        }
        #endregion

        //delete customer
        #region delete customer
        public async Task<int> DeleteCustomer(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var customer = await _context.Customer.FirstOrDefaultAsync(cust => cust.CustId == id);

                //check condition
                if (customer != null)
                {
                    _context.Customer.Remove(customer);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion

        //UpdateCustomer
        #region UpdateCustomer

        public async Task UpdateCustomer(Customer customer)
        {
            if (_context != null)
            {
                _context.Entry(customer).State = EntityState.Modified;
                _context.Customer.Update(customer);
                await _context.SaveChangesAsync(); //Commit the transaction
            }

        }

        public Task<int> AddCustomer(CustomerRepository customerRepository)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomer(CustomerRepository customerRepository)
        {
            throw new NotImplementedException();
        }
        #endregion








    }
}
