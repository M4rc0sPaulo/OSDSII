using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OsDsII.api.Models;


namespace OSDSII.api.Repositories.interfaces
{
    public interface ICustomersRepository
    //Injetar uma interface
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}