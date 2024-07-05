using Microsoft.EntityFrameworkCore;

namespace task1_read_from_txt
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ZEZOTAHA\SQLEXPRESS;Initial Catalog=NBS_Task1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True");

        }

        public DbSet<FileData> Files { get; set; }
        public DbSet<FileComponent> Components { get; set; }
    }
}
