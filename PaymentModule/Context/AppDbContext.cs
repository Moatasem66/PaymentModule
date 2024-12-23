using Microsoft.EntityFrameworkCore;
using PaymentModule.Entities;
using System;
using System.Reflection;

namespace PaymentModule.Context;
/// <summary>
/// Class DBContext the session between Code and Database 
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
  
    public DbSet<Invoice> Invoices { get; set; }
    /// <summary>
    /// override OnModelCreating to apply my configuration for entities .
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
