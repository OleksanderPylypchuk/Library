using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.BackEnd.Abstract
{
	public abstract class BookList
	{
		public List<Book> books;
		public BookList()
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
		public abstract string RetrieveBookNames();
	}
}
