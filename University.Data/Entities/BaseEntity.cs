using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRTaxApi.Data.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } =DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
