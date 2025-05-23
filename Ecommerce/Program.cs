using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repositories;
using Ecommerce.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Uitilites;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace Ecommerce
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options=>
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(2))
                .AddDefaultTokenProviders().AddDefaultUI().
                AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.Configure<StripeUtilite>(builder.Configuration.GetSection("stripe"));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            StripeConfiguration.ApiKey = builder.Configuration.GetSection("stripe:SecretKey").Get<string>();

            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "Customer",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
