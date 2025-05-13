using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Master.Core.Identity;

namespace Master.Repository.Seeding
{
    public static class SeedRolesAndAdmin
    {
        public static async Task Initialize(IServiceProvider services, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // 1. إنشاء الأدوار (Roles) إذا لم تكن موجودة
            var roleNames = new[] { "Admin", "User" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // 2. التأكد من وجود مستخدم أدمن (Admin) محدد
            string adminEmail = "admin@gmail.com"; // نفس الإيميل هنا وهناك
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Type=  "Admin"
                };

                var result = await userManager.CreateAsync(user, "A3!b7X$yN9#kQz"); // تأكد أنها قوية ومتوافقة مع السياسات

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    // طباعة الأخطاء للتشخيص
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
            }
        }
    }
}
