using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductQuestionConfiguration : IEntityTypeConfiguration<ProductQuestion>
{
    public void Configure(EntityTypeBuilder<ProductQuestion> builder)
    {
        builder.ToTable("ProductQuestions").HasKey(pq => pq.Id);

        builder.Property(pq => pq.Id).HasColumnName("Id").IsRequired();
        builder.Property(pq => pq.ProductId).HasColumnName("ProductId");
        builder.Property(pq => pq.CustomerId).HasColumnName("CustomerId");
        builder.Property(pq => pq.SellerId).HasColumnName("SellerId");
        builder.Property(pq => pq.Question).HasColumnName("Question");
        builder.Property(pq => pq.Answer).HasColumnName("Answer");
        builder.Property(pq => pq.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pq => pq.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pq => pq.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pq => !pq.DeletedDate.HasValue);
    }
}