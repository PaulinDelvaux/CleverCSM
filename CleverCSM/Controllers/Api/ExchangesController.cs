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

        // GET /api/exchanges
        public IEnumerable<ExchangeDTO> GetExchange()
        {
            return _context.Exchange.ToList().Select(Mapper.Map<Exchange, ExchangeDTO>);
        }

        // GET /api/exchanges/1
        public IHttpActionResult GetExchange(int id)
        {
            var exchange = _context.Exchange.Include(c=>c.Contact).Include(c=>c.User).SingleOrDefault(c => c.User.Id == id);

            if (exchange == null)
                return NotFound();

            return Ok(Mapper.Map<Exchange, ExchangeDTO>(exchange));
        }


        // POST /api/exchanges
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

        // PUT api/exchanges/1
        [HttpPut]
        public void UpdateExchange(ExchangeDTO exchangedto)
        {
            var Inputexchange = Mapper.Map<ExchangeDTO, Exchange>(exchangedto);

            if (Inputexchange == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var exchange = _context.Exchange.SingleOrDefault(c => c.Id == exchangedto.Id);

            var priority = Inputexchange.Priority;

            if (priority == 3)
            {
                exchange.LastContact = DateTime.Now;
                exchange.NextContact = DateTime.Now.AddDays(exchangedto.Frequency);
                exchange.LastTryAttempt = DateTime.Now;
                exchange.NextTryAttempt = DateTime.Now.AddDays(exchangedto.Frequency);
            }
            if (priority == 2)
            {
                exchange.LastTryAttempt = DateTime.Now;
                exchange.NextTryAttempt = DateTime.Now.AddDays(2);
            }
            if (priority == 1)
            {
                exchange.LastTryAttempt = DateTime.Now;
                exchange.NextTryAttempt = DateTime.Now.AddDays(1);
            }
            
            _context.SaveChanges();
        }

        //DELETE api/exchanges/1
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
