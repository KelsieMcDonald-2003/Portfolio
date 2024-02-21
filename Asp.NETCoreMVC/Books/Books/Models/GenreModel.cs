using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class GenreModel
    {
        [Key]
        public string GenreId { get; set; } = string.Empty;
        public string GenreName { get; set; } = string.Empty;
    }
}
