using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookinist.Infrastructure.DebugServices
{
    public class DebugBooksRepository : IRepository<Book>
    {
        public DebugBooksRepository()
        {
            var books = Enumerable.Range(1, 100)
            .Select(i => new Book
            {
                Id = i,
                Name = $"Книга {i}"
            }).ToArray();

            var categories = Enumerable.Range(1, 10)
                .Select(i => new Category 
                {
                     Id = i,
                     Name = $"Категория {i}"
                }).ToArray();

            foreach (var book in books)
            {
                var category = categories[book.Id % categories.Length];
                category.Books.Add(book);
                book.Category = category;
            }

            Items = books.AsQueryable();
        }
        public IQueryable<Book> Items { get; }

        public Book Add(Book item) 
        {
            throw new NotImplementedException();
        }

        public Task<Book> AddAsync(Book item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
