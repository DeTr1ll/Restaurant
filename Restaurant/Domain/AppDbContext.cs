using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TextField> TextFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Создаем роль админа
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a9f9de6f-ef3c-4d4c-a42b-79e0594675cb",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "513b9ca1-d72c-4bbb-90dd-d9fdb81dd051",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email="TrubnikovID@krok.edu.ua",
                NormalizedEmail = "TRUBNIKOVID@KROK.EDU.UA",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "1q2w3e123"),
                SecurityStamp = string.Empty
            });
            
            //Создаем роль менеджера
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "a9f9de6f-ef3c-4d4c-a42b-79e0594675cb",
                UserId = "513b9ca1-d72c-4bbb-90dd-d9fdb81dd051"
            });


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ded0f509-8e65-4bfb-b4c5-4b7d49e3f1b9",
                Name = "manager",
                NormalizedName = "MANAGER"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "74ed5f78-6593-4305-a024-743779f0fd56",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "TrubnikovID@krok.edu.ua",
                NormalizedEmail = "TRUBNIKOVID@KROK.EDU.UA",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "1q2w3e123"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ded0f509-8e65-4bfb-b4c5-4b7d49e3f1b9",
                UserId = "74ed5f78-6593-4305-a024-743779f0fd56"
            });

        }
    }
}
