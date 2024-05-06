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
    public class AuthService
    {
        public static bool IsTokenValid (string tokenKey)
        {
            var extinkey = DataAccessFactory.TokenData().Read(tokenKey)
            ;
            if(extinkey != null && extinkey.DeletedAt==null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string tkey)
        {
            var extinkey = DataAccessFactory.TokenData().Read(tkey);
            if (extinkey != null)
            {
                extinkey.DeletedAt = DateTime.Now;
                if (DataAccessFactory.TokenData().Update(extinkey) != null)
                {
                    return true;
                }
            }
            return false;
        }


        public static TokenDTO LogInAuthenticate(string Adminemail, string password)
        {
            var res = DataAccessFactory.AuthData().LogInAuthenticate(Adminemail, password);
            if (res)
            {
                var token = new Token();
                token.email = Adminemail;
                var AdminId=DataAccessFactory.LoginAdminId().GetAdminIdByEmail(Adminemail);
                token.AdminId = AdminId;
                token.CreatedAt = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            return null;
        }


        public static AdminDTO Update2(string TokenKey, AdminDTO updatedAdminDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mappedAdmin = mapper.Map<Admin>(updatedAdminDTO);

            var data = DataAccessFactory.AdminData().UpdateByToken(TokenKey, mappedAdmin);

            if (data != null)
            {
               
                return mapper.Map<AdminDTO>(data);
            }
            return null;
        }









    }
}
