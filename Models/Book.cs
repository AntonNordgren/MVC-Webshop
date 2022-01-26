using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "ISBN must be 13 Characters")]
        public string Isbn { get; set; }

        [Required]
        [StringLength(99, ErrorMessage = "Book title cannot be more than 99 Characthers")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Book description cannot be more than 1000 Characthers")]
        public string Description { get; set; }

        [Required]
        public int TotalPage { get; set; }
        

        [Required]
        public DateTime PublisherDate { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Book Language cannot be more than 25 Characthers")]
        public string Language { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }



        // Navigation properties

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        // book and product item needed
    }
}
