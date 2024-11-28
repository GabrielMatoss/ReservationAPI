using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.Entities;

namespace Reservation.Data.Mappings;

public class GuestMappings : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(e => new {e.UserId, e.ReservationId});
        
        builder.Property(e => e.UserId).IsRequired();   
        
        builder.Property(g => g.Name).HasMaxLength(100);
        
        builder.Property(g => g.LastName).HasMaxLength(100);
    }
}