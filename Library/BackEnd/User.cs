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
		public string Email { get; set; }
		public BorrowedBookList list;
		public string Name { get { return _name; }
			set
			{
				if (string.IsNullOrEmpty(value) || (value.Length < 3 || value.Length > 20))
					throw new Exception("Неможливе ім'я");
				_name = value;
			}
		}
		public virtual int BirthDate { get => _birthDate;
			set
			{
				_birthDate = value;
			}
		}
		public User(string name, int birthDate, string email)
		{
			Name = name;
			BirthDate = birthDate;
			Email = email;
			list = new BorrowedBookList();
		}	
		public virtual void TakeBook(Book book)
		{
			list.AddBook(book);
		}
		public virtual Book ReturnBook(string title)
		{
			Book book = list.Find(title); 
			if(book!=null)
			{
				list.RemoveBook(book);
			}
			return book;
		}
		public virtual void PrintToDisplay()
		{
			string info = $"			Інформація про користувача\nІм'я: {Name}\nДата народження: {BirthDate}\nКонтактна інформація: {Email}\nСтатус: Дорослий\nВзяті книги:";
			info += list.RetrieveBookNames();
			Console.WriteLine(info);
		}
	}
}
