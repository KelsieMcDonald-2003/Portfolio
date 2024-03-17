using Microsoft.AspNetCore.Identity;
using Crochet.Data;
using Crochet.Models;
using System.Threading.Tasks;

namespace Crochet
{
    public class SeedData
    {
        public static async Task SeedAsync(AppDbContext context, IServiceProvider provider)
        {
            if (!context.Patterns.Any())
            {
                var userManager = provider.GetRequiredService<UserManager<AppUserModel>>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

                const string ROLE = "Admin";
                const string PASSWORD = "Secret123!";

                bool isSuccess = true;
                if (await roleManager.FindByNameAsync(ROLE) == null)
                {
                    isSuccess = (await roleManager.CreateAsync(new IdentityRole(ROLE))).Succeeded;
                }

                var user1 = new AppUserModel { Name = "Kelsie McDonald", UserName = "Kelsie" };
                var result = await userManager.CreateAsync(user1, PASSWORD);

                isSuccess &= result.Succeeded;
                if (isSuccess)
                    isSuccess &= (await userManager.AddToRoleAsync(user1, ROLE)).Succeeded;
                if (isSuccess)
                    await context.SaveChangesAsync();
            }
        }
    }
}
