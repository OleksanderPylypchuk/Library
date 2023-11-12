using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd;

namespace TestProject.Tests
{
    [TestClass]
    public class LibraryTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Exception exception = null;

            try
            {
                new BookLibrary();
            }
            catch (Exception ex) { exception = ex; }

            Assert.IsNull(exception);
        }
        [TestMethod]
        public void TestAddBook()
        {
            BookLibrary bookLibrary = new BookLibrary();
            Exception exception = null;

            try
            {
                bookLibrary.AddBook(new Book("something", 1999, new Author("someone", 1988)));
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }
        [TestMethod]
        public void TestRemoveBookNonExistent()
        {
            BookLibrary bookLibrary = new BookLibrary();

            Assert.IsFalse(bookLibrary.RemoveBook(new Book("something", 1999, new Author("someone", 1988))));
        }
        [TestMethod]
        public void TestRemoveBookExistent()
        {
            BookLibrary bookLibrary = new BookLibrary();
            Book book = new Book("something", 1999, new Author("someone", 1988));
            bookLibrary.AddBook(book);

            Assert.IsTrue(bookLibrary.RemoveBook(book));
        }
        [TestMethod]
        public void TestFindBookWrongName()
        {
            BookLibrary bookLibrary = new BookLibrary();
            Exception exception = null;

            try
            {
                bookLibrary.Find("somebook");
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }
        [TestMethod]
        public void TestFindBookRightName()
        {
            BookLibrary bookLibrary = new BookLibrary();
            bookLibrary.AddBook(new Book("something", 1999, new Author("someone", 1988)));
            Exception exception = null;

            try
            {
                bookLibrary.Find("something");
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }
        [TestMethod]
        public void TestPrint()
        {
            BookLibrary bookLibrary = new BookLibrary();
            Exception exception = null;

            try
            {
                bookLibrary.PrintToDisplay();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }
    }
}
