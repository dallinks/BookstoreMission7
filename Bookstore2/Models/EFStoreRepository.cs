using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore2.Models;

namespace Bookstore2.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private BookstoreContext context;
        public EFStoreRepository(BookstoreContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Book> Books => context.Books;

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }
    }
}

