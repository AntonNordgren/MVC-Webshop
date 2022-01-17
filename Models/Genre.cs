using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    [Table("Genre")]
    public class Genre
    {
        [DisplayName("Genre ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Book Type")]
        [MaxLength(49, ErrorMessage = "Book Type cannot be more than 49 Characters")]
        public string Type { get; set; }
        

        // Navigation properties
        public List<Book> Books { get; set; }
       
    }
}
