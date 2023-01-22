using Bookinist.DAL.Context;
using Bookinist.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinist.Data
{
    class DbInitializer
    {
        private readonly BookinistDB _db;
        private readonly ILogger<DbInitializer> _Logger;

        public DbInitializer(BookinistDB db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync() {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Иницализация БД...");

            _Logger.LogInformation("Удаление существующей БД...");
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _Logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);

            //_db.Database.EnsureCreated();
            _Logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync();
            _Logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Books.AnyAsync()) return;

            await InitializeCategories();
            await InitializeBooks();
            await InitializeBuyers();
            await InitializeSellers();
            await InitializeDeals();
            _Logger.LogInformation("Инициализация БД выполнена за {0} сек", timer.Elapsed.TotalSeconds);
        }


        private const int __CategoriesCount = 10;
        private Category[] _Categories;
        private async Task InitializeCategories() {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Иницализация категорий...");
            _Categories = new Category[__CategoriesCount];
            for (var i = 0; i < __CategoriesCount; i++)
                _Categories[i] = new Category { Name = $"Категория {i + 1}" };
            await _db.Categories.AddRangeAsync(_Categories);
            await _db.SaveChangesAsync();
            _Logger.LogInformation("Иницализация категорий выполнена за {0} сек", timer.Elapsed.TotalSeconds);
        }

        private const int __BooksCount = 10;
        private Book[] _Books;
        private async Task InitializeBooks()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Иницализация книг...");
            var rnd = new Random();

            _Books = Enumerable.Range(1, __BooksCount)
                .Select(i => new Book { 
                    Name = $"Книга {i}",
                    Category = rnd.NextItem(_Categories)
                })
                .ToArray();
            await _db.Books.AddRangeAsync(_Books);
            await _db.SaveChangesAsync();
            _Logger.LogInformation("Иницализация книг выполнена за {0} сек", timer.Elapsed.TotalSeconds);
        }

        private const int __SellersCount = 10;
        private Seller[] _Sellers;
        private async Task InitializeSellers()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Иницализация продавцов...");
            _Sellers = Enumerable.Range(1, __SellersCount)
                .Select(i => new Seller
                {
                    Name = $"Прдавец-Имя {i}",
                    Surname = $"Прдавец-Фамилия {i}",
                    Patronymic = $"Прдавец-Отчество {i}",
                })
                .ToArray();
            await _db.Sellers.AddRangeAsync(_Sellers);
            await _db.SaveChangesAsync();
            _Logger.LogInformation("Иницализация продавцов выполнена за {0} сек", timer.Elapsed.TotalSeconds);
        }

        private const int __BuyersCount = 10;
        private Buyer[] _Buyers;
        private async Task InitializeBuyers()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Иницализация покупателей...");
            _Buyers = Enumerable.Range(1, __BuyersCount)
                .Select(i => new Buyer
                {
                    Name = $"Покупатель-Имя {i}",
                    Surname = $"Покупатель-Фамилия {i}",
                    Patronymic = $"Покупатель-Отчество {i}",
                })
                .ToArray();
            await _db.Buyers.AddRangeAsync(_Buyers);
            await _db.SaveChangesAsync();
            _Logger.LogInformation("Иницализация покупателей выполнена за {0} сек", timer.Elapsed.TotalSeconds);
        }

        private const int __DealsCount = 1000;
        private Deal[] _Deals;
        private async Task InitializeDeals()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Иницализация сделок...");
            var rnd = new Random();

            var deals = Enumerable.Range(1, __DealsCount)
                .Select(i => new Deal
                {
                    Book = rnd.NextItem(_Books),
                    Seller =rnd.NextItem(_Sellers),
                    Buyer =rnd.NextItem(_Buyers),
                    Price =(decimal)(rnd.NextDouble() * 5000 + 700)
                });
            await _db.AddRangeAsync(deals);
            await _db.SaveChangesAsync();
            _Logger.LogInformation("Иницализация сделок выполнена за {0} сек", timer.Elapsed.TotalSeconds);
        }
    }
}
