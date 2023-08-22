using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;
using OSDSII.api.Repositories.interfaces;

namespace OsDsII.api.Controllers

//DETECÇÃO DE REGRA DE NEGÓCIO
{
    [ApiController]
    [Route("Controller")]
    public class CustomersController : ControllerBase


    {

        private readonly DataContext _context;
        private readonly ICustomersRepository _customersRepository;

        public CustomersController(DataContext context, ICustomersRepository customersRepository)
        {
            _context = context;
            _customersRepository = customersRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                //List<Customer> lista = await _context.Customers.ToListAsync();
                IEnumerable<Customer> lista = await _customersRepository.GetAllCustomersAsync();
                //Essa ação está sendo feita no repositório, então é apenas chama-la
                return Ok(lista);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Customer customer = await _context.Customers
                        .SingleOrDefaultAsync(pBusca => pBusca.Id == id);
                        return Ok(customer);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message); ;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add ([FromBody] Customer newCustomer)
        //Existe um corpo na equisição (JSON)----A
        {
            try
            {
                newCustomer = _context.Customers.FirstOrDefault(cBusca => cBusca.Id == newCustomer.Id);



                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync();

                return Ok (newCustomer);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Customer DeleteCustomer =  await _context.Customers
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                _context.Customers.Remove(DeleteCustomer);
                int linhasafetadas =  await _context.SaveChangesAsync();
                return Ok(linhasafetadas);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                Customer UpdateCustomer =  await _context.Customers
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                _context.Customers.Update(UpdateCustomer);
                int linhasafetadas = await _context.SaveChangesAsync();
                return Ok(linhasafetadas); ;
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
       

    };
}
