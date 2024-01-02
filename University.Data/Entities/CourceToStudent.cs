using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRTaxApi.Data.Entities;

public class CourceToStudent
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    
    public int CourceId { get; set; }
    
    public Cource Cource { get; set; }

    public Student Student { get; set; }
}

public class CourceToStudentConfiguration : IEntityTypeConfiguration<CourceToStudent>
{
    public void Configure(EntityTypeBuilder<CourceToStudent> builder)
    {
        builder.HasKey(x => x.Id);
    }
}