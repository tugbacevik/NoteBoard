using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NoteBoard.Model;

namespace NoteBoard.DAL.Repositories
{
   public class UserDAL
    {
        NoteBoardDBContext _db;
        public UserDAL()
        {
           _db = new NoteBoardDBContext();
        }

        public int Add(User user)
        {
           // _db.Users.Add(user);
            _db.Entry(user).State = EntityState.Added;
            return _db.SaveChanges();
        }

        public int Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public int Delete(User user)
        {
            _db.Entry(user).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();

        }
        public User GetById(int UserID)
        {
            return _db.Users.FirstOrDefault(a => a.UserID == UserID);
        }
    }
}
