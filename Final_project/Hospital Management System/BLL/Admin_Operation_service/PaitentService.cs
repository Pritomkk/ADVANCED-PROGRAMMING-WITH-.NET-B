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
    public class PaitentService
    {
        public static PaitentDTO AddByAdmin(string Token, PaitentDTO AddPaiDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaitentDTO, Patient>();
                c.CreateMap<Patient, PaitentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedADoc = mapper.Map<Patient>(AddPaiDTO);
            var data = DataAccessFactory.Admin_Op_PaitentData().AddbyAdmin(Token, mappedADoc);
            if (data != null)
            {
                return mapper.Map<PaitentDTO>(data);
            }
            return null;
        }
        public static PaitentDTO Search(int PaitentId)
        {


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PaitentDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.PaitentData().Read(PaitentId);

            if (data != null)
            {
                return mapper.Map<PaitentDTO>(data);
            }
            return null;


        }


        public static bool Delete(int PaitentId)
        {
            return DataAccessFactory.PaitentData().Delete(PaitentId);
        }

        public static dischargePaitentDTO DischargePaitent(int PaitentId, dischargePaitentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<dischargePaitentDTO, Patient>();
                c.CreateMap<Patient, dischargePaitentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedPai = mapper.Map<Patient>(obj);
            var data = DataAccessFactory.Admin_Op_PaitentData().dischargebyAdmin(PaitentId, mappedPai); // Change method name to AddByAdmin
            if (data != null)
            {
                return mapper.Map<dischargePaitentDTO>(data);
            }
            return null;
        }


    }
}
