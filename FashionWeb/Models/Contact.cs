﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionWeb.Models
{
    [Table("tblContact")]
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string? Name { get; set; }
        public int Phone { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? Email { get; set; }
    }
}
