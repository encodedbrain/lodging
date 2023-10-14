using lodging.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lodging.Mappings;

public class SuiteMap : IEntityTypeConfiguration<Suite>
{
    public void Configure(EntityTypeBuilder<Suite> builder)
    {
        builder.ToTable("Suites");
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Rooms).HasColumnName("rooms").HasColumnType("int").IsRequired();
        builder.Property(prop => prop.TypeSuite).HasColumnName("typesuite").HasColumnType("varchar(20)").IsRequired();
        builder.Property(prop => prop.Identifier).HasColumnName("identifier").HasColumnType("int")
            .IsRequired();
        builder.HasOne(prop => prop.Person).WithMany(prop => prop.Suites).HasForeignKey(prop => prop.SuiteId).OnDelete(DeleteBehavior.ClientSetNull);

        builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
    }
}