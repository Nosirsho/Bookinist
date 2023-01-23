using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace Bookinist.ViewModels
{
    class BuyersViewModel : ViewModel
    {
        private IRepository<Buyer> _BuyersRepository;

        public BuyersViewModel(IRepository<Buyer> BuyersRepository)
        {
            _BuyersRepository = BuyersRepository;
        }
    }
}
