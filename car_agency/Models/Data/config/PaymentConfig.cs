using car_agency.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace car_agency.Models.Data.config
{
	public class PaymentConfig : IEntityTypeConfiguration<Payment>
	{
		public void Configure(EntityTypeBuilder<Payment> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.User)
				.WithMany(x => x.Payments)
				.HasForeignKey(x => x.UserId);
		}
	}
}
