using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BackEnd
{
	public class YoungUser:User
	{
		public override int BirthDate 
		{ 
			get
			{
				return base.BirthDate;
			}
			set
			{
				if (value>2020) throw new Exception("Занадто юний користувач");
				if (value<2010) throw new Exception("Вік не підходить для юного користувача");
				base.BirthDate = value;
			}
		}
		public int BooksCount {  get; set; }
		public YoungUser(string name, int birthDate, string email):base(name, birthDate, email) 
		{
			BooksCount = 0;
		}
		public override void TakeBook(Book book)
		{
			BooksCount++;
			if (BooksCount > 3)
			{
				BooksCount--;
				throw new Exception("Користувач до 14 років не може взяти більше трьох книг одночасно");
			}
			base.TakeBook(book);
		}
		public override Book ReturnBook(string title)
		{
			BooksCount--;
			return base.ReturnBook(title);
		}
	}
}
