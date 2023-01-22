using Bookinist.DAL.Context;
using Bookinist.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bookinist.DAL
{
    class BooksRepository : DbRepository<Book>
    {
        public override IQueryable<Book> Items => base.Items.Include(item => item.Category);
        public BooksRepository(BookinistDB db) : base(db){}
    }
}
