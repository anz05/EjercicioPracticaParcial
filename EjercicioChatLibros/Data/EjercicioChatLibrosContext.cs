using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class EjercicioChatLibrosContext : DbContext
{
    public EjercicioChatLibrosContext(DbContextOptions<EjercicioChatLibrosContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //lo q mapea la tabla
        modelBuilder.Entity<Book>()
            .ToTable("Books")
            .Property(e => e.Id)
            .HasMaxLength(40);
        modelBuilder.Entity<Book>()
            .Property(e => e.Year)
            .HasMaxLength(4);
        modelBuilder.Entity<Book>()
            .Property(e => e.Title)
            .HasMaxLength(100);
        modelBuilder.Entity<Book>()
            .Property(e=>e.Author)
            .HasMaxLength(60);
        modelBuilder.Entity<Book>()
            .Property(e=>e.ISBN)
            .HasMaxLength(13);

        modelBuilder.Entity<Loan>()
            .Property(e => e.Id)
            .HasMaxLength(12);
    }

}
