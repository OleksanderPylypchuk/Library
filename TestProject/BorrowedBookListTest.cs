using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd;

namespace TestProject
{
	[TestClass]
	public class BorrowedBookListTest
	{
		[TestMethod]
		public void AddBookTest()
		{
			BorrowedBookList book = new BorrowedBookList();
			Exception exception = null;

			try
			{
				book.AddBook(new Book("something", 1999, new Author("someone", 1988)));
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNull(exception);
		}
		[TestMethod]
		public void RemoveBookTest()
		{
			BorrowedBookList book = new BorrowedBookList();
			Exception exception = null;

			try
			{
				book.RemoveBook(new Book("something", 1999, new Author("someone", 1988)));
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNull(exception);
		}
		[TestMethod]
		public void FindBookTestNonExistent()
		{
			BorrowedBookList book = new BorrowedBookList();
			Exception exception = null;

			try
			{
				book.RemoveBook(new Book("something", 1999, new Author("someone", 1988)));
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNull(exception);
		}
		[TestMethod]
		public void FindBookTestExistent()
		{
			BorrowedBookList book = new BorrowedBookList();
			book.AddBook(new Book("something", 1999, new Author("someone", 1988)));
			Exception exception = null;

			try
			{
				book.RemoveBook(new Book("something", 1999, new Author("someone", 1988)));
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNull(exception);
		}
	}
}
