using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Infra.Data.Context
{
    public class CentralContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=CentralDeErros;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasMany(u => u.ErrorOccurrences).WithOne(u => u.User).IsRequired();
            modelBuilder.Entity<Situation>().HasMany(s => s.ErrorOccurrences).WithOne(s => s.Situation).IsRequired();
            modelBuilder.Entity<Level>().HasMany(l => l.Errors).WithOne(l => l.Level).IsRequired();
            modelBuilder.Entity<EnvironmentLevel>().HasMany(e => e.Errors).WithOne(e => e.Environment).IsRequired();
            modelBuilder.Entity<Error>().HasKey(e => e.ErrorId);
            modelBuilder.Entity<ErrorOccurrence>().HasKey(e => e.ErrorOccurrenceId);
        }
    }

}
