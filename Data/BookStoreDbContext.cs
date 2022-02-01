using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Data
{
    // inheriting from Identity.EntityFrameworkCore
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<CartItem> CartItems { get; set; }


        // using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // used to resolve the error while add migration after using IdentityDbContext
            //error "The entity type IdentityUserLogin of string require a primary key to be defined"
            base.OnModelCreating(modelBuilder);

            //configure the field lengths of ApplicationUser
            modelBuilder.Entity<ApplicationUser>()
            .Property(e => e.FirstName)
            .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.LastName)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Address)
                .HasMaxLength(250);
            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.PostalNumber)
                .HasMaxLength(250);
            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.City)
                .HasMaxLength(250);
            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Country)
                .HasMaxLength(250);



            // BookAuthor relationsship
            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(bi => bi.AuthorId);

            // OrderItem relationsship
            modelBuilder.Entity<OrderItem>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.OrderItems)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(b => b.Order)
                .WithMany(ba => ba.OrderItems)
                .HasForeignKey(bi => bi.OrderId);

            /// seeding Admin rol and an account 
            /// 
            
            string userId = Guid.NewGuid().ToString();
            string AdminroleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId2 = Guid.NewGuid().ToString();
            string userId3 = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = AdminroleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                

            });
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null,"admin")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = AdminroleId

            });



            /// user role
            /// 


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER",

            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId2,
                Email = "user2@bookstore.com",
                NormalizedEmail = "USER2@BOOKSTORE.COM",
                UserName = "user2@bookstore.com",
                NormalizedUserName = "USER2@BOOKSTORE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "user2")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userId2,
                RoleId = userRoleId

            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId3,
                Email = "user3@bookstore.com",
                NormalizedEmail = "USER3@BOOKSTORE.COM",
                UserName = "user3@bookstore.com",
                NormalizedUserName = "USER3@BOOKSTORE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "user3")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userId3,
                RoleId = userRoleId

            });

        }

    }
}
