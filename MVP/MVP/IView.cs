using System;

namespace MPC
{
    public interface IView
    {
        event Action<string, string, string> OnAddLibrary;
        event Action OnRequestLibraryList;

        void DisplayLibraryList(string libraryList);
        void ShowError(string message);
        void ShowSuccess(string message);
    }
}
