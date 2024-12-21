using car_agency.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace car_agency.Models.Data.config
{
	public class CarBrandConfig : IEntityTypeConfiguration<CarBrand>
	{
		public void Configure(EntityTypeBuilder<CarBrand> builder)
		{
			builder.HasKey(x => x.BrandId);
			
		}

	}
}
