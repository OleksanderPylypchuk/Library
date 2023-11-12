using Library.BackEnd;

namespace TestProject.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestConstructorWrongValue()
        {
            string name = "";
            string email = "";
            int birthDate = 5;
            Exception exception = null;

            try
            {
                new User(name, birthDate, email);
            }
            catch (Exception ex) { exception = ex; }

            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void TestConstructorRightValue()
        {
            string name = "Petro Doroshenko";
            string email = "asaskdaks@gmail.com";
            int birthDate = 1996;
            Exception exception = null;

            try
            {
                new User(name, birthDate, email);
            }
            catch (Exception ex) { exception = ex; }

            Assert.IsNull(exception);
        }
        [TestMethod]
        public void TestTakeBook()
        {
            string title = "existent";
            User user = new User("Name", 1998, "damls@gmail.com");
            Book book = new Book("something", 1999, new Author("someone", 1988));
            Exception exception = null;
            try
            {
                user.TakeBook(book);
            }
            catch (Exception ex) { exception = ex; };

            Assert.IsNull(exception);
        }
        [TestMethod]
        public void TestRemoveBookWrongTitle()
        {
            string title = "non existent";
            User user = new User("Name", 1998, "damls@gmail.com");
            Exception exception = null;

            Assert.IsFalse(user.ReturnBook(title) != null);
        }
        [TestMethod]
        public void TestPrintInfo()
        {
            User user = new User("Name", 1998, "damls@gmail.com");
            Exception exception = null;
            try
            {
                user.PrintToDisplay();
            }
            catch (Exception ex) { exception = ex; };

            Assert.IsNull(exception);
        }
        [TestMethod]
        public void TestReturnBookWrongName()
        {
            User user = new User("Name", 1998, "damls@gmail.com");

            Book book = user.ReturnBook("");

            Assert.IsNull(book);
        }
        [TestMethod]
        public void TestReturnBookRightName()
        {
            User user = new User("Name", 1998, "damls@gmail.com");
            Book book = new Book("something", 1999, new Author("someone", 1988));
            user.TakeBook(book);

            book = user.ReturnBook("something");

            Assert.IsNotNull(book);
        }
    }
}