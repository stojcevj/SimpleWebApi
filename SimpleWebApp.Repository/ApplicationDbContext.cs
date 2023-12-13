using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApp.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .Property(s => s.CountryId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contact>()
                .Property(s => s.ContactId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Company>()
                .Property(s => s.CompanyId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Company>()
                .HasMany(s => s.Contacts)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyId)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .HasMany(s => s.Contacts)
                .WithOne(s => s.Country)
                .HasForeignKey(s => s.CountryId)
                .IsRequired();
        }

    }
}
