using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.EntityFramework.Configurations
{
    public class Configuration : IEntityTypeConfiguration<Company>,
        IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.ToTable("Process");

            builder.HasKey(process => process.Id)
                   .HasName("PK_Process");

            builder.Property(process => process.Active)
                   .IsRequired();

            builder.Property(process => process.Number)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(process => process.State)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(process => process.Value)
                   .IsRequired();

            builder.Property(process => process.CreationDate)
                   .IsRequired();

            #region RelationShip

            builder.HasOne(process => process.Company)
                   .WithMany(company => company.Processes)
                   .HasForeignKey(process => process.IdCompany)
                   .HasConstraintName("FK_Company_Process")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(company => company.Id)
                   .HasName("PK_Company");

            builder.Property(company => company.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(company => company.CNPJ)
                   .HasMaxLength(14)
                   .IsRequired();

            builder.Property(company => company.State)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
