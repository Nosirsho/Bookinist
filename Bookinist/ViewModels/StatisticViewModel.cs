using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using Bookinist.Models;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
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

        public ObservableCollection<BestSellerInfo> Bestsellers { get; set; } = new ObservableCollection<BestSellerInfo>();

        /*==========================================================================*/
        /*--------------------------------------------------------------------------*/
        

        /*==========================================================================*/
        /*--------------------------------------------------------------------------*/
        #region Command ComputeStatisticCommand - Вычислить статические данные
        /// <summary>Вычислить статические данные</summary>
        private ICommand _ComputeStatisticCommand;

        /// <summary>Вычислить статические данные</summary>
        public ICommand ComputeStatisticCommand => _ComputeStatisticCommand
            ??= new LambdaCommandAsync(OnComputeStatisticCommandExecuted);
        
        /// <summary>Логика выполнения - Вычислить статические данные</summary>
        private async Task OnComputeStatisticCommandExecuted()
        {
            await ComputeDealsStatisticAsync();

            
            
            
        }

        private async Task ComputeDealsStatisticAsync() {
            var bestsellers_quary = _DealsRepository.Items
                .GroupBy(b => b.Book.Id)
                .Select(deals => new { BookId = deals.Key, Count = deals.Count(), Sum = deals.Sum(d=>d.Price) })
                .OrderByDescending(deals => deals.Count)
                .Take(5)
                .Join(_BooksRepository.Items,
                        deals => deals.BookId,
                        book => book.Id,
                        (deals, book) => new BestSellerInfo 
                        { 
                            Book = book, 
                            SellCount = deals.Count, 
                            SumCost = deals.Sum 
                        });

                Bestsellers.AddClear(await bestsellers_quary.ToArrayAsync());
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
