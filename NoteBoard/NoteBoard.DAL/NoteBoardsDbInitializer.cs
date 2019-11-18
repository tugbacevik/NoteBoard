using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NoteBoard.Model;

namespace NoteBoard.DAL
{
    class NoteBoardsDbInitializer:CreateDatabaseIfNotExists<NoteBoardDBContext>
    {

        protected override void Seed(NoteBoardDBContext context)
        {
            User user = new User();
            user.FirstName = "Tuğba";
            user.LastName = "Çevik";
            user.UserName = "admin";
            user.UserRole = UserRole.Admin;
            user.IsActive = true;
            user.CreatedDate = DateTime.Now;
            user.Passwords.Add(new Password()
            {
                PasswordText = "Ba123",
                IsActive = true,
                CreatedDate = DateTime.Now
            });

            context.Users.Add(user);
            context.SaveChanges();
            base.Seed(context); // Base'deki seed metoduna ekliyoruz.
        }
    }
}
