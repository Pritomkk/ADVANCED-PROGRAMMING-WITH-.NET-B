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
    public class DoctorService
    { 
        public static DoctorDTO AddByAdmin(int dep_id,string Token, DoctorDTO AddDocDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DoctorDTO,doctor>();
                c.CreateMap<doctor, DoctorDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedADoc= mapper.Map<doctor>(AddDocDTO);
            var data = DataAccessFactory.DoctorDataOpByAdmin().AddByAdminDep(dep_id,Token, mappedADoc);
            if (data != null)
            {
                return mapper.Map<DoctorDTO>(data);
            }
            return null;
        }

        public static DoctorDTO Search(int DoctorId)
        {
            var data = DataAccessFactory.DoctorData().Read(DoctorId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);

            var doctorDto = mapper.Map<DoctorDTO>(data);

            return doctorDto;
        }

        public static bool Delete(int docId)
        {
            return DataAccessFactory.DoctorData().Delete(docId);


        }



    }
}
