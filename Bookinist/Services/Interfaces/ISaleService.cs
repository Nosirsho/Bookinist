using Bookinist.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Services.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<Deal> Deals { get; }

        Task<Deal> MakeDeal(string BookName, Seller Seller, Buyer Buyer, decimal Price);
    }
}
