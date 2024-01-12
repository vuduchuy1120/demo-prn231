using Demo_API_Empty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_Empty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        MySaleDBContext _saleDBContext = new MySaleDBContext();
        //get all
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            return Ok(_saleDBContext.Customers.ToList());
        }
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            _saleDBContext.Customers.Add(customer);
            _saleDBContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var customerOld = _saleDBContext.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
            if (customerOld == null)
            {
                return BadRequest();
            }
            customerOld.CustomerName = customer.CustomerName;
            customerOld.Address = customer.Address;
            customerOld.Birthdate = customer.Birthdate;
            customerOld.Gender = customer.Gender;
            _saleDBContext.SaveChanges();
            return Ok(customerOld);
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _saleDBContext.Customers.SingleOrDefault(x => x.CustomerId == id);
            _saleDBContext.Remove(customer);
            _saleDBContext.SaveChanges();
            return Ok();
        }
        [HttpGet("id")]
        public IActionResult GetCustomerByID(int id)
        {
            var customer = _saleDBContext.Customers.Find(id);
            return Ok(customer);
        }
       
    }
}
