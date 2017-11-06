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
    public class ExchangesController : ApiController
    {
        private Models.ApplicationDbContext _context;

        public ExchangesController()
        {
            _context = new ApplicationDbContext();

        }

        // GET /api/customers
        public IEnumerable<ExchangeDTO> GetExchange()
        {
            return _context.Exchange.ToList().Select(Mapper.Map<Exchange, ExchangeDTO>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetExchange(int id)
        {
            var exchange = _context.Exchange.SingleOrDefault(c => c.User.Id == id);

            if (exchange == null)
                return NotFound();

            return Ok(Mapper.Map<Exchange, ExchangeDTO>(exchange));
        }


        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateExchange(ExchangeDTO exchangedto)
        {
            exchangedto.LastContact = DateTime.Now;
            exchangedto.NextContact = DateTime.Now.AddDays(exchangedto.Frequency);
            exchangedto.Priority = 3;
            exchangedto.NextTryAttempt = exchangedto.NextContact;
            exchangedto.LastTryAttempt = exchangedto.LastContact;

            var exchange = Mapper.Map<ExchangeDTO,Exchange>(exchangedto);
            
            _context.Exchange.Add(exchange);
            _context.SaveChanges();

            exchangedto.Id = exchange.Id;

            return Created(new Uri(Request.RequestUri + "/" + exchangedto.Id), exchangedto);
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateExchange(int id, ExchangeDTO exchangedto)
        {
            var exchange = Mapper.Map<ExchangeDTO, Exchange>(exchangedto);

            if (exchange == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Exchange.Add(exchange);
            _context.SaveChanges();
        }

        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteExchange(int id)
        {
            var exchange = _context.Exchange.SingleOrDefault(c => c.Id == id);

            if (exchange == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Exchange.Remove(exchange);
            _context.SaveChanges();
        }
    }
}
