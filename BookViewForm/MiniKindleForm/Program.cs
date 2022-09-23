using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniKindleForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Book book = new Book();

            Page page1 = new Page();
            Page page2 = new Page();
            Page page3 = new Page();

            page1.Words = "Page one";
            book.Pages.Add(page1);

            page2.Words = "Page two";
            book.Pages.Add(page2);
            

            book.Pages.Add(page3);

            BookController bc = new BookController();

            Application.Run(new BookView(bc, book));
        }
    }
}
