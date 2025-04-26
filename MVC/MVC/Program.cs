using System;
using System.Windows.Forms;

namespace MVC
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var libraryCollection = new LibraryCollection();
            var controller = new ControllerLibrary(libraryCollection);

            Console.WriteLine("Выберите режим:");
            Console.WriteLine("1. Графический интерфейс (WinForms)");
            Console.WriteLine("2. Консоль");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            IView view;

            if (choice == "1")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                view = new ViewWinForms(controller, libraryCollection);
                view.Show();
            }
            else
            {
                view = new ViewConsole(controller, libraryCollection);
                view.Show();
            }
        }
    }
}
