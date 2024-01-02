using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRTaxApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRTaxApi.Data.Contexts
{
    public class IRTaxApiDbContext : DbContext
    {
        public IRTaxApiDbContext(DbContextOptions<IRTaxApiDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cource> Cources { get; set; }

        public DbSet<CourceToStudent> CourceToStudents { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
