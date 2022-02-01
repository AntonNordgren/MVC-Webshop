using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MVC_Webshop.Models;

namespace MVC_Webshop.Data
{
    public class BookStoreDbInitializer
    {
        
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
          
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<BookStoreDbContext>();
            context.Database.EnsureCreated();
            if (!context.Genres.Any())//add genres if they do not exist
            {
                context.Genres.AddRange(new List<Genre>()
                    {
                        new Genre { Type = "Kids" },
                        new Genre { Type = "Food" },
                        new Genre { Type = "Detective" },
                        new Genre { Type = "Biography" },
                        new Genre { Type = "School Literature" }

                    });

            }
            if (!context.Publishers.Any()) //add publishers if they do not exist
            {
                context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher { Name = "SE" },
                        new Publisher { Name = "NOSE" }
                    });
                context.SaveChanges();
            }
            if (!context.Authors.Any()) //add books if they do not exist
            {
                context.Authors.AddRange(new List<Author>()
                    {
                        new Author { FullName = "Dawn Machell" },
                        new Author { FullName = "Marie Helleday Ekwurtze" },
                        new Author { FullName = "Erik Larsson" },
                        new Author { FullName = "Carl Hedin"},
                        new Author { FullName = "Holly Jackson"},
                        new Author { FullName = "John Le Carre"},
                        new Author { FullName = "Jenny Wallden"},
                        new Author { FullName = "Helen Carlander"}
                    });
                context.SaveChanges();
            }

            if (!context.Books.Any()) //add books if they do not exist
            {
                context.Books.AddRange(new List<Book>()
                    {
                        new Book {
                            Title="Älskade nalle : saga med gosiga flärpar",
                            Isbn="9789179851521",
                            Description="En genial liten bok som kommer att älskas av alla små barn som inte kan låta bli att pilla med tvättråden på sina snuttefiltar!",
                            TotalPage=50,
                            PublisherDate=new DateTime(2020,09,11),
                            Language="Svenska",
                            ImageUrl="https://s2.adlibris.com/images/57878676/alskade-nalle-saga-med-gosiga-flarpar.jpg",
                            UnitPrice=69,
                            Quantity=40,
                            PublisherId=1,
                            GenreId=1
                        },
                        new Book {
                            Title="Min lilla pekbok : första 100 orden",
                            Isbn="9789177831488",
                            Description="Tjocka böcker med vadderade omslag, fina fotografier och massor av färger.",
                            TotalPage=40,
                            PublisherDate=new DateTime(2020,10,20),
                            Language="Svenska",
                            ImageUrl="https://s1.adlibris.com/images/35377774/min-lilla-pekbok-forsta-100-orden.jpg",
                            UnitPrice=120,
                            Quantity=35,
                            PublisherId=1,
                            GenreId=1
                        },
                        new Book {
                            Title="A Good Girl's Guide to Murder ",
                            Isbn="9781405293181",
                            Description="The New York Times No.1 bestselling YA crime thriller that everyone is talking about!",
                            TotalPage=90,
                            PublisherDate=new DateTime(2019,06,20),
                            Language="Engelska",
                            ImageUrl="https://s2.adlibris.com/images/47523192/a-good-girls-guide-to-murder.jpg",
                            UnitPrice=90,
                            Quantity=16,
                            PublisherId=2,
                            GenreId=3
                        },
                        new Book {
                            Title="Wok, ris, nudlar",
                            Isbn="9789178870417",
                            Description="I denna bok finns asiatiska favoriter som vardagsbibimbap och teriyakikyckling men du får också lära dig att göra egna handdragna nudlar och hur du gör kimchi på bästa sätt. ",
                            TotalPage=164,
                            PublisherDate=new DateTime(2020,09,20),
                            Language="Svenska",
                            ImageUrl="https://s1.adlibris.com/images/57918624/wok-ris-nudlar.jpg",
                            UnitPrice=130,
                            Quantity=14,
                            PublisherId=1,
                            GenreId=2
                        },
                    });
                context.SaveChanges();

            }
            if (!context.BookAuthors.Any())//add many to many connection between author and book
            {
                context.BookAuthors.AddRange(new List<BookAuthor>()
                    {
                        new BookAuthor {
                            AuthorId=1,BookId=1
                        },
                        new BookAuthor {
                            AuthorId=2,BookId=2
                        },
                        new BookAuthor {
                            AuthorId=5,BookId=3
                        },
                        new BookAuthor {
                            AuthorId=7,BookId=4
                        }
                    });
                context.SaveChanges();
            }

            if (!context.Orders.Any()) //add example orders if there are none
            {
                context.Orders.AddRange(new List<Order>()
                    {
                        new Order {
                            OrderDate= new DateTime(2022,01,02),
                            TotalCost=0,
                            OrderStatus="Shipped",
                            Notes="test order shipped",
                            UserId=context.Users.First(a=>a.Email=="user2@bookstore.com").Id
                        },
                        new Order {
                            OrderDate= new DateTime(2022,01,12),
                            TotalCost=0,
                            OrderStatus="Not Shipped",
                            Notes="test order not shipped",
                            UserId=context.Users.First(a=>a.Email=="user2@bookstore.com").Id
                        },
                        new Order {
                            OrderDate= new DateTime(2022,01,12),
                            TotalCost=0,
                            OrderStatus="Canceled",
                            Notes="test order canceled",
                            UserId=context.Users.First(a=>a.Email=="user3@bookstore.com").Id
                        },
                        new Order {
                            OrderDate= new DateTime(2022,01,13),
                            TotalCost=0,
                            OrderStatus="Not Shipped",
                            Notes="test order h1",
                            UserId=context.Users.First(a=>a.Email=="user3@bookstore.com").Id
                        }
                    }) ;
                context.SaveChanges();
            }
            if (!context.OrderItems.Any()) //add example orderitems
            {
                context.OrderItems.AddRange(new List<OrderItem>()
                    {
                        new OrderItem
                        {

                            Quantity=2,
                            UnitPrice=context.Books.First(a=>a.Id==1).UnitPrice,
                            Discount=0,
                            BookId=1,
                            OrderId=1

                        },
                        new OrderItem
                        {

                            Quantity=1,
                            UnitPrice=context.Books.First(a=>a.Id==2).UnitPrice,
                            Discount=0,
                            BookId=2,
                            OrderId=1

                        },
                        new OrderItem
                        {

                            Quantity=1,
                            UnitPrice=context.Books.First(a=>a.Id==3).UnitPrice,
                            Discount=0,
                            BookId=3,
                            OrderId=2

                        },
                        new OrderItem
                        {

                            Quantity=3,
                            UnitPrice=context.Books.First(a=>a.Id==2).UnitPrice,
                            Discount=0,
                            BookId=2,
                            OrderId=3

                        },
                        new OrderItem
                        {

                            Quantity=2,
                            UnitPrice=context.Books.First(a=>a.Id==4).UnitPrice,
                            Discount=0,
                            BookId=2,
                            OrderId=4

                        },
                    });
                context.SaveChanges();
            }
        }
    }
}
