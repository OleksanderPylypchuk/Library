using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class BorrowedBookList : IBookList
	{
		List<Book> books;
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
			foreach (Book book in books)
			{
				if (book.Title == title) return book;
			}
			return null;
		}

		public bool RemoveBook(Book book)
		{
			return books.Remove(book);
		}
		public string RetriveBookNames()
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
