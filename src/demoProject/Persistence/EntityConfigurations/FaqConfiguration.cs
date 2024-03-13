using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
    public void Configure(EntityTypeBuilder<Faq> builder)
    {
        builder.ToTable("Faqs").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.Question).HasColumnName("Question");
        builder.Property(f => f.Answer).HasColumnName("Answer");
        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(f => !f.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<Faq> getSeeds()
    {
        List<Faq> faqs = new() {
        new() { Id = 1, Question = "How can I reset my password?", Answer = "You can reset your password by clicking on the 'Forgot Password' link on the login page." },
        new() { Id = 2, Question = "What payment methods do you accept?", Answer = "We accept credit/debit cards, PayPal, and bank transfers." },
        new() { Id = 3, Question = "How long does shipping take?", Answer = "Shipping usually takes 3-5 business days, depending on your location." },
        new() { Id = 4, Question = "Do you offer refunds?", Answer = "Yes, we offer refunds within 30 days of purchase. Please refer to our refund policy for more details." },
        new() { Id = 5, Question = "Can I change my delivery address?", Answer = "Yes, you can change your delivery address before your order is shipped. Please contact our customer support team for assistance." },
        new() { Id = 6, Question = "Is there a warranty on your products?", Answer = "Yes, all our products come with a one-year warranty against manufacturing defects." }
    };

        return faqs.ToArray();
    }

}