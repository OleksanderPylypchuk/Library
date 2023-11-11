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
		public int? DeathDate { get; set; }
	}
}
