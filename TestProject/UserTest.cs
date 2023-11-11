using Library.BackEnd;

namespace TestProject
{
	[TestClass]
	public class UserTest
	{
		[TestMethod]
		public void TestConstructorWrongValue()
		{
			string name = "";
			string email = "";
			int birthDate=5;
			Exception exception = null;

			try
			{
				new User(name, birthDate, email);
			}
			catch (NotImplementedException ex) { }
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
		public void TestTakeBookWrongTitle()
		{
			string title = "non existent";
			User user = new User("Name", 1998, "damls@gmail.com");
			Exception exception = null;

			try
			{
				user.TakeBook(title);
			}
			catch (NotImplementedException ex) { }
			catch (Exception ex) { exception = ex; };

			Assert.IsNotNull(exception);
		}
		[TestMethod]
		public void TestTakeBook()
		{
			string title = "existent";
			User user = new User("Name", 1998, "damls@gmail.com");
			Exception exception = null;
			try
			{
				user.TakeBook(title);
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
			try
			{
				user.ReturnBook(title);
			}
			catch (NotImplementedException ex) { }
			catch (Exception ex) { exception = ex; };

			Assert.IsNotNull(exception);
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

			Assert.IsNotNull(exception);
		}
	}
}