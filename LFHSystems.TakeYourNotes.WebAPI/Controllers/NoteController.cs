using LFHSystems.TakeYourNotes.Model;
using LFHSystems.TakeYourNotes.Repository;
using LFHSystems.TakeYourNotes.Repository.Context;
using Microsoft.AspNetCore.Mvc;

namespace LFHSystems.TakeYourNotes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        readonly NoteRepository repo;
        readonly TakeYourNotesDBContext _ctx;
        public NoteController(IConfiguration configuration, TakeYourNotesDBContext context)
        {
            this._ctx = context;
            repo = new NoteRepository(this._ctx);
        }

        [HttpPost]
        [Route("Insert")]
        public JsonResult Insert([FromBody] NoteModel pLead)
        {
            repo.Insert(ref pLead);
            return Json(pLead);
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update([FromBody] NoteModel pLead)
        {
            repo.Update(pLead);
            return Json(pLead);
        }

        [HttpDelete()]
        [Route("DeleteExistingNote/{pId}")]
        public IActionResult Delete(int pId)
        {
            repo.Delete(new NoteModel() { ID = pId });
            return Ok();
        }

        [HttpGet]
        [Route("GetExistingNoteById/{pId}")]
        public JsonResult GetExistingNoteById(int pId)
        {
            NoteModel ret;
            ret = repo.GetByParameter(new NoteModel() { ID = pId });

            return Json(ret);
        }

        [HttpGet]
        [Route("GetExistingNotes")]
        public JsonResult GetExistingNotes()
        {
            IEnumerable<NoteModel> ret;
            ret = repo.GetAll();

            return Json(ret);
        }

    }
}
