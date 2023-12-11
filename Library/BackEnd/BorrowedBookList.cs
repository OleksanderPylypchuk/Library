using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
    public class BorrowedBookList : IBookList<Book>
	{
		public List<Book> books;
		public BorrowedBookList()
		{
			books = new List<Book>();
		}
		public void AddBook(Book book)
		{
			books.Add(book);
		}

		public Book Find(string title)
		{
			return books.FirstOrDefault(u=>u.Title == title);
		}

		public bool RemoveBook(Book book)
		{
			if(!books.Contains(book)) return false;
			books.Remove(book);
			return true;
		}

		public string RetrieveBookNames()
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
