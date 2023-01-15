using System.ComponentModel.DataAnnotations;

namespace Bookman.Model
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int  Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Author { get; set; }
    }
}
