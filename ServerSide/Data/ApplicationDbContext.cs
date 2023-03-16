using Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Interface;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Degree> Degrees { get; set; }

        #region Helpers
        private void HanldeEntityRecords()
        {
            foreach(var entry in base.ChangeTracker.Entries<IEntity>().Where(x => x.State == EntityState.Added))
            {
                entry.Entity.Id = Guid.NewGuid();
                entry.Entity.DateCreated = DateTime.Now;
            }
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CVTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            HanldeEntityRecords();
            return await base.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> SaveChanges()
        {
            HanldeEntityRecords();
            return base.SaveChanges();
        }
    }
}