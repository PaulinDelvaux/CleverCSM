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
    public class MessagesController : ApiController
    {
        private Models.ApplicationDbContext _context;

        public MessagesController()
        {
            _context = new ApplicationDbContext();

        }

        // GET /api/customers
        public IEnumerable<MessageDTO> GetMessage()
        {
            return _context.Message.ToList().Select(Mapper.Map<Message, MessageDTO>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetMessage(int id)
        {
            var message = _context.Message.SingleOrDefault(c => c.ExchangeId == id);

            if (message == null)
                return NotFound();

            return Ok(Mapper.Map<Message, MessageDTO>(message));
        }


        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateMessage(MessageDTO messagedto)
        {
            messagedto.Time = DateTime.Now;

            var message = Mapper.Map<MessageDTO, Message>(messagedto);

            _context.Message.Add(message);
            _context.SaveChanges();

            messagedto.Id = message.Id;

            return Created(new Uri(Request.RequestUri + "/" + messagedto.Id), messagedto);
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateMessage(int id, MessageDTO messagedto)
        {
            var message = Mapper.Map<MessageDTO, Message>(messagedto);

            if (message == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Message.Add(message);
            _context.SaveChanges();
        }

        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteMessage(int id)
        {
            var message = _context.Message.SingleOrDefault(c => c.Id == id);

            if (message == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Message.Remove(message);
            _context.SaveChanges();
        }
    }
}
