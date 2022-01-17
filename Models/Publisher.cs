using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    [Table("Publisher")]
    public class Publisher
    {
        [DisplayName("Publisher ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Publisher Name")]
        [MaxLength(49, ErrorMessage = "Publisher Name cannot be more than 49 Characters")]
        public string Name { get; set; }

        // Navigation properties
        public List<Book> Books { get; set; }
    }
}
