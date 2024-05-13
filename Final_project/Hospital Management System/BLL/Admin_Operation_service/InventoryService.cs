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
    public class InventoryService
    {

        public static InventoryDTO AddInventory(string Token, InventoryDTO AddInvenDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<InventoryDTO, Inventory>();
                c.CreateMap<Inventory, InventoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedInven = mapper.Map<Inventory>(AddInvenDTO);
            var data = DataAccessFactory.Admin_Op_InventoryData().AddbyAdmin(Token, mappedInven);
            if (data != null)
            {
                return mapper.Map<InventoryDTO>(data);
            }
            return null;
        }
        public List<InventoryDTO> AllInventoryinfo()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Inventory, InventoryDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.InventoryData().Read();

            if (data != null)
            {

                return mapper.Map<List<InventoryDTO>>(data);
            }
            return null;
        }


        public static InventoryDTO BillingInfo(int InvenId)
        {


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Inventory, InventoryDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.InventoryData().Read(InvenId);

            if (data != null)
            {
                return mapper.Map<InventoryDTO>(data);
            }
            return null;


        }


        public static bool Delete(int InventoryId)
        {
            return DataAccessFactory.InventoryData().Delete(InventoryId);
        }

    }
}
