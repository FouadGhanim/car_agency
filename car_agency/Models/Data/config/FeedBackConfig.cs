using car_agency.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace car_agency.Models.Data.config
{
	public class FeedBackConfig : IEntityTypeConfiguration<Feedback>
	{
		public void Configure(EntityTypeBuilder<Feedback> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.User)
				.WithMany(x => x.Feedbacks)
				.HasForeignKey(x => x.UserId);
		}
	}
}
