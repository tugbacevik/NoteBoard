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
            return _userDAL.Add(user) > 0;
        }
        //admin onay verirse yayınlanacak. 
    }
}
