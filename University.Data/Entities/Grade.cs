using IRTaxApi.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRTaxApi.Data.Entities;

public class Grade : BaseEntity<int>
{
    public string Name { get; set; }

    public ICollection<Student>? Students { get; set; }

    public ICollection<Cource>? Cources { get; set; }
}

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasKey(x => x.Id);
        
        builder.HasMany(x=>x.Cources)
            .WithOne(x=>x.Grade)
            .HasForeignKey(x=>x.GradeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();
        
        builder.HasMany(x=>x.Students)
            .WithOne(x=>x.Grade)
            .HasForeignKey(x=>x.GradeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();
        
        builder.HasQueryFilter(x=>x.IsDeleted == false);
        
        builder.HasData(Enum.GetValues<GradeEnum>().Select( x => new Grade { Id = (int)x, Name = x.ToString() }).ToList());
    }
}