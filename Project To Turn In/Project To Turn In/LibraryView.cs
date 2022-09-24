using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_To_Turn_In
{
    public partial class LibraryView : Form
    {

        BookController bc;

        BindingList<Book> listOfBooksForListBox = new BindingList<Book>();



        public LibraryView(BookController controller)
        {
            InitializeComponent();
            bc = controller;
            uxListBox.DataSource = listOfBooksForListBox;
            foreach(Book book in bc.Books)
            {
                listOfBooksForListBox.Add(book);
            }
        }

        private void uxOpenBtn_Click(object sender, EventArgs e)
        {
            BookView bv = new BookView(bc, uxListBox.SelectedItem as Book);
            bv.Show();
            bv.Setup();
        }
    }
}
