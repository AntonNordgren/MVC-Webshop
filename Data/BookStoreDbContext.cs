using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Webshop.Models
{
    // inheriting from Identity.EntityFrameworkCore
    public class BookStoreDbContext :IdentityDbContext<IdentityUser>
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


        }

    }
}
