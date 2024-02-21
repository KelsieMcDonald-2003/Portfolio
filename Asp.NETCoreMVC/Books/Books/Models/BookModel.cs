using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Books.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int? PubYear { get; set; }
        public int? Rating { get; set; }
        public string GenreId { get; set; }
        public GenreModel Genre { get; set; }
        public string Slug => Title?.Replace(' ', '-').ToLower() + PubYear?.ToString();
    }
}