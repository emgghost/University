using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRTaxApi.Data.Entities;

public class Student : BaseEntity<int>
{
    public string Name { get; set; }

    public string Family { get; set; }

    public string StudentCode { get; set; }

    public int GradeId { get; set; }

    public Grade Grade { get; set; }

    public string FieldOfStudy { get; set; }

    public ICollection<CourceToStudent>? CourceToStudents { get; set; }
}

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.CourceToStudents)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}