using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProducerService.Data.Entities;

namespace ProducerService.Data.EntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public const string TableName = "tbl_product";
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
