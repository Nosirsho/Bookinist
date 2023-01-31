using Bookinist.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Models
{
    internal class BestSellerInfo
    {
        public Book Book { get; set; }
        public int SellCount { get; set; }
    }
}
