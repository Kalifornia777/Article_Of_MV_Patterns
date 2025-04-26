using System;

namespace MVVM
{
    public class ViewModelLibrary
    {
        private readonly LibraryCollection libraryCollection;

        public event Action<string> OnSuccessMessage;
        public event Action<string> OnErrorMessage;
        public event Action<string> OnLibraryListUpdated;

        public ViewModelLibrary(LibraryCollection libraryCollection)
        {
            this.libraryCollection = libraryCollection;
        }

        public void AddLibrary(string name, string address, string booksInput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
                {
                    OnErrorMessage?.Invoke("Название и адрес библиотеки не могут быть пустыми");
                    return;
                }

                if (!int.TryParse(booksInput, out int numberOfBooks))
                {
                    OnErrorMessage?.Invoke("Введите корректное число для количества книг!");
                    return;
                }

                if (numberOfBooks < 0)
                {
                    OnErrorMessage?.Invoke("Количество книг не может быть отрицательным.");
                    return;
                }

                var library = new Library(name, address, numberOfBooks);
                libraryCollection.AddLibrary(library);

                OnLibraryListUpdated?.Invoke(libraryCollection.GetLibrariesList());

                OnSuccessMessage?.Invoke("Библиотека успешно добавлена!");

            }
            catch (Exception ex)
            {
                OnErrorMessage?.Invoke(ex.Message);
            }
        }
    }
}
