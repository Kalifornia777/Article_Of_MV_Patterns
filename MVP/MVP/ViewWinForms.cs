using System;
using System.Windows.Forms;

namespace MPC
{
    public partial class ViewWinForms : Form, IView
    {
        public event Action<string, string, string> OnAddLibrary;
        public event Action OnRequestLibraryList;

        public ViewWinForms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string address = textBox2.Text;
            string booksInput = textBox3.Text;

            OnAddLibrary?.Invoke(name, address, booksInput);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnRequestLibraryList?.Invoke();
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