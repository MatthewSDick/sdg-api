using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sdg_api
{
  public partial class DatabaseContext : DbContext
  {

    public DbSet<CheckIn> CheckIns { get; set; }

    public void SaveNewPerson(CheckIn person)
    {
      CheckIns.Add(person);
      SaveChanges();
    }

    public List<CheckIn> GetPeople()
    {
      var allPeople = new List<CheckIn>();
      foreach (var person in CheckIns)
      {
        allPeople.Add(person);
      }
      return allPeople;
    }

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=ExplosionDatabase");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
