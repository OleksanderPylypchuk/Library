using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd;

namespace Library.UserProgramCommunication
{
	public class Communication
	{
		public BookLibrary library;
		public List<User> users;
		public List<Author> authors;
		public User currentuser=null;
		public Communication()
		{
			library = new BookLibrary();
			users = new List<User>();
			authors = new List<Author>();
		}
		public void Options()
		{
			try
			{
				Console.WriteLine("Виберіть опцію:\n1 - Дії з книгами\n2 - Дії з користувачем\n3 - Додати автора\n4 - Переглянути книги у бібліотеці\n5 - Вихід");
				switch(Console.ReadLine())
				{
					case "1":
						BookOperations();
						break;
					case "2":
						UserOperations(); break;
					case "3":
						AddAuthor(); break;
					case "4":
						SeeBooksInLibrary(); break;
					case "5":
						Exit();
						break;
					default:
						throw new Exception("Немає такої опції");
				}
			}
			catch(Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void BookOperations()
		{
			try
			{
				Console.WriteLine("Виберіть опцію:\n1 - Додати книгу\n2 - Викинути книгу");
				switch (Console.ReadLine())
				{
					case "1":
						AddBook();
						break;
					case "2":
						TrashBook();
						break;
					default:
						throw new Exception("Немає такої опції");
				}
				ReturnToOptions();
			}
			catch (Exception e)
			{
				ReturnToOptions(e);
			}
		}
		public void AddBook()
		{
			try
			{
				Console.WriteLine("Введіть назву книги");
				string title = Console.ReadLine();
				Console.WriteLine("Введіть дату написання");
				int date = int.Parse(Console.ReadLine());
				Console.WriteLine("Виберіть автора за індексом"); int i = 0;
				foreach (Author author in authors)
				{
					Console.WriteLine(i + " - " + author.Name);
					i++;
				}
				i = int.Parse(Console.ReadLine());
				Book book = new Book(title, date, authors[i]);
				library.AddBook(book);
				Console.WriteLine("Створено книгу!");
				ReturnToOptions();
			}
			catch(Exception e)
			{
				ReturnToOptions();
			}
		}
		public void TrashBook()
		{
			try
			{
				Console.WriteLine("Введіть назву книги");
				string title = Console.ReadLine();
				Book book = library.Find(title);
				if (book != null)
				{
					library.RemoveBook(book);
					Console.WriteLine("Успішно видалено книгу");
					ReturnToOptions();
				}
				Console.WriteLine("Такої книги не знайдено");
				ReturnToOptions();
			}
			catch(Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void AddAuthor()
		{
			try
			{
				Console.WriteLine("Введіть ім'я");
				string name = Console.ReadLine();
				Console.WriteLine("Введіть дату народження");
				int birthdate = int.Parse(Console.ReadLine());
				Author author;
				Console.WriteLine("Чи живий ще автор? 1 - ні, 2 - так");
				switch (Console.ReadLine())
				{
					case "1":
						Console.WriteLine("Введіть дату смерті");
						int deathdate = int.Parse(Console.ReadLine());
						author = new Author(name, birthdate, deathdate);
						authors.Add(author);
						Console.WriteLine();
						break;
					case "2":
						author = new Author(name, birthdate);
						authors.Add(author);
						Console.WriteLine("Додано автора!");
						break;
					default:
						throw new Exception("Неможлива опція");
				}
				ReturnToOptions();
			}
			catch (Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void UserOperations()
		{
			try
			{
				Console.WriteLine("Виберіть опцію:\n1 - Додати користувача\n2 - Обрати користувача\n3 - Дії з обраним користувачем");
				switch (Console.ReadLine())
				{
					case "1":
						Console.WriteLine("Введіть ім'я користувача");
						string title = Console.ReadLine();
						Console.WriteLine("Введіть дату народження");
						int birthdate = int.Parse(Console.ReadLine());
						Console.WriteLine("Введіть email адресу");
						string email = Console.ReadLine();
						users.Add(new User(title, birthdate, email));
						Console.WriteLine("Створено користувача!");
						break;
					case "2":
						Console.WriteLine("Виберіть користувача за індексом");
						int i = 0;
						foreach (User user in users)
						{
							Console.WriteLine(i + " - " + user.Name);
						}
						i = int.Parse(Console.ReadLine());
						currentuser = users[i];
						Console.WriteLine($"Обрано користувача {currentuser.Name}");
						break;
					case "3":
						CurrentUserOperation();
						break;
					default:
						throw new Exception("Немає такої опції");
				}
				ReturnToOptions();
			}
			catch(Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void CurrentUserOperation()
		{
			try
			{
				Console.WriteLine("Виберіть опцію:\n1 - Позичити книгу\n2 - Віддати книгу\n3 - Вивести інформацію про користувача");
				string title;
				switch (Console.ReadLine())
				{
					case "1":
						Console.WriteLine("Введіть назву книги");
						title = Console.ReadLine();
						Book book = library.Find(title);
						if (book != null)
						{
							currentuser.TakeBook(book);
							library.RemoveBook(book);
							Console.WriteLine("Взято книгу");
							break;
						}
						throw new Exception("Не знайдено книги з такою назвою");
					case "2":
						Console.WriteLine("Введіть назву книги");
						title = Console.ReadLine();
						Book temp = currentuser.ReturnBook(title);
						if (temp != null)
						{
							library.AddBook(temp);
							Console.WriteLine("Повернено книгу");
							break;
						}
						throw new Exception("Не знайдено книги з такою назвою");
					case "3":
						currentuser.PrintToDisplay();
						break;
					default:
						throw new Exception("Немає такої опції");
				}
				ReturnToOptions();
			}
			catch (Exception ex) { ReturnToOptions(ex); }
		}
		public void SeeBooksInLibrary()
		{
			library.PrintToDisplay();
			ReturnToOptions();
		}
		public void ReturnToOptions()
		{
			Console.WriteLine("\nНатисніть будь яку кнопку");
			Console.ReadLine();
			Console.Clear();
			Options();
		}
		public void ReturnToOptions(Exception ex)
		{
			Console.WriteLine(ex.Message);
			ReturnToOptions();
		}
		public void Exit()
		{
			Environment.Exit(0);
		}
	}
}
