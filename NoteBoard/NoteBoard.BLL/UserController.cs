using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
   public class UserController
    {
        UserDAL _userDAL;
        public UserController()
        {
            _userDAL = new UserDAL();
        }
        public bool Add(User user)
        {
            try
            {
                if (user.Passwords.Count > 0)
                {
                    user.IsActive = false;
                    user.CreatedDate = DateTime.Now;
                    user.Passwords.First().IsActive = true;
                    user.Passwords.First().CreatedDate = DateTime.Now;
                    //admin onayıyla beraber true
                    _userDAL.Add(user);
                    return true;
                }
                else { throw new Exception("Şifre yok"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Update(User user)
        {
            try
            {
                user.ModifiedDate = DateTime.Now;
                _userDAL.Update(user);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(User user)
        {
            try
            {
                user.IsActive = false;
                return Update(user);
                //veritabanından silmiyoruz, aktifliğini kapatıyoruz.
                //30 günden fazla pasif kalırsa silinsin
                //Admin kara listeye alamıyor 
                //
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public User GetByID(int UserID)
        {
            return _userDAL.GetById(UserID);
        }

        public User GetByLogin(string username, string password)
        {
            List<User> users = _userDAL.GetAll();
            User user = users.Where(a => a.IsActive && a.UserName == username).SingleOrDefault();
            if (user !=null)
            {
                Password pass = user.Passwords.Where(a => a.IsActive && a.PasswordText == password).FirstOrDefault();
                if (pass == null)
                {
                    return null;
                }
            }
            return user;
        }
        public List<User> GetAll()
        {
            return _userDAL.GetAll();
        }

    }
}
