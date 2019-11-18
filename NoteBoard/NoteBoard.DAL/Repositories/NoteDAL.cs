using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace NoteBoard.DAL.Repositories
{
    public class NoteDAL
    {
        NoteBoardDBContext _db;
        public NoteDAL()
        {
            _db = new NoteBoardDBContext();
        }

        public int Add(Note note)
        {
            _db.Entry(note).State =EntityState.Added;
            return _db.SaveChanges();
        }

        public int Update(Note note)
        {
            _db.Entry(note).State = EntityState.Modified;
            return _db.SaveChanges();
        }
        public int Delete(Note note)
        {

            _db.Entry(note).State = EntityState.Deleted;
            return _db.SaveChanges();
        }
        public Note GetById(int noteID)
        {
            return _db.Notes.FirstOrDefault(a => a.NoteID == noteID);
        }
        public List<Note> GetAll()
        {
            return _db.Notes.ToList();
        }

    }
}
