using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class GenreModel
    {
        [Key]
        public string GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
