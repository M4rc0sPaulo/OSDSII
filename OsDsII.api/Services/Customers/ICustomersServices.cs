using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OsDsII.api.Models;

namespace OSDSII.api.Services.Customers.interfaces
{
    public interface ICustomersServices
    {
                public Task<IEnumerable<Customer>> GetAllCustomersAsync();
                //Mudança do que é dito na Controller para o Services

    }
}