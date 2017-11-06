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
    public class CompaniesController : ApiController
    {
        private ApplicationDbContext _context;

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/companies
        public IEnumerable<CompanyDTO> GetCompanies()
        {
            return _context.Company.Include(c => c.AddressInfo).ToList().Select(Mapper.Map<Company, CompanyDTO>);
        }

        // GET /api/companies/1
        public IHttpActionResult GetCompany(int id)
        {
            var company = _context.Company.Include(c => c.AddressInfo).SingleOrDefault(c => c.Id == id);

            if (company == null)
                return NotFound();

            return Ok(Mapper.Map<Company, CompanyDTO>(company));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCompany(CompanyDTO companydto)
        {
            var company = Mapper.Map<CompanyDTO, Company>(companydto);
            var addressinfo = Mapper.Map<AddressInfoDTO, AddressInfo>(companydto.AddressInfo);

            _context.AddressInfo.Add(addressinfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == companydto.AddressInfo.Email && c.Address == companydto.AddressInfo.Address && c.Phone == companydto.AddressInfo.Phone);

            companydto.AddressInfoId = aInfo.Id;

            _context.Company.Add(company);
            _context.SaveChanges();

            companydto.Id = company.Id;

            return Created(new Uri(Request.RequestUri + "/" + companydto.Id), companydto);
        }

        // PUT api/companies/1
        [HttpPut]
        public void UpdateCompany(int id)
        {
            var company = _context.Company.SingleOrDefault(c => c.Id == id);

            var companydto = Mapper.Map<Company, CompanyDTO>(company);
            var addressinfo = Mapper.Map<AddressInfoDTO, AddressInfo>(companydto.AddressInfo);


            _context.AddressInfo.Add(addressinfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == companydto.AddressInfo.Email && c.Address == companydto.AddressInfo.Address && c.Phone == companydto.AddressInfo.Phone);

            company.Id = id;
            company.AddressInfoId = aInfo.Id;

            _context.Company.Add(company);
            _context.SaveChanges();
        }

        //DELETE api/companies/1
        [HttpDelete]
        public void DeleteCompany(int id)
        {
            var company = _context.Company.SingleOrDefault(c => c.Id == id);

            if (company == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Company.Remove(company);
            _context.SaveChanges();
        }

    }
}
