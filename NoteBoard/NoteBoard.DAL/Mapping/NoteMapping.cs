using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBoard.DAL.Mapping
{
    public class NoteMapping:EntityTypeConfiguration<Note>
    {
        public NoteMapping()
        {
            Property(t => t.Title).IsRequired().HasMaxLength(25);
            Property(c => c.Content).IsRequired().HasMaxLength(250);
            HasRequired(a => a.User).WithMany(a => a.Notes).HasForeignKey(a => a.UserID);
            Map(a => a.MapInheritedProperties());
            HasKey(a => a.NoteID);
            Property(a => a.NoteID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
