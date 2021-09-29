using System;
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

      // to disable change tracking
      // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
      // db.Entry(some_obj).State = EntityState.Detached;

      // use either option below to log the queries to the console
      // options.LogTo(Console.WriteLine, LogLevel.Information);
      // options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

      // displays parameter values in logs
      options.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Student>()
      .HasMany(s => s.Klasses)
      .WithMany(k => k.Students)
      .UsingEntity<Registration>(
        // the functions below need to be in a specific order
        j => j.HasOne(r => r.Klass).WithMany(k => k.Registrations),
        j => j.HasOne(r => r.Student).WithMany(s => s.Registrations)
      );
    }
  }
}
