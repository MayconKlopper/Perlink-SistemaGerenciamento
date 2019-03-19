using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

using SistemaGerenciamento.Domain.Entities;
using SistemaGerenciamento.EntityFramework.ResourceFiles;
using SistemaGerenciamento.EntityFramework.Configurations;

namespace SistemaGerenciamento.EntityFramework.Conections
{
    public class Conection : DbContext
    {
        private readonly string connectionString;
        public Conection(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString(Resource.SqlServerLocalConnection);
        }

        public DbSet<Company> Companies { get; private set; }
        public DbSet<Process> Processes { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            optionsBuilder.UseSqlServer(this.connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new Configuration();

            modelBuilder.ApplyConfiguration<Company>(configuration);
            modelBuilder.ApplyConfiguration<Process>(configuration);

            modelBuilder.Entity<Company>().HasData(
                new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro" },
                new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo" }
            );

            modelBuilder.Entity<Process>().HasData(
                new Process() { Id = 1, IdCompany = 1, Active = true, Number = "00001CIVELRJ", State = "Rio de Janeiro", Value = 200000M, CreationDate = new DateTime(2007, 10, 10) },
                new Process() { Id = 2, IdCompany = 1, Active = true, Number = "00002CIVELSP", State = "São Paulo", Value = 100000M, CreationDate = new DateTime(2007, 10, 20) },
                new Process() { Id = 3, IdCompany = 1, Active = false, Number = "00003TRABMG", State = "Minas Gerais", Value = 10000M, CreationDate = new DateTime(2007, 10, 30) },
                new Process() { Id = 4, IdCompany = 1, Active = false, Number = "00004CIVELRJ", State = "Rio de Janeiro", Value = 20000M, CreationDate = new DateTime(2007, 11, 10) },
                new Process() { Id = 5, IdCompany = 1, Active = true, Number = "00005CIVELSP", State = "São Paulo", Value = 35000M, CreationDate = new DateTime(2007, 11, 15) },

                new Process() { Id = 6, IdCompany = 2, Active = true, Number = "00006CIVELRJ", State = "Rio Janeiro", Value = 20000M, CreationDate = new DateTime(2007, 5, 1) },
                new Process() { Id = 7, IdCompany = 2, Active = true, Number = "00007CIVELRJ", State = "Rio de Janeiro", Value = 700000M, CreationDate = new DateTime(2007, 6, 2) },
                new Process() { Id = 8, IdCompany = 2, Active = false, Number = "00008CIVELSP", State = "São Paulo", Value = 500M, CreationDate = new DateTime(2007, 7, 3) },
                new Process() { Id = 9, IdCompany = 2, Active = true, Number = "00009CIVELSP", State = "São Paulo", Value = 32000M, CreationDate = new DateTime(2007, 8, 4) },
                new Process() { Id = 10, IdCompany = 2, Active = false, Number = "00010TRABAM", State = "Amazonas", Value = 1000M, CreationDate = new DateTime(2007, 9, 5) }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
