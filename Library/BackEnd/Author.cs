using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class Author : People
	{
		private string _name;
		private int _birthDate;
		private int? _deathDate;
		public override string Name { get { return _name; }
			set {if (string.IsNullOrEmpty(value) || (value.Length < 3 || value.Length > 20))
					throw new Exception("Неможливе ім'я"); 
				_name = value;} }
		public override int BirthDate { get { return _birthDate; }
			set {if (value > 2010)
					throw new Exception("Неможливий вік автора");
			_birthDate = value;
			}
		}
		public int? DeathDate { get { return _deathDate; }
			set {if (value <= _birthDate)
					throw new Exception("Неможлива дата смерті");
			_deathDate = value;
			} }
		public Author(string name, int birthDate, int? deathDate)
		{
			Name = name;
			BirthDate = birthDate;
			DeathDate = deathDate;
		}
		public Author(string name, int birthDate):this(name, birthDate, null)
		{ 

		}
	}
}
