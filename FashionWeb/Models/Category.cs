using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionWeb.Models
{
    [Table("tblCategory")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public bool? IsActive { get; set; }
        public int? MenuOrder { get; set; }
    }
}
