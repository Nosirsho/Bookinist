using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using Bookinist.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Services
{
    class SaleService : ISaleService
    {
        private readonly IRepository<Book> _Books;
        private readonly IRepository<Deal> _Deals;

        public IEnumerable<Deal> Deals => _Deals.Items;

        public SaleService(IRepository<Book> Books, IRepository<Deal> Deals)
        {
            _Books = Books;
            _Deals = Deals;
        }

        public async Task<Deal> MakeDeal(string BookName, Seller Seller, Buyer Buyer, decimal Price) 
        {
            var book = await _Books.Items
                .FirstOrDefaultAsync(b => b.Name == BookName)
                .ConfigureAwait(false);
            
            if (book is null) return null;

            var deal = new Deal {
                Book = book,
                Seller = Seller,
                Buyer = Buyer,
                Price = Price
            };

            return await _Deals.AddAsync(deal);
        }
    }
}
