using System;
using System.Windows.Forms;

namespace MPC
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var libraryCollection = new LibraryCollection();

            Console.WriteLine("Выберите режим:");
            Console.WriteLine("1. Графический интерфейс (WinForms)");
            Console.WriteLine("2. Консоль");
            Console.Write("Ваш выбор: ");
            string mode = Console.ReadLine();

            if (mode == "1")
            {
                Application.EnableVisualStyles();
                var view = new ViewWinForms();
                var presenter = new LibraryPresenter(view, libraryCollection);
                Application.Run(view);
            }
            else
            {
                var view = new ViewConsole();
                var presenter = new LibraryPresenter(view, libraryCollection);
                view.Start();
            }
        }
    }
}
