using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EVF.DAL.DataConnection.EVF;
using EVF.DAL.DataConnection.Identity;
using EVF.DAL.Entity.Identity;
using Microsoft.AspNetCore.Localization;
using evf.Utils;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using Azure.Core;
using System.Net;

namespace evf
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

            //builder.Services.AddIdentity<UserInfo, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
            //builder.Services.AddIdentity<UserInfo, IdentityRole>().AddDefaultTokenProviders();
            builder.Services.AddIdentity<UserInfo, IdentityRole>()
                     .AddEntityFrameworkStores<IdentityContext>()
                     .AddDefaultTokenProviders();



            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddMvc().AddSessionStateTempDataProvider();



            builder.Services.AddDistributedMemoryCache();


            builder.Services.ConfigureApplicationCookie(options =>
            {
                //Cookie settings
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.LoginPath = $"/Account/Connection/Login"; //login page
                options.LogoutPath = $"/Account/Connection/Logout"; //Logout page

                // Redirection lorsqu'un utilisateur tente d'acc�der � une page sans avoir les permissions requises
                options.AccessDeniedPath = $"/Account/Connection/AccessDenied"; // page � afficher en cas d'acc�s refus�


                options.SlidingExpiration = true;
            });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
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

            builder.Services.AddControllersWithViews()
         .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
         .AddDataAnnotationsLocalization();

         

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
               

                options.DefaultRequestCulture = new RequestCulture("en-GB");

                var cultures = new CultureInfo[]
                {
                    new CultureInfo("en-GB"),
                    new CultureInfo("es-ES"),
                    new CultureInfo("fr-FR")
                };

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;

            });
         
            builder.Services.AddScoped<IDisplayPatchNote, DisplayPatchNote>();

            builder.Services.AddLocalization();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Testing"))
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/ForecastEntry/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRequestLocalization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication(); //point d'entr�e d'ASP.NET Identity
            app.UseAuthorization();


            app.MapAreaControllerRoute(name: "areaAccount",
                areaName: "Account",
                pattern: "Account/{controller}/{action}");

            app.MapAreaControllerRoute(name: "areaAdmin",
                areaName: "Admin",
                pattern: "Admin/{controller}/{action}"
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ForecastEntry}/{action=Customers}/{idCustomer?}/{idCommercial?}");
            app.Run();
        }
    }
}