using MiniKindle;

namespace MiniKindleUserInterface
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            BookController controller = new BookController(); // here is the book controller

            Application.Run(new Form1()); // here is the form
        }
    }
}