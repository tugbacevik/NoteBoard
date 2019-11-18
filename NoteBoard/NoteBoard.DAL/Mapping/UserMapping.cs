using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(a => a.FirstName).IsRequired().HasMaxLength(20);
            Property(a => a.LastName).IsRequired().HasMaxLength(30);
            Property(a => a.UserName).IsRequired().HasMaxLength(18);
            HasKey(u => u.UserID);
            Property(u => u.UserID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map(a => a.MapInheritedProperties()); //Kalıtım alınan proppertyleride mappliyor.
            HasIndex(a => a.UserName).IsUnique();

        }
    }
}
