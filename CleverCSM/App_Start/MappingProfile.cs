using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CleverCSM.Models;
using CleverCSM.DTOs;

namespace CleverCSM.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<AddressInfo, AddressInfoDTO>();
            Mapper.CreateMap<AddressInfoDTO, AddressInfo>();
            Mapper.CreateMap<CompanyCustomer, CompanyCustomerDTO>();
            Mapper.CreateMap<CompanyCustomerDTO, CompanyCustomer>();
            Mapper.CreateMap <Company, CompanyDTO> ();
            Mapper.CreateMap <CompanyDTO, Company> ();
            Mapper.CreateMap <Contact,ContactDTO> ();
            Mapper.CreateMap <ContactDTO,Contact> ();
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap <Exchange,ExchangeDTO> ();
            Mapper.CreateMap <ExchangeDTO,Exchange> ();
            Mapper.CreateMap <Message,MessageDTO> ();
            Mapper.CreateMap <MessageDTO,Message> ();
            Mapper.CreateMap <User,UserDTO> ();
            Mapper.CreateMap <UserDTO,User> ();

        }
    }
}