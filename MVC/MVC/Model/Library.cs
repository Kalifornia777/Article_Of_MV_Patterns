using System;
using System.Collections.Generic;

namespace MVC
{
    public class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfBooks { get; set; }

        public Library(string name, string address, int numberOfBooks)
        {
            Name = name;
            Address = address;
            NumberOfBooks = numberOfBooks;
        }
        public override string ToString()
        {
            return $"{Name} ({Address}) - {NumberOfBooks} книг";
        }
    }

    public class LibraryCollection
    {
        private List<Library> libraries = new List<Library>();

        public event Action<string> OnLibraryListUpdated;

        public void AddLibrary(Library library)
        {
            libraries.Add(library);
            NotifyView();
        }

        public string GetLibrariesList()
        {
            return libraries.Count > 0 ? string.Join("\n", libraries) : "Список библиотек пуст";
        }

        private void NotifyView()
        {
            OnLibraryListUpdated?.Invoke(GetLibrariesList());
        }
    }
}
