using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using Bookinist.Services.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookinist.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Book> _BooksRepository;
        private readonly IRepository<Seller> _SellersRepository;
        private readonly IRepository<Buyer> _BuyersRepository;
        private readonly IRepository<Deal> _DealsRepository;
        private readonly ISaleService _SaleService;
        private readonly IUserDialog _UserDialog;

        //------------------------------------------------------------------------------------
        #region Title : string - Загаловок
        /// <summary>Загаловок</summary>
        private string _Title = "Главное окно программы";

        /// <summary>Загаловок</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        #region CurrentModel : ViewModel - Текущая дочерняя модель-прдест
        /// <summary>Текущая дочерняя модель-прдест</summary>
        private ViewModel _CurrentModel;

        /// <summary>Текущая дочерняя модель-прдест</summary>
        public ViewModel CurrentModel { get => _CurrentModel; private set => Set(ref _CurrentModel, value); }
        #endregion
        //------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------
        #region Command ShowBooksViewCommand - Отобразить представление книг
        /// <summary>Отобразить представление книг</summary>
        private ICommand _ShowBooksViewCommand;

        /// <summary>Отобразить представление книг</summary>
        public ICommand ShowBooksViewCommand => _ShowBooksViewCommand
            ??= new LambdaCommand(OnShowBooksViewCommandExecuted, CanShowBooksViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Отобразить представление книг</summary>
        private bool CanShowBooksViewCommandExecute() => true;

        /// <summary>Логика выполнения - Отобразить представление книг</summary>
        private void OnShowBooksViewCommandExecuted() 
        {
            CurrentModel = new BooksViewModel(_BooksRepository, _UserDialog);
        }
        #endregion

        #region Command ShowBuyersViewCommand - Отобразить представление покупателей
        /// <summary>Отобразить представление покупателей</summary>
        private ICommand _ShowBuyersViewCommand;

        /// <summary>Отобразить представление покупателей</summary>
        public ICommand ShowBuyersViewCommand => _ShowBuyersViewCommand
            ??= new LambdaCommand(OnShowBuyersViewCommandExecuted, CanShowBuyersViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Отобразить представление покупателей</summary>
        private bool CanShowBuyersViewCommandExecute() => true;

        /// <summary>Логика выполнения - Отобразить представление покупателей</summary>
        private void OnShowBuyersViewCommandExecuted()
        {
            CurrentModel = new BuyersViewModel(_BuyersRepository);
        }
        #endregion

        #region Command ShowStatisticViewCommand - Отобразить представление статистики
        /// <summary>Отобразить представление статистики</summary>
        private ICommand _ShowStatisticViewCommand;

        /// <summary>Отобразить представление статистики</summary>
        public ICommand ShowStatisticViewCommand => _ShowStatisticViewCommand
            ??= new LambdaCommand(OnShowStatisticViewCommandExecuted, CanShowStatisticViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Отобразить представление статистики</summary>
        private bool CanShowStatisticViewCommandExecute() => true;

        /// <summary>Логика выполнения - Отобразить представление статистики</summary>
        private void OnShowStatisticViewCommandExecuted()
        {
            CurrentModel = new StatisticViewModel(_BooksRepository, _BuyersRepository, _SellersRepository, _DealsRepository);
        }
        #endregion
        //------------------------------------------------------------------------------------

        public MainWindowViewModel(
            IRepository<Book> BooksRepository, 
            IRepository<Seller> SellersRepository, 
            IRepository<Buyer> BuyersRepository,
            IRepository<Deal> DealsRepository,
            ISaleService SaleService,
            IUserDialog UserDialog)
        {
            _BooksRepository = BooksRepository;
            _SellersRepository = SellersRepository;
            _BuyersRepository = BuyersRepository;
            _DealsRepository = DealsRepository;
            _SaleService = SaleService;
            _UserDialog = UserDialog;

            /*var dealsCount = _SaleService.Deals.Count();

            var book = _BooksRepository.Get(5);
            var buyer = BuyersRepository.Get(3);
            var seller = SellersRepository.Get(4);

            var deal = SaleService.MakeDeal(book.Name, seller, buyer, 867.45m);
            
            var dealsCount2 = _SaleService.Deals.Count();*/
        }
    }
}
