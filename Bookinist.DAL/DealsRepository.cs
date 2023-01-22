using Bookinist.DAL.Context;
using Bookinist.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bookinist.DAL
{
    class DealsRepository : DbRepository<Deal>
    {
        public override IQueryable<Deal> Items => base.Items
            .Include(item => item.Book)
            .Include(item => item.Seller)
            .Include(item => item.Buyer)
        ;
        public DealsRepository(BookinistDB db) : base(db) { }
    }
}
