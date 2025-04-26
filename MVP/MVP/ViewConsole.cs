using System;

namespace MPC
{
    public class ViewConsole : IView
    {
        public event Action<string, string, string> OnAddLibrary;
        public event Action OnRequestLibraryList;

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n1. Добавить библиотеку");
                Console.WriteLine("2. Показать список библиотек");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Название: ");
                        string name = Console.ReadLine();
                        Console.Write("Адрес: ");
                        string address = Console.ReadLine();
                        Console.Write("Количество книг: ");
                        string books = Console.ReadLine();
                        OnAddLibrary?.Invoke(name, address, books);
                        break;
                    case "2":
                        OnRequestLibraryList?.Invoke();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        public void DisplayLibraryList(string libraryList)
        {
            Console.WriteLine("\nСписок библиотек:");
            Console.WriteLine(libraryList);
        }

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + message);
            Console.ResetColor();
        }

        public void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Успех: " + message);
            Console.ResetColor();
        }
    }
}
