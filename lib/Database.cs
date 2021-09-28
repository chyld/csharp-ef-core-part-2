using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace lib
{
  public class Database : DbContext
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Klass> Klasses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      var basedir = System.AppContext.BaseDirectory;
      var solndir = Directory.GetParent(basedir).Parent.Parent.Parent.Parent;
      options.UseSqlite($"Data Source={solndir.FullName}/db/app.db");
      // options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    }
  }
}
