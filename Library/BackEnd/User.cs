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
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int BirthDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string Email { get; set; }
		public BorrowedBookList list;
		public User(string name, int birthDate, string email)
		{
			//Name = name;
			//BirthDate = birthDate;
			//Email = email;
			throw new NotImplementedException();
		}	
		public void TakeBook(string title)
		{
			throw new NotImplementedException();
		}
		public void ReturnBook(string title)
		{ 
			throw new NotImplementedException(); 
		}
		public void PrintToDisplay()
		{
			throw new NotImplementedException();
		}
	}
}
