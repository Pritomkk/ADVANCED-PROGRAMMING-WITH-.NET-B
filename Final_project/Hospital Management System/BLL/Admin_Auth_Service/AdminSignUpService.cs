using AutoMapper;
using BLL.DTOS;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin_Auth_Service
{
    public class AdminSignUpService
    {
        public static AdminDTO SignUp(AdminDTO admin)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Admin>(admin);
            var data = DataAccessFactory.AdminData().Create(mapped);


            if (data != null)
                return mapper.Map<AdminDTO>(data);
            return null;
        }
    }
}
