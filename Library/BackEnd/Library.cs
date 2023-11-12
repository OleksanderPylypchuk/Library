using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class BookLibrary : IBookList,IPrintable
	{
		public List<Book> books;
		public BookLibrary()
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

		public void PrintToDisplay()
		{
			string text = "Книги у бібліотеці:";
			foreach (Book book in books)
			{
				text += book.Title;
			}
			Console.WriteLine(text);
		}

		public bool RemoveBook(Book book)
		{
			return books.Remove(book);
		}
	}
}
