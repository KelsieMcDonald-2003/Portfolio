using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crochet.Models
{
    public class AppUserModel : IdentityUser
    {
        public string? Name { get; set; } = string.Empty;

        [NotMapped]
        public IList<string>? RoleNames { get; set; }
    }
}