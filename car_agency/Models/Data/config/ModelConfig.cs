using car_agency.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace car_agency.Models.Data.config
{
	public class ModelConfig : IEntityTypeConfiguration<Model>
	{
		public void Configure(EntityTypeBuilder<Model> builder)
		{
			builder.HasKey(x => x.ModelId);
			builder.HasOne(x => x.CarBrand)
				.WithMany(x => x.Models)
				.HasForeignKey(x => x.BrandId);

				
		}

	}
}
