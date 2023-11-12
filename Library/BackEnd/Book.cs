using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd.Interfaces;

namespace Library.BackEnd
{
	public class Book : IPrintable
	{
		private string _title;
		public string Title { get { return _title; } set { if (value == "") throw new Exception("Пуста назва"); _title = value; } }
		public int PublishDate {  get; set; }
		Author Author { get; set; }
		public Book(string title, int date, Author author)
		{
			if (date < author.BirthDate||(author.DeathDate!=null&&date>author.DeathDate))
				throw new Exception("Книга написана не автором");
			Title = title;
			PublishDate = date;
			Author = author;
		}

		public void PrintToDisplay()
		{
			Console.WriteLine($"Назва: {Title}\nДата написання: {PublishDate}\nАвтор: {Author.Name}");
		}
	}
}
