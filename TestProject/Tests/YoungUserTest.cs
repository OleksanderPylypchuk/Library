using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd;

namespace TestProject.Tests
{
	[TestClass]
	public class YoungUserTest
	{
		[TestMethod]
		public void TestConstructorTooYoung()
		{
			Exception exception = null;
			try
			{
				User younguser = new YoungUser("name", 2023, "email");
			}
			catch (Exception ex) { exception = ex; }

			Assert.IsNotNull(exception);
		}
		[TestMethod]
		public void TestConstructorTooOld()
		{
			Exception exception = null;

			try
			{
				User younguser = new YoungUser("name", 1999, "email");
			}
			catch (Exception ex) { exception = ex; }

			Assert.IsNotNull(exception);
		}
		[TestMethod]
		public void TestConstructorOkValues()
		{
			Exception exception = null;

			try
			{
				User younguser = new YoungUser("name", 2015, "email");
			}
			catch (Exception ex) { exception = ex; }

			Assert.IsNull(exception);
		}
		[TestMethod]
		public void TestTakingBook()
		{
			User younguser = new YoungUser("name", 2015, "email");
			Exception exception = null;

			try
			{
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
			}
			catch (Exception ex) { exception = ex;}

			Assert.IsNull(exception);
		}
		[TestMethod]
		public void TestTakingBooks()
		{
			User younguser = new YoungUser("name", 2015, "email");
			Exception exception = null;

			try
			{
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
			}
			catch (Exception ex) { exception = ex; }

			Assert.IsNotNull(exception);
		}
		[TestMethod]
		public void ReturningBooks()
		{
			User younguser = new YoungUser("name", 2015, "email");
			younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
			Exception exception = null;

			try
			{
				younguser.ReturnBook("something");
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
				younguser.TakeBook(new Book("something", 1999, new Author("someone", 1988)));
			}
			catch (Exception ex) { exception = ex; }

			Assert.IsNull(exception);
		}
	}
}
