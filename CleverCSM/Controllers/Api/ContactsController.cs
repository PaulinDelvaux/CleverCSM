using CleverCSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using CleverCSM.Models;
using System.Data.Entity;
using CleverCSM.DTOs;
using AutoMapper;

namespace CleverCSM.Controllers.Api
{
    public class ContactsController : ApiController
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/contacts
        public IEnumerable<ContactDTO> GetContacts()
        {
            return _context.Contact.Include(c => c.AddressInfo).ToList().Select(Mapper.Map<Contact, ContactDTO>);
        }

        // GET /api/contacts/1
        public IHttpActionResult GetContact(int id)
        {
            var contact = _context.Contact.Include(c => c.AddressInfo).SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound();

            return Ok(Mapper.Map<Contact, ContactDTO>(contact));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateContact(ContactDTO contactdto)
        {
            var contact = Mapper.Map<ContactDTO, Contact>(contactdto);

            _context.Contact.Add(contact);
            _context.SaveChanges();

            return Ok(Mapper.Map<Contact, ContactDTO>(contact));
        }

        // PUT api/contacts/1
        [HttpPut]
        public void UpdateContact(int id, ContactDTO contactdto)
        {
            var contact = Mapper.Map<ContactDTO, Contact>(contactdto);
            var addressinfo = Mapper.Map<AddressInfoDTO, AddressInfo>(contactdto.AddressInfo);


            _context.AddressInfo.Add(addressinfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == contactdto.AddressInfo.Email && c.Address == contactdto.AddressInfo.Address && c.Phone == contactdto.AddressInfo.Phone);

            contact.Id = id;
            contact.AddressInfoId = aInfo.Id;

            _context.Contact.Add(contact);
            _context.SaveChanges();
        }

        //DELETE api/contacts/1
        [HttpDelete]
        public void DeleteContact(int id)
        {
            var contact = _context.Contact.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Contact.Remove(contact);
            _context.SaveChanges();
        }

    }
}