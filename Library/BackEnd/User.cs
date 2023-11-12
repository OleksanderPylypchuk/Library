using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class User : IPeople, IPrintable
	{
		private string _name;
		private string _email;
		private int _birthDate;
		public string Name { get { return _name; }
			set
			{
				if (string.IsNullOrEmpty(value) || (value.Length < 3 || value.Length > 20))
					throw new Exception("Неможливе ім'я");
				_name = value;
			}
		}

		public int BirthDate { get => _birthDate;
			set
			{
				if (value > 2010)
					throw new Exception("Неможливий вік користувача");
				_birthDate = value;
			}
		}

		public string Email { get; set; }
		public BorrowedBookList list;
		public User(string name, int birthDate, string email)
		{
			Name = name;
			BirthDate = birthDate;
			Email = email;
			list = new BorrowedBookList();
		}	
		public void TakeBook(Book book)
		{
			list.AddBook(book);
		}
		public Book ReturnBook(string title)
		{
			Book book = list.Find(title); 
			if(book!=null)
			{
				list.RemoveBook(book);
			}
			return book;
		}
		public void PrintToDisplay()
		{
			string info = $"			Інформація про користувача\nІм'я: {Name}\nДата народження: {BirthDate}\nКонтактна інформація: {Email}\nВзяті книги:";
			info += list.RetriveBookNames();
		}
	}
}
