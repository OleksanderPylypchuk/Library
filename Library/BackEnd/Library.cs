﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class Library : IBookList,IPrintable
	{
		public void AddBook(Book book)
		{
			throw new NotImplementedException();
		}

		public Book Find(string title)
		{
			throw new NotImplementedException();
		}

		public void PrintToDisplay()
		{
			throw new NotImplementedException();
		}

		public void RemoveBook(Book book)
		{
			throw new NotImplementedException();
		}
	}
}
