using Bookinist.DAL.Entities;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace Bookinist.ViewModels
{
    class BooksViewModel : ViewModel
    {
        private IRepository<Book> _BooksRepository;

        public BooksViewModel(IRepository<Book> BooksRepository)
        {
            _BooksRepository = BooksRepository;
        }
    }
}
