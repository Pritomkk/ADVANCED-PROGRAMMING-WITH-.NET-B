using BLL.DTOS;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Admin_Auth_Service
{
    public class AdminCrudService
    {
        public static AdminDTO Get(string TokenKey)
        {
            var data = DataAccessFactory.AdminData().Read(TokenKey);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });

            var mapper = new Mapper(config);

            var adminDto = mapper.Map<AdminDTO>(data);

            return adminDto;
        }



        public static bool Delete(string TokenKey)
        {
            return DataAccessFactory.AdminData().Delete(TokenKey);

         
        }

    }
}