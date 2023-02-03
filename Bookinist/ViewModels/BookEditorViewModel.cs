using Bookinist.DAL.Entities;
using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.ViewModels
{
    internal class BookEditorViewModel : ViewModel
    {
        public int BookId { get; }
        
        
        #region Name : string - Название книги
        /// <summary>Название книги</summary>
        private string _Name;

        /// <summary>Название книги</summary>
        public string Name { get => _Name; set => Set(ref _Name, value); }
        #endregion

        public BookEditorViewModel() : this (new Book { Id = 1, Name = "Алифбо" })
        {
            if (!App.IsDesignTime)
            {
                throw new InvalidOperationException("Не для рантайма!");
            }
        }
        public BookEditorViewModel(Book book)
        {
            BookId = book.Id;
            Name = book.Name;
        }


    }
}
