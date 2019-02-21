using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;
using AutoMapper;

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
        public IEnumerable<CustomerDto> GetCustomers()
        {
           var customerDtos =  _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);

            return customerDtos;
        }
        
        //GET/api/Customers/id
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        //POST/api/Customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerdto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return customerdto;
        }

        //PUT/api/Customers/
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var custinDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(custinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customerdto, custinDb);
          /*  custinDb.Name = customerdto.Name;
            custinDb.Birthdate = customerdto.Birthdate;
            custinDb.isSubscribedtoNewsletter = customerdto.isSubscribedtoNewsletter;
            custinDb.MembershipTypeId = customerdto.MembershipTypeId; */

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
