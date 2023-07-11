using System;

namespace LFHSystems.TakeYourNotes.Model
{
    public class NoteModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
