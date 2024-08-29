using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionWeb.Models
{
    [Table("tblColor")]
    public class Color
    {
        [Key]
        public int ColorID { get; set; }
        [StringLength(30)]
        public string? ColorName { get; set; }
    }
}
