using Books.Data;
using Books.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class SeedData
    {
        public static void Seed(AppDbContext context, IServiceProvider provider)
        {
            if(!context.Books.Any())
            {
                var userManager = provider.GetRequiredService<UserManager<AppUserModel>>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

                const string ROLE = "Admin";
                const string PASSWORD = "Password";

                bool isSuccess = true;
                if(roleManager.FindByNameAsync(ROLE).Result == null)
                {
                    isSuccess = roleManager.CreateAsync(new IdentityRole(ROLE)).Result.Succeeded;
                }

                var user1 = new AppUserModel { Name = "Kelsie McDonald", UserName = "Kelsie" };

                isSuccess &= userManager.CreateAsync(user1, PASSWORD).Result.Succeeded;
                if(isSuccess)
                {
                    isSuccess &= userManager.AddToRoleAsync(user1, ROLE).Result.Succeeded;
                }

                if(isSuccess)
                {
                    var book1 = new BookModel
                    {
                        Title = "Court of Thorns and Roses",
                        Author = "Sarah J. Maas",
                        Description = "This book is about Feyre getting to know the Fae world.",

                    };
                }
            }
        }
    }
}