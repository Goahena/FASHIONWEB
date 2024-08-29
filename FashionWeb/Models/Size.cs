using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionWeb.Models
{
    [Table("tblSize")]
    public class Size
    {
        [Key]
        public int SizeID { get; set; }
        public string? SizeName { get; set; }
    }
}
