using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd;

namespace TestProject
{
	[TestClass]
	public class TestBook
	{
		[TestMethod]
		public void TestConstructor()
		{
			try
			{
				new Book("something", 1999, new Author("someone", 1988));
			}
			catch
			{
				Assert.Fail();
			}

			Assert.IsTrue(true);
		}
		[TestMethod]
		public void TestConstructorWrongYear()
		{
			try
			{
				new Book("something", 1987, new Author("someone", 1988));
			}
			catch
			{
				Assert.IsTrue(true);
				return;
			}
			Assert.Fail();
		}
		[TestMethod]
		public void TestPrint()
		{
			Book book = new Book("something", 1999, new Author("someone", 1988));
			Exception exception = null;

			try
			{
				book.PrintToDisplay();
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNull(exception);
		}
	}
}
