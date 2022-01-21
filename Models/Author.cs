using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    [Table("Author")]
    public class Author
    {
        [DisplayName("Author ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Author FullName")]
        [MaxLength(49, ErrorMessage = "Author full name cannot be more than 49 Characters")]
        public string FullName { get; set; }

        // Navigation properties
        public List<BookAuthor> BookAuthors { get; set; }
        


    }
}
