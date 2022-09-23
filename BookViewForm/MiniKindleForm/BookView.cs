using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniKindleForm
{
    public partial class BookView : Form
    {
        /// <summary>
        /// Controller
        /// </summary>
        BookController BookController;

        /// <summary>
        /// Current Book
        /// </summary>
        Book book;

        /// <summary>
        /// Constructor for Book view
        /// </summary>
        /// <param name="c">Controller</param>
        /// <param name="b">Current Book</param>
        public BookView(BookController c, Book b)
        {
            InitializeComponent();
            BookController = c;
            book = b;
            addTextToTextBox();
        }

        /// <summary>
        /// This method adds header text to header txt box
        /// </summary>
        private void addHeaderToTextBox()
        {
            uxHeaderTextBox.Text = book.Pages[book.CurrentPage].PageHeader.ToString();
        }

        /// <summary>
        /// This method adds the words from the page to the big text box in the view
        /// </summary>
        private void addTextToTextBox()
        {
            uxTextBox.Text = book.Pages[book.CurrentPage].Words.ToString();
        }

        /// <summary>
        /// This method changes the books current page to add one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNextBtn_Click(object sender, EventArgs e)
        {
            if(book.CurrentPage != book.Pages.Count())
            {
                book.CurrentPage += 1;
            }
        }
        /// <summary>
        /// This method changes the books current page to subtract one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void uxPreviousBtn_Click(object sender, EventArgs e)
        {
            if(book.CurrentPage != 0)
            {
                book.CurrentPage += 1;
            }
        }

        private void uxBookMark_Click(object sender, EventArgs e)
        {
            BookMark bm = new BookMark(book.CurrentPage);
            book.BookMarks.Add(bm);
        }
    }
}
