using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRTaxApi.Data.Entities;

public class Cource : BaseEntity<int>
{
    public string Name { get; set; }

    public int Code { get; set; }

    public int Unit { get; set; }

    public int GradeId { get; set; }

    public Grade Grade { get; set; }

    public ICollection<CourceToStudent>? CourceToStudents { get; set; }

}

public class CourceConfiguration : IEntityTypeConfiguration<Cource>
{
    public void Configure(EntityTypeBuilder<Cource> builder)
    {
        builder.HasIndex(x => new{x.Name,x.GradeId}).IsUnique();
        
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.CourceToStudents)
            .WithOne(x => x.Cource)
            .HasForeignKey(x => x.CourceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();
        
        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}