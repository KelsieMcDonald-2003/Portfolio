using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Crochet.Models
{
    public class PatternModel
    {
        [Key]
        public int PatternId { get; set; }
        public AppUserModel Publisher { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public string HookId { get; set; } = string.Empty;
        public HookModel Size { get; set; } = null!;
        public int YarnId { get; set; }
        public YarnModel Brand { get; set; } = null!;
        public YarnModel Color { get; set; } = null!;
        public YarnModel Weight { get; set; } = null!;
        public string Pattern { get; set; } = string.Empty;
    }
}