using System;

namespace MPC
{
    public class LibraryPresenter
    {
        private readonly IView view;
        private readonly LibraryCollection libraryCollection;

        public LibraryPresenter(IView view, LibraryCollection libraryCollection)
        {
            this.view = view;
            this.libraryCollection = libraryCollection;

            view.OnAddLibrary += AddLibrary;
            view.OnRequestLibraryList += DisplayLibraries;
        }

        private void AddLibrary(string name, string address, string booksInput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
                {
                    throw new ArgumentException("Название и адрес библиотеки не могут быть пустыми.");
                }

                if (!int.TryParse(booksInput, out int numberOfBooks))
                {
                    view.ShowError("Введите корректное число для количества книг!");
                    return;
                }

                if (numberOfBooks < 0)
                {
                    throw new ArgumentException("Количество книг не может быть отрицательным.");
                }

                var library = new Library(name, address, numberOfBooks);
                libraryCollection.AddLibrary(library);

                view.ShowSuccess("Библиотека успешно добавлена!");
            }
            catch (Exception ex)
            {
                view.ShowError(ex.Message);
            }
        }

        private void DisplayLibraries()
        {
            try
            {
                string librariesList = libraryCollection.GetLibrariesList();
                view.DisplayLibraryList(librariesList);
            }
            catch (Exception ex)
            {
                view.ShowError("Ошибка при выводе списка библиотек: " + ex.Message);
            }
        }
    }
}
