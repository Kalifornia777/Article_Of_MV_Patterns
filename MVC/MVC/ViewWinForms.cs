using System;
using System.Reflection;
using System.Windows.Forms;

namespace MVC
{
    public partial class ViewWinForms : Form, IView
    {
        private readonly ControllerLibrary controller;

        public new void Show()
        {
            Application.Run(this);
        }

        public ViewWinForms(ControllerLibrary controller, LibraryCollection model)
        {
            InitializeComponent();
            this.controller = controller;

            controller.OnSuccessMessage += ShowSuccess;
            controller.OnErrorMessage += ShowError;
            model.OnLibraryListUpdated += DisplayLibraryList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string address = textBox2.Text;
            string booksInput = textBox3.Text;

            controller.AddLibrary(name, address, booksInput);
        }

        public void DisplayLibraryList(string libraryList)
        {
            label4.Text = libraryList;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
