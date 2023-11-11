using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd;

namespace TestProject
{
	[TestClass]
	public class AuthorTest
	{
		[TestMethod]
		public void ConstructorTestEmptyName()
		{
			string name = ""; int birth = 1999;
			Exception ex=null;

			try
			{
				new Author(name, birth);
			}
			catch (NotImplementedException exc) { }
			catch (Exception exc)
			{
				ex = exc;
			}

			Assert.IsNotNull(ex);
		}
		[TestMethod]
		public void ConstructorTestWrongDeathDay()
		{
			string name = "Some Dude"; int birth = 1999; int death = 1983;
			Exception ex = null;

			try
			{
				new Author(name, birth, death);
			}
			catch (NotImplementedException exc) { }
			catch (Exception exc)
			{
				ex = exc;
			}

			Assert.IsNotNull(ex);
		}
		[TestMethod]
		public void ConstructorTestWithDeath()
		{
			string name = "Some Dude"; int birth = 1999; int death = 2022;
			Exception ex = null;

			try
			{
				new Author(name, birth, death);
			}
			catch (Exception exc)
			{
				ex = exc;
			}

			Assert.IsNull(ex);
		}
		public void ConstructorTestWithoutDeath()
		{
			string name = "Some Dude"; int birth = 1999;
			Exception ex = null;

			try
			{
				new Author(name, birth);
			}
			catch (Exception exc)
			{
				ex = exc;
			}

			Assert.IsNull(ex);
		}
	}
}
