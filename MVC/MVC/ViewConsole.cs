using System;

namespace MVC
{
    public class ViewConsole : IView
    {
        private readonly ControllerLibrary controller;

        public ViewConsole(ControllerLibrary controller, LibraryCollection model)
        {
            this.controller = controller;
            controller.OnSuccessMessage += ShowSuccess;
            controller.OnErrorMessage += ShowError;
            model.OnLibraryListUpdated += DisplayLibraryList;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\nДобавление библиотеки:");
                Console.Write("Название: ");
                string name = Console.ReadLine();

                Console.Write("Адрес: ");
                string address = Console.ReadLine();

                Console.Write("Количество книг: ");
                string booksInput = Console.ReadLine();

                controller.AddLibrary(name, address, booksInput);

                Console.Write("Хотите продолжить? да/нет: ");
                var choice = Console.ReadLine();
                if (choice?.ToLower() != "да")
                    break;
            }
        }

        private void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + message);
            Console.ResetColor();
        }

        private void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Успех: " + message);
            Console.ResetColor();
        }

        private void DisplayLibraryList(string libraryList)
        {
            Console.WriteLine("\nТекущий список библиотек:\n" + libraryList + "\n");
        }
    }
}
