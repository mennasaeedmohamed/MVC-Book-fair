using System.ComponentModel.DataAnnotations;

namespace task5.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)] 
        public string Type { get; set; }
        public Author Author { get; set; }
    }
}
