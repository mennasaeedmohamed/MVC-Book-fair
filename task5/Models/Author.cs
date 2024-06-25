using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace task5.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }    
        public int Age { get; set; }
        public List<Book> Book { get; set; }
    }
}
