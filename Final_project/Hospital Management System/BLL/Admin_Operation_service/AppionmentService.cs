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
    public class AppionmentService
    {
        public static AppionmentDTO AppionmentDoctor(string Token,int paitentId,int doctorId, AppionmentDTO AppionDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AppionmentDTO, Appointment>();
                c.CreateMap<Appointment, AppionmentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedAppionment = mapper.Map<Appointment>(AppionDTO);
            var data = DataAccessFactory.Admin_Op_AppionmentData().AppionmentAssignAd(Token, paitentId,doctorId,mappedAppionment);
            if (data != null)
            {
                return mapper.Map<AppionmentDTO>(data);
            }
            return null;
        }


        public static AppionmentDTO Search(int AppionentId)
        {
            var data = DataAccessFactory.AppionmentData().Read(AppionentId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Appointment, AppionmentDTO>();
            });
            var mapper = new Mapper(config);

            var D_AppionmentDto = mapper.Map<AppionmentDTO>(data);

            return D_AppionmentDto;
        }

        public static bool Delete(int AppionId)
        {
            return DataAccessFactory.AppionmentData().Delete(AppionId);


        }

        public List<(DoctorDTO,PaitentDTO,AppionmentDTO)> DoctorAppionment(int docAppointmentId)
        {
            var doctorAppointmentInfoList = DataAccessFactory.doc_AppionmentData().doctorAppionment(docAppointmentId);


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Appointment, AppionmentDTO>();
                cfg.CreateMap<Patient, PaitentDTO>();
                cfg.CreateMap<doctor, DoctorDTO>();

            });
            var mapper = new Mapper(config);
            var doctorAppointmentsDTO = doctorAppointmentInfoList.Select(x =>
         (
             mapper.Map<DoctorDTO>(x.Item1),
             mapper.Map<PaitentDTO>(x.Item2),
             mapper.Map<AppionmentDTO>(x.Item3)
         )).ToList();

            return doctorAppointmentsDTO;
        }

        public static cancelAppionmentDTO cancelAppionment(int PaitentId, cancelAppionmentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<cancelAppionmentDTO, Appointment>();
                c.CreateMap<Appointment, cancelAppionmentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedPai = mapper.Map<Appointment>(obj);
            var data = DataAccessFactory.dischargeAppionment().dischargebyAdmin(PaitentId, mappedPai); 
            if (data != null)
            {
                return mapper.Map<cancelAppionmentDTO>(data);
            }
            return null;
        }














    }
}
