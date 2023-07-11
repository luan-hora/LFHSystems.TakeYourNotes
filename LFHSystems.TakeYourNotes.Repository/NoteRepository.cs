using LFHSystems.TakeYourNotes.Model;
using LFHSystems.TakeYourNotes.Repository.Context;
using LFHSystems.TakeYourNotes.Repository.Interface;
using System;
using System.Collections.Generic;

namespace LFHSystems.TakeYourNotes.Repository
{
    public class NoteRepository : ICrud<NoteModel>
    {
        private readonly TakeYourNotesDBContext _ctx;
        public NoteRepository(TakeYourNotesDBContext ctx)
        {
            this._ctx = ctx;
        }

        public int Delete(NoteModel pObj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoteModel> GetAll()
        {
            return _ctx.Note;
        }

        public NoteModel GetByParameter(NoteModel pObj)
        {
            throw new NotImplementedException();
        }

        public void Insert(ref NoteModel pObj)
        {
            _ctx.Note.Add(pObj);
            _ctx.SaveChanges();
        }

        public void Update(NoteModel pObj)
        {
            throw new NotImplementedException();
        }
    }
}
