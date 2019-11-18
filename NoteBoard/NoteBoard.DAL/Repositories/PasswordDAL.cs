using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Repositories
{
   public class PasswordDAL
    {
        NoteBoardDBContext _db;
        public PasswordDAL()
        {
            _db = new NoteBoardDBContext();
        }

        public int Add(Password pwd)
        {
            _db.Passwords.Add(pwd);
            return _db.SaveChanges();
        }
        public int Update(Password pwd)
        {
            _db.Entry(pwd).State=EntityState.Modified;
            return _db.SaveChanges();
        }
        public int Delete(Password pwd)
        {
            _db.Entry(pwd).State = EntityState.Deleted;
            return _db.SaveChanges();
        }
        public List<Password> GetAll()
        {
            return _db.Passwords.ToList();
        }
        public Password GetById(int pwd)
        {
            return _db.Passwords.FirstOrDefault(a => a.PasswordNum == pwd);
        }
    }
}
