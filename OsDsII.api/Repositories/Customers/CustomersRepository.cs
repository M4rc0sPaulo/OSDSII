using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;
using OSDSII.api.Repositories.interfaces;

namespace OSDSII.api.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DataContext _context;

        public CustomersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }
/*IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;*/
       
    }
}