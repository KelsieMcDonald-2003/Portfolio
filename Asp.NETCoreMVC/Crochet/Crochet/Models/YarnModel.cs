using System.ComponentModel.DataAnnotations;

namespace Crochet.Models
{
    public class YarnModel
    {
        [Key]
        public int YarnId { get; set; }
        public string YarnBrand { get; set; } = string.Empty;
        public string YarnColor { get; set; } = string.Empty;
        public string YarnWeight { get; set; } = string.Empty;
    }
}
