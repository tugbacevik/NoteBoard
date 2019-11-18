using NoteBoard.DAL.Mapping;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NoteBoard.DAL
{
   public  class NoteBoardDBContext:DbContext
    {
        public NoteBoardDBContext():base("server=.;Database=NoteBoardDBContext;UID=sa;PWD=123")
        {
            Database.SetInitializer(new NoteBoardsDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new PasswordMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
