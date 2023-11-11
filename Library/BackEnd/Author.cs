using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class Author : IPeople
	{
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int BirthDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		private int? DeathDate { get; set; }
		public Author(string name, int birthDate, int? deathDate)
		{
			//Name = name;
			//BirthDate = birthDate;
			//DeathDate = deathDate;
			throw new NotImplementedException();
		}
		public Author(string name, int birthDate):this(name, birthDate, null)
		{ 

		}
	}
}
