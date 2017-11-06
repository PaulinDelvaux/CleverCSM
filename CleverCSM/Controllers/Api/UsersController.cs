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
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/users
        public IEnumerable<User> GetUsers()
        {
            return _context.User.Include(c => c.AddressInfo).ToList();
        }

        // GET /api/users/1
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.User.Include(c => c.AddressInfo).SingleOrDefault(c => c.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST /api/sers
        [HttpPost]
        public IHttpActionResult CreateUser(User user)
        {
            
            _context.AddressInfo.Add(user.AddressInfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == user.AddressInfo.Email && c.Address == user.AddressInfo.Address && c.Phone == user.AddressInfo.Phone);

            user.AddressInfoId = aInfo.Id;

            _context.User.Add(user);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + user.Id), user);
        }

        // PUT api/users/1
        [HttpPut]
        public void UpdateUser(int id)
        {
            var user = _context.User.SingleOrDefault(c => c.Id == id);

            var cInfo = _context.Company.SingleOrDefault(c => c.Name==user.CompanyName);

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Id == user.AddressInfoId);

            user.Id = id;
            //user.AddressInfoId = aInfo.Id;
            user.Company = cInfo;
            user.AddressInfo = aInfo;

            _context.SaveChanges();
        }

        //DELETE api/users/1
        [HttpDelete]
        public void DeleteUser(string id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

    }
}
