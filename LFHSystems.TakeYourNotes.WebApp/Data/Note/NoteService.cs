using LFHSystems.TakeYourNotes.Business;
using LFHSystems.TakeYourNotes.Model;

namespace LFHSystems.TakeYourNotes.WebApp.Data.Note
{
    public class NoteService
    {
        private IConfiguration _configuration;
        private NoteBusiness noteBus;
        public NoteService(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.noteBus = new NoteBusiness(_configuration);
        }

        public async Task InsertLead(NoteModel pObj)
        {
            try
            {
                await noteBus.CreateNewNote(pObj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }                
    }
}
