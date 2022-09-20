using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniKindle
{
    /// <summary>
    /// The class representing a controller for the minikindle book library
    /// </summary>
    public class BookController
    {
        /// <summary>
        /// the location of the book text file
        /// </summary>
        private static readonly string bookfileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// the list of books
        /// </summary>
        private List<Book> BooksList = new List<Book>();

        /// <summary>
        /// Enumerate through the list of books
        /// </summary>
        public IEnumerable<Book> Books => BooksList;

        /// <summary>
        /// The count of books
        /// </summary>
        public int BookCount => BooksList.Count;

        /// <summary>
        /// Default constructor - might need to change the later
        /// </summary>
        public BookController()
        {
            Sync(SyncStrategy.Fetch);
        }

        /// <summary>
        /// Add list of Books
        /// </summary>
        /// <param name="booksList">the list of books</param>
        public BookController(List<Book> booksList)
        {
            BooksList = booksList;
        }

        /// <summary>
        /// Constructor with action delegates this one is probably what you want to hook into for the front end
        /// </summary>
        /// <param name="addB">the add book</param>
        /// <param name="removeB">the remove book</param>
        /// <param name="updateB">the update book</param>
        /// <param name="setPage">set the current page that the user is viewing</param>
        /// <param name="getBooks">get the list of books</param>
        public BookController(Action<Book> addB, Action<Book> removeB, Action<Book, Book> updateB, Action<Book, Page> setPage, Func<Book[]> getBooks)
        {
            addB = AddBook;
            removeB = RemoveBook;
            updateB = UpdateBook;
            getBooks = GetBooks;
            setPage = SetCurrentPage;

            Sync(SyncStrategy.Fetch);
        }

        /// <summary>
        /// Add a book to the list
        /// </summary>
        /// <param name="b"></param>
        /// <exception cref="Exception">exception</exception>
        public void AddBook(Book b)
        {

            if (BooksList.Count >= 5)
            {
                throw new Exception("Cannot have more than 5 books");
            }

            BooksList.Add(b);

            Sync();
        }


        /// <summary>
        /// Remove a book from the list
        /// </summary>
        /// <param name="b">the book to remove from the list</param>
        public void RemoveBook(Book b)
        {
            BooksList.Remove(b);

            Sync();
        }

        /// <summary>
        /// Update a book in the list
        /// </summary>
        /// <param name="oldB">the old book</param>
        /// <param name="newBook">the new book</param>
        public void UpdateBook(Book oldB, Book newBook)
        {

            newBook.ID = oldB.ID;

            BooksList.Remove(oldB);
            BooksList.Add(newBook);

            Sync();
        }

        /// <summary>
        /// Get an array of books
        /// </summary>
        /// <returns>returns an array of book</returns>
        public Book[] GetBooks()
        {
            return Books.ToArray();
        }

        /// <summary>
        /// Set the current page (if you are looking to go to the next page or back a page, just find the page and send it here)
        /// </summary>
        /// <param name="b">the book</param>
        /// <param name="p">the page</param>
        public void SetCurrentPage(Book b, Page p) //read comments above
        {
            int currentP = p.PageNumber;
            b.CurrentPage = currentP;
            UpdateBook(b, b);
        }

        #region no need to look at this lol

        /// <summary>
        /// Sync to the server (text file)
        /// </summary>
        /// <param name="strat">the sync strategy</param>
        private void Sync(SyncStrategy strat = SyncStrategy.Save)
        {
            if (strat == SyncStrategy.Fetch)
            {

                List<Book> books = Deserialize();

                if (books != BooksList)
                    BooksList = books;
            }
            else if (strat == SyncStrategy.Save)
            {
                Serialize();
            }
        }

        /// <summary>
        /// Update the books list
        /// </summary>
        private void Serialize()
        {

            var json = JsonSerializer.Serialize<List<Book>>(BooksList);

            using (FileStream stream = File.OpenWrite(bookfileLocation))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(json);
                }
            }
        }

        /// <summary>
        /// Get the books list
        /// </summary>
        /// <returns></returns>
        private List<Book> Deserialize()
        {
            var json = JsonSerializer.Deserialize<List<Book>>(bookfileLocation);

            if (json != null)
                return json;
            else
                return new List<Book>();
        }
        #endregion
    }

    /// <summary>
    /// The sync strategy
    /// </summary>
    public enum SyncStrategy
    {
        Save,
        Fetch
    }
}
