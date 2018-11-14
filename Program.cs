using AutoMapper;
using System;

namespace ConsoleApp8Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Mapper.Initialize(cfg => {
                cfg.CreateMap<string, string>().ConvertUsing(s => s ?? string.Empty);
                cfg.CreateMap<long, DateTime>().ConvertUsing(s => new DateTime(s));
                cfg.CreateMap<Book, BookDto>();
            });

            var book1 = new Book
            {
                Id = 1,
                Date = DateTime.Now.Ticks
            };
            var book2 = book1.MapTo<BookDto>();

            Console.WriteLine($" Book1: Id:{book1.Id} Title:{book1.Title} Title Null?{book1.Title == null} Date:{new DateTime(book1.Date)}");
            Console.WriteLine($" Book2: Id:{book2.Id} Title:{book2.Title} Title Null?{book2.Title==null} Date:{book2.Date}");

            var ab1 = new AB() { Id = 1 };
            var ab2 = ab1.MapTo<AB2>();

            Console.WriteLine($" Ab1: Id:{ab1.Id}");
            Console.WriteLine($" Ab2: Id:{ab2.Id}");

            //不对了 InitMaps > item.CustomMapper == null  自定义设置丢失
            book2 = book1.MapTo<BookDto>();
            Console.WriteLine($" Book1: Id:{book1.Id} Title:{book1.Title} Title Null?{book1.Title == null} Date:{new DateTime(book1.Date)}");
            Console.WriteLine($" Book2: Id:{book2.Id} Title:{book2.Title} Title Null?{book2.Title == null} Date:{book2.Date}");

            Console.Read();
        }
    }

    public class Book
    {
        public int Id { set; get; }
        public string Title { set; get; }

        public long Date { set; get; }
    }

    public class BookDto
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public DateTime Date { set; get; }
    }

    public class AB
    {
        public int Id { set; get; }
    }

    public class AB2
    {
        public int Id { set; get; }
    }
}
