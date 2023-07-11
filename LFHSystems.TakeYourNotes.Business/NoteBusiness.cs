using LFHSystems.TakeYourNotes.Business.Base;
using LFHSystems.TakeYourNotes.Model;
using LFHSystems.TakeYourNotes.Utils.API;
using LFHSystems.TakeYourNotes.Utils.Extensions;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace LFHSystems.TakeYourNotes.Business
{
    public class NoteBusiness : BaseBusiness<NoteModel>
    {
        IConfiguration _configuration;
        public NoteBusiness(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<NoteModel> CreateNewNote(NoteModel pObj)
        {
            try
            {
                pObj.CreationDate = DateTime.Now;
                StringContent content = new StringContent(pObj.ToJson(), Encoding.UTF8, "application/json");
                string response = await APIConsume.ApiPostAsync($"{_configuration.GetSection("ApiAddresses:WebApiTakeYourNotes").Value}/Note/Insert", content);

                return pObj;
            }
            catch (Exception ex)
            {

                throw;
            }
        }               

        public List<NoteModel> GetExistingNotes()
        {
            List<NoteModel> ret;
            try
            {
                string response = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiTakeYourNotes").Value}/Note/GetExistingNotes").Result;
                ret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NoteModel>>(response) ?? new List<NoteModel>();

                return ret;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override bool ValidateModel(NoteModel pObj)
        {
            throw new NotImplementedException();
        }
    }
}