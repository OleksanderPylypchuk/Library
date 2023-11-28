using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Abstract;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class BookLibrary : BookList
	{
		public override string RetrieveBookNames()
		{
			string result = "Книги у бібліотеці:";
			foreach (Book book in books)
			{
				result += book.Title + " ";
			}
			return result;
		}
	}
}
