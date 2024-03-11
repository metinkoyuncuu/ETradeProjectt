using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ReviewFeedbackConfiguration : IEntityTypeConfiguration<ReviewFeedback>
{
    public void Configure(EntityTypeBuilder<ReviewFeedback> builder)
    {
        builder.ToTable("ReviewFeedbacks").HasKey(rf => rf.Id);

        builder.Property(rf => rf.Id).HasColumnName("Id").IsRequired();
        builder.Property(rf => rf.ProductReviewId).HasColumnName("ProductReviewId");
        builder.Property(rf => rf.CustomerId).HasColumnName("CustomerId");
        builder.Property(rf => rf.Feedback).HasColumnName("Feedback");
        builder.Property(rf => rf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rf => rf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rf => rf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rf => !rf.DeletedDate.HasValue);
    }
}