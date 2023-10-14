using lodging.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lodging.Mappings;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons");
        builder.HasKey(prop => prop.Id);


        builder.Property(prop => prop.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
        builder.Property(prop => prop.Cpf).HasColumnName("cpf").HasColumnType("varchar(11)").IsRequired();
        builder.Property(prop => prop.Password).HasColumnName("password").HasColumnType("varchar(200)").IsRequired();
        builder.Property(prop => prop.Email).HasColumnName("email").HasColumnType("varchar(100)").IsRequired();

        builder.HasMany(prop => prop.Reserve)
            .WithOne(prop => prop.Person)
            .HasForeignKey(prop => prop.ReserveId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasMany(prop => prop.Suites)
            .WithOne(prop => prop.Person)
            .HasForeignKey(prop => prop.SuiteId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
    }
}