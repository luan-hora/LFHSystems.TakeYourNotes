using LFHSystems.TakeYourNotes.Model;
using Microsoft.EntityFrameworkCore;

namespace LFHSystems.TakeYourNotes.Repository.Context
{
    public class TakeYourNotesDBContext : DbContext
    {

        public DbSet<NoteModel> Note { get; set; }
        public TakeYourNotesDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NoteModel>(e =>
            {
                e.ToTable("Tb_Notes").HasKey(k => k.ID);
                e.Property(p => p.ID).ValueGeneratedOnAdd();
            });
        }
    }
}
