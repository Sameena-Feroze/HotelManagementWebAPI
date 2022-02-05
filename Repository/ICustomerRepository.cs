using HotelManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<int> AddCustomer(Customer customer);


        //update medicines
        Task UpdateCustomer(Customer customer);


        //delete medicines
        Task<int> DeleteCustomer(int? id);
    }
}
