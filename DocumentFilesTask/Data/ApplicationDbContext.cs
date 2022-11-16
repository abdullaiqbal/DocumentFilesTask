using DocumentFilesTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentFilesTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<FilesRecord> FilesRecords { get; set; }
        public DbSet<AppFile> File { get; set; }
    }

}
