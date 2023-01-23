using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookinist.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        private IRepository<Book> _BooksRepository;
        private IRepository<Buyer> _BuyersRepository;
        private IRepository<Seller> _SellersRepository;
        private IRepository<Deal> _DealsRepository;

        /*==========================================================================*/
        /*--------------------------------------------------------------------------*/
        #region BooksCount : int - Количество книг
        /// <summary>Количество книг</summary>
        private int _BooksCount;

        /// <summary>Количество книг</summary>
        public int BooksCount { get => _BooksCount; private set => Set(ref _BooksCount, value); }
        #endregion

        /*==========================================================================*/
        /*--------------------------------------------------------------------------*/
        #region Command ComputeStatisticCommand - Вычислить статические данные
        /// <summary>Вычислить статические данные</summary>
        private ICommand _ComputeStatisticCommand;

        /// <summary>Вычислить статические данные</summary>
        public ICommand ComputeStatisticCommand => _ComputeStatisticCommand
            ??= new LambdaCommandAsync(OnComputeStatisticCommandExecuted, CanComputeStatisticCommandExecute);

        /// <summary>Проверка возможности выполнения - Вычислить статические данные</summary>
        private bool CanComputeStatisticCommandExecute() => true;

        /// <summary>Логика выполнения - Вычислить статические данные</summary>
        private async Task OnComputeStatisticCommandExecuted()
        {
            BooksCount = await _BooksRepository.Items.CountAsync();
            /*var deals = _DealsRepository.Items;
            var bestsellers = await deals.GroupBy(d => d.Book)
                .Select(book_deals => new { Book = book_deals.Key, Count = book_deals.Count() })
                .OrderByDescending(book => book.Count)
                .Take(7)
                .ToArrayAsync();*/
        }
        #endregion
        /*--------------------------------------------------------------------------*/

        public StatisticViewModel(IRepository<Book> BooksRepository, IRepository<Buyer> BuyersRepository, IRepository<Seller> SellersRepository, IRepository<Deal> DealsRepository)
        {
            _BooksRepository = BooksRepository;
            _BuyersRepository = BuyersRepository;
            _SellersRepository = SellersRepository;
            _DealsRepository = DealsRepository;
        }
    }
}
