using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EVF.DAL.DataConnection.EVF;
using EVF.DAL.DataConnection.Identity;
using EVF.DAL.Entity.Identity;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using Azure.Core;
using System.Net;


namespace EVF.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<EVFContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<UserInfo, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();


            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddMvc().AddSessionStateTempDataProvider();



            builder.Services.AddDistributedMemoryCache();


            builder.Services.ConfigureApplicationCookie(options =>
            {
                //Cookie settings
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.LoginPath = $"/Account/Connection/Login"; //login page
                options.LogoutPath = $"/Account/Connection/Logout";

                options.SlidingExpiration = true;
            });



            builder.Services.Configure<IdentityOptions>(options =>
            {


                // Password settings.
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 4;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;

                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = false;
                

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

            });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
           
            });

         

            builder.Services.AddControllersWithViews()
         .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
         .AddDataAnnotationsLocalization();


            builder.Services.AddSession();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseRequestLocalization();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication(); //point d'entrée d'ASP.NET Identity
            app.UseAuthorization();


            app.MapAreaControllerRoute(name: "areaAccount",
                areaName: "Account",
                pattern: "Account/{controller}/{action}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Evf}/{action=Index}/{id?}");
            //pattern: "{controller=ForecastEntry}/{action=Index}/{idCustomer?}/{idCommercial?}");

            app.Run();
        }
    }
}