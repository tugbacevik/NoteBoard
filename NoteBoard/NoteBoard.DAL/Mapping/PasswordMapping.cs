using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using NoteBoard.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBoard.DAL.Mapping
{
    class PasswordMapping: EntityTypeConfiguration<Password>
    {
        public PasswordMapping()
        {
            Property(a => a.PasswordText).IsRequired().HasMaxLength(16);
            HasRequired(a => a.User).WithMany(a => a.Passwords).HasForeignKey(a => a.UserID);
            Map(a => a.MapInheritedProperties());
            HasKey(p => p.PasswordNum);
            Property(p => p.PasswordNum).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
