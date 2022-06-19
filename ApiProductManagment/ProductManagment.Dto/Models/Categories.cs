using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagment.Dto.Models
{
    public class Categories
    {
        [Key]
        [Column("idCategory")]
        [StringLength(50)]
        public Guid IdCategory { get; set; }
        public string? Name { get; set; }

        public ICollection<CategoryXProducts>? CategoriesXproducts { get; set; }
    }
}
