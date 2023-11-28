using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Abstract;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class BorrowedBookList : BookList
	{
		public override string RetrieveBookNames()
		{
			string result = "";
			foreach(Book book in books)
			{
				result += book.Title + "\n";
			}
			return result;
		}
	}
}
