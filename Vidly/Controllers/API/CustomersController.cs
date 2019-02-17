using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }
        //GET/api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        
        //GET/api/Customers/id
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        //POST/api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //PUT/api/Customers/
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var custinDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(custinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            custinDb.Name = customer.Name;
            custinDb.Birthdate = customer.Birthdate;
            custinDb.isSubscribedtoNewsletter = customer.isSubscribedtoNewsletter;
            custinDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        //DELETE/api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var custinDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (custinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(custinDb);
            _context.SaveChanges();
        }
    }
}
