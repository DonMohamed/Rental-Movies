using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidlly.Dtos;
using Vidlly.Models;

namespace Vidlly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get Api/Customers 
        public IHttpActionResult GetCustomers(string Query=null)
        {

            var CustomersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(Query))
                CustomersQuery = CustomersQuery.Where(c => c.Name.Contains(Query));

               var customerDto= CustomersQuery
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);

            return Ok(customerDto);
        }
        // Get Api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>( customer));
        
        }
        //post Api/custpmers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" +customer.Id), customerDto );
        }
        // Put Api/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto,customerInDb);
            
            _context.SaveChanges();

            return Ok();

        }
        //Delete Api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return BadRequest();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
