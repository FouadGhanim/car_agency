using car_agency.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace car_agency.Models.Data.config
{
	public class CarConfig : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.HasKey(x => x.CarId);
			builder.HasOne(x => x.User)
				.WithMany(x => x.Cars)
				.HasForeignKey(x => x.UserId);

			builder.HasOne(x => x.CarBrand)
				.WithMany(x => x.Cars)
				.HasForeignKey(x => x.BrandId);

			builder.HasOne(x => x.Model)
				.WithMany(x => x.Cars)
				.HasForeignKey(x => x.ModelId);


		}
	}
}
