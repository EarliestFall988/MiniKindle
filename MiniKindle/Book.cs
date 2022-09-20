using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniKindle
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        /// <summary>
        /// The title of the book
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = "New Book Title";

        /// <summary>
        /// The finger print id of the book (so we know which book is which)
        /// </summary>
        [JsonPropertyName("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// The list of pages
        /// </summary>
        [JsonPropertyName("pages")]
        public List<Page> Pages { get; set; } = new List<Page>();

        /// <summary>
        /// The current page
        /// </summary>
        [JsonPropertyName("current-page")]
        public int CurrentPage { get; set; } = 0;

        /// <summary>
        /// The list of bookmarks
        /// </summary>
        [JsonPropertyName("book-marks")]
        public List<BookMark> BookMarks { get; set; } = new List<BookMark>();

        /// <summary>
        /// Get current page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">thrown when the page is not within range of an actual page</exception>
        public Page GetCurrentPage()
        {
            foreach(var x in Pages)
            {
                if(x.PageNumber == CurrentPage)
                {
                    return x;
                }
            }

            throw new ArgumentOutOfRangeException("cannot find page with the page number " + CurrentPage);
        }

        public int CompareTo(Book? other)
        {
            if(other == null) return 1;

            return this.ID.CompareTo(other.ID);
        }

        public bool Equals(Book? other)
        {
           if(other==null) return false;

           return this.ID.Equals(other.ID);
        }
    }
}
