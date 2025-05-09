using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Data.Enums;
using TechXpress.Data.Models;
using TechXpress.Data.Settings;

namespace TechXpress.Data.Identity
{
    public class DbInitializer
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var config = serviceProvider.GetRequiredService<IOptions<AdminSettings>>();

            var adminConfig = config.Value;

            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                var roleName = role.ToString()!;
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                }
            }

            var existingAdmin = await userManager.FindByEmailAsync(adminConfig.Email);
            if (existingAdmin == null)
            {
                var admin = new AppUser
                {
                    UserName = adminConfig.Email,
                    Email = adminConfig.Email,
                    FirstName = adminConfig.FirstName,
                    LastName = adminConfig.LastName,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, adminConfig.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                }
            }

        }
    }
}

