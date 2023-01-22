using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Book> _BooksRepository;
        
        #region Title : string - Загаловок
        /// <summary>Загаловок</summary>
        private string _Title = "Главное окно программы";

        /// <summary>Загаловок</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion


        public MainWindowViewModel(IRepository<Book> BooksRepository)
        {
            _BooksRepository = BooksRepository;
            var books = _BooksRepository.Items.Take(10).ToArray();
        }
    }
}
