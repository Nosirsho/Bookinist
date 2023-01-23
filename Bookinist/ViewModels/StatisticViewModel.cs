using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace Bookinist.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        private IRepository<Book> _BooksRepository;
        private IRepository<Buyer> _BuyersRepository;
        private IRepository<Seller> _SellersRepository;

        public StatisticViewModel(IRepository<Book> BooksRepository, IRepository<Buyer> BuyersRepository, IRepository<Seller> SellersRepository)
        {
            _BooksRepository = BooksRepository;
            _BuyersRepository = BuyersRepository;
            _SellersRepository = SellersRepository;
        }
    }
}
