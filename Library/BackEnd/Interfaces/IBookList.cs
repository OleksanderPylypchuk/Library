using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BackEnd.Interfaces
{
	public interface IBookList
	{
		public void AddBook(Book book);
		public void RemoveBook(Book book);
		public Book Find(string title);
	}
}
