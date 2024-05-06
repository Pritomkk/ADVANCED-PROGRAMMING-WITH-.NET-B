using AutoMapper;
using BLL.DTOS;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin_Operation_service
{
     public class DepartmentService
    {
        public static DepartmentDTO AddByAdmin(string Token, DepartmentDTO AddDep)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DepartmentDTO, Department>();
                c.CreateMap<Department, DepartmentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedADep= mapper.Map<Department>(AddDep);
            var data = DataAccessFactory.CreateDepartmentByAdmin().AddbyAdmin(Token, mappedADep);
            if (data != null)
            {
                return mapper.Map<DepartmentDTO>(data);
            }
            return null;
        }

    }
}
