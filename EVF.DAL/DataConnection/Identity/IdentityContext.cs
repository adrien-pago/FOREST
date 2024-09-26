using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EVF.DAL.Entity.Identity;

namespace EVF.DAL.DataConnection.Identity
{
    public class IdentityContext : IdentityDbContext<UserInfo>
    {
        //private readonly string moniGUID = Guid.NewGuid().ToString();
        //private readonly string ariGUID = Guid.NewGuid().ToString();
        //private readonly string fabGUID = Guid.NewGuid().ToString();
        private readonly string adminGUID = Guid.NewGuid().ToString();

        public DbSet<Parametrage> Parametrage { get; set; }

        public IdentityContext (DbContextOptions<IdentityContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInfo>().Navigation(u => u.PersonnelNav).AutoInclude(); //****
            modelBuilder.Entity<UserInfo>().Navigation(u => u.ParametrageNav).AutoInclude(); //****

            modelBuilder.Entity<Parametrage>().Property(p => p.FormatDate).HasDefaultValue("yyyy/MM/dd");
            modelBuilder.Entity<Parametrage>().Property(p => p.DecimalFormat).HasDefaultValue("en-US");
            modelBuilder.Entity<Parametrage>().Property(p => p.SaveType).HasDefaultValue("Individual");

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Commercial", NormalizedName = "CO" },
                new IdentityRole() { Id = "2", Name = "AssistantCommercial", NormalizedName = "AC" },
                new IdentityRole() { Id = "3", Name = "Administrateur", NormalizedName = "ADM" }
                );

            modelBuilder.Entity<UserInfo>().HasData(

                        new UserInfo()
                        {
                            Id = adminGUID,
                            UserName = "EAVF$2",
                            NormalizedUserName = "EAVF$2".ToUpper(),
                            PasswordHash = new PasswordHasher<UserInfo>().HashPassword(null, "2@e4*f"),
                        }


                ); 

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                     new IdentityUserRole<string>()
                     {
                         UserId = adminGUID,
                         RoleId = "3"
                     }
                  );

        }


    }
}
