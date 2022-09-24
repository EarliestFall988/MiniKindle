﻿using System;
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
            addTitleToTextBox();
            uxPgNum.Maximum = book.Pages.Count() -1;
            uxPgNum.Minimum = 0;
        }

        /// <summary>
        /// This method adds header text to header txt box
        /// </summary>
        private void addTitleToTextBox()
        {
            uxTitleTextBox.Text = book.Title.ToString();
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
            if(book.CurrentPage != book.Pages.Count() - 1)
            {
                book.CurrentPage += 1;
                addTextToTextBox();
                uxPreviousBtn.Enabled = true;
                
                object BookMark = new BookMark(book.CurrentPage);
                if (book.BookMarks.Contains(BookMark))
                {
                    uxBookMarked.Text = "BookMarked";
                }
                else
                {
                    uxBookMarked.Text = "";
                }
            }

            if ((book.CurrentPage == book.Pages.Count() - 1))
            {
                uxNextBtn.Enabled = false;
            }


            if (book.TryGetCurrentPage(out var page))
            {

                if (book.CurrentPage >= 0 && book.CurrentPage < book.Pages.Count)
                    BookController.SetCurrentPage(book, page);

                uxPgNum.Value = book.CurrentPage;
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
                book.CurrentPage -= 1;
                addTextToTextBox();
                uxNextBtn.Enabled = true;
                if (book.CurrentPage == 0)
                {
                    uxPreviousBtn.Enabled = false;
                }
                object BookMark = new BookMark(book.CurrentPage);
                if (book.BookMarks.Contains(BookMark))
                {
                    uxBookMarked.Text = "BookMarked";
                }
                else
                {
                    uxBookMarked.Text = "";
                }
            }

            if (book.TryGetCurrentPage(out var page))
            {

                if (book.CurrentPage >= 0 && book.CurrentPage < book.Pages.Count)
                    BookController.SetCurrentPage(book, page);
            }

            uxPgNum.Value = book.CurrentPage;
        }

        /// <summary>
        /// Method to add book mark when btn clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBookMark_Click(object sender, EventArgs e)
        {
            
            if(uxBookMarked.Text == "")
            {
                BookMark bm = new BookMark(book.CurrentPage);
                book.BookMarks.Add(bm);
                uxBookMarked.Text = "BookMarked";

                
            }
            else
            {
                BookMark bm = new BookMark(book.CurrentPage);
                int index = book.BookMarks.IndexOf(bm);
                book.BookMarks.RemoveAt(index);
                uxBookMarked.Text = "";
            }

            BookController.UpdateBook(book);
        }

        /// <summary>
        /// Changes page when the up down is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPgNum_ValueChanged(object sender, EventArgs e)
        {
            book.CurrentPage = Int32.Parse(uxPgNum.Value.ToString());
            addTextToTextBox();
        }

        private void uxTitleTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
