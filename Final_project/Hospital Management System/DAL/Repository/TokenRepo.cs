using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class TokenRepo:Repository, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token Read(string TokenKey)
        {
            return db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));
        }

        public Token Update(Token obj)
        {
            var token = Read(obj.TokenKey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return token;
            return null;
        }
        public Token UpdateByToken(string TokenKey, Token obj)
        {
            var tokenEntity = db.Tokens.FirstOrDefault(t => t.TokenKey.Equals(TokenKey));

            if (tokenEntity != null)
            {
                var existingAdmin = Read(tokenEntity.email);

                if (existingAdmin != null)
                {
                    existingAdmin.email = obj.email;

                    if (db.SaveChanges() > 0)
                    {
                        return obj; 
                    }
                }
            }

            return null;
        }


    }
}

