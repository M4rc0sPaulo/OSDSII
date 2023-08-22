
using OsDsII.api.Data;
using OsDsII.api.Models;
using Microsoft.EntityFrameworkCore;
using OSDSII.api.Services.Customers.interfaces;

namespace OSDSII.api.Services.Customers
{
    public class CustomersServices : ICustomersServices
    {
         private readonly DataContext _context;

        public CustomersServices(DataContext context)
        {
            _context = context;
        }
         public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }
        //Regra de negócio largar um Return throw Exception("Nome dado ao erro");
    }
}