using lodging.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lodging.Mappings;

public class ReserveMap : IEntityTypeConfiguration<Reserve>
{
    public void Configure(EntityTypeBuilder<Reserve> builder)
    {
        builder.ToTable("Reserves");
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.EntryDate).HasColumnName("entryDate").HasColumnType("datetime").IsRequired();
        builder.Property(prop => prop.DepartureDate).HasColumnName("departureDate").HasColumnType("datetime")
            .IsRequired();
        builder.Property(prop => prop.Identifier).HasColumnName("identifier").HasColumnType("int")
            .IsRequired();
        builder.Property(prop => prop.Childrens).HasColumnName("children").HasColumnType("int")
            .IsRequired();
        builder.Property(prop => prop.Adults).HasColumnName("adult").HasColumnType("int")
            .IsRequired();
        builder.Property(prop => prop.Daily).HasColumnName("daily").HasColumnType("decimal").IsRequired();
        
        builder.Property(prop => prop.Days).HasColumnName("days").HasColumnType("int").IsRequired();
        
        builder.HasOne(prop => prop.Person).WithMany(prop => prop.Reserve).HasForeignKey(prop => prop.ReserveId).OnDelete(DeleteBehavior.ClientSetNull);
        builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
    }
}