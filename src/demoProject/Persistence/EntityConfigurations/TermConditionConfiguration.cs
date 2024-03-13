using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TermConditionConfiguration : IEntityTypeConfiguration<TermCondition>
{
    public void Configure(EntityTypeBuilder<TermCondition> builder)
    {
        builder.ToTable("TermConditions").HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id).HasColumnName("Id").IsRequired();
        builder.Property(tc => tc.Header).HasColumnName("Header");
        builder.Property(tc => tc.Text).HasColumnName("Text");
        builder.Property(tc => tc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tc => tc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tc => tc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tc => !tc.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<TermCondition> getSeeds()
    {
        List<TermCondition> termConditions = new() {
        new() {
            Id = 1,
            Header = "Privacy Policy",
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut commodo ipsum non magna aliquam, in suscipit leo finibus. Cras at aliquet enim. Sed feugiat, odio ac venenatis sodales, justo mauris bibendum nulla, vitae pellentesque mi magna ac sem. Duis congue odio at magna viverra, id tempor turpis bibendum. Duis commodo, risus vel laoreet sollicitudin, risus libero tristique odio, ac malesuada sem ligula et turpis. Donec nec massa libero. Cras sollicitudin nisi vel odio rhoncus, nec mattis quam congue.",
  
        },
        new() {
            Id = 2,
            Header = "Terms of Use",
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer quis tristique nisi. Nam nec nisl at lorem fermentum feugiat. Nulla quis molestie sapien, non fermentum mi. Maecenas vitae lorem augue. In vel felis risus. Vestibulum sollicitudin, libero non malesuada commodo, lorem ligula feugiat risus, at posuere urna eros at purus. Vivamus aliquet diam nec pharetra malesuada. Ut id sollicitudin metus. Nam luctus odio et tellus molestie, nec finibus nunc lobortis. Nullam auctor augue a ante vehicula, nec congue justo tempor.",
           
        },
        new() {
            Id = 3,
            Header = "Cookie Policy",
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nec nisi eget purus lacinia vestibulum non ac nulla. Integer ullamcorper, odio eget sagittis tristique, justo felis bibendum libero, et viverra quam libero nec sapien. Suspendisse sed metus nec lacus aliquet fringilla vitae in risus. Fusce id posuere eros. In hac habitasse platea dictumst. Ut id justo a sapien accumsan molestie. Vestibulum nec tincidunt justo, vel commodo nisi. Maecenas quis tristique lorem, sit amet pretium nisl. Cras vehicula faucibus sapien vitae rhoncus. Mauris vel fringilla sapien.",

        } };

        return termConditions.ToArray();
    }

}