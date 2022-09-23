using Xunit;
using Project_To_Turn_In;

namespace MiniKindleTests
{
    /// <summary>
    /// Unit tests
    /// </summary>
    public class UnitTest1
    {
        /// <summary>
        /// Creating a book mark sucessful
        /// </summary>
        [Fact]
        public void CreatingBookMarkSuccessful()
        {
            BookMark bookMark = new BookMark()
            {
                BookMarkLocation = 2,
            };
        }

        /// <summary>
        /// Creating a page successful
        /// </summary>
        [Fact]
        public void CreatingPageSuccessful()
        {
            Page page = new Page()
            {
                Words = "this is a string of words",
                PageNumber = 1,
                PageHeader = "First Page"
            };
        }

        /// <summary>
        /// Creating a book os successful
        /// </summary>
        [Fact]
        public void CreatingBookSuccessful()
        {
            Book book = new Book()
            {
                Title = "Some book title",
                Pages = new System.Collections.Generic.List<Page>(),
                BookMarks = new System.Collections.Generic.List<BookMark>(),
            };
        }
    }
}