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

		public void PrintToDisplay()
		{
			throw new NotImplementedException();
		}
	}
}
