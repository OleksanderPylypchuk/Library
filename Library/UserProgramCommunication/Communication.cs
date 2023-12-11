using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BackEnd;
using Library.BackEnd.Interfaces;

namespace Library.UserProgramCommunication
{
	public class Communication
	{
		public BookLibrary library;
		public List<User> users;
		public List<Author> authors;
		public User currentuser;
		public delegate void ShowMessage(string message);
		public event ShowMessage showMessage;
		public delegate string? GetData();
		public GetData getData;
		public event Action Start;
		public Communication()
		{
			library = new BookLibrary();
			users = new List<User>();
			authors = new List<Author>();
			showMessage = Console.WriteLine;
			getData = Console.ReadLine;
			Start = Options;
			Start();
		}
		public void Options()
		{
			try
			{
				showMessage("Виберіть опцію:\n1 - Дії з книгами\n2 - Дії з користувачем\n3 - Додати автора\n4 - Переглянути книги у бібліотеці\n5 - Вихід");
				switch (getData())
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
				showMessage("Виберіть опцію:\n1 - Додати книгу\n2 - Передрукувати існуючу книгу\n3 - Викинути книгу");
				switch (getData())
				{
					case "1":
						AddBook();
						break;
					case "2":
						AddBook(1);
						break;
					case "3":
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
				int temp= library.GetCount();
				showMessage("Введіть назву книги");
				string title = getData();
				showMessage("Введіть дату написання");
				int date = int.Parse(getData());
				showMessage("Виберіть автора за індексом"); int i = 0;
				foreach (Author author in authors.Where(u=> u.BirthDate < date && ((u.DeathDate != null && u.DeathDate >= date) || (u.DeathDate == null))))
				{
					showMessage(i + " - " + author.Name);
					i++;
				}
				if (i == 0)
					throw new Exception("Немає доступних авторів");
				i = int.Parse(getData());
				if (i>=authors.Count)
					throw new Exception("Немає такого автора");
				Book book = new Book(title, date, authors[i]);
				library.AddBook(book);
				if (temp==library.GetCount())
					throw new Exception("Книгу не додано");	
				showMessage("Створено книгу!");
				ReturnToOptions();
			}
			catch(Exception e)
			{
				ReturnToOptions(e);
			}
		}
		public void AddBook(int i)
		{
			try
			{
				showMessage("Введіть назву книги");
				string title = getData();
				Book bookToClone = library.Find(title);
				if (bookToClone == null) 
					throw new Exception("Немає такої книги");
				Book bookToAdd = (Book)bookToClone.Clone();
				library.AddBook(bookToAdd);
				showMessage("Клоновано книгу!");
				ReturnToOptions();
			}
			catch (Exception e)
			{
				ReturnToOptions(e);
			}
		}
		public void TrashBook()
		{
			try
			{
				showMessage("Введіть назву книги");
				string title = getData();
				Book book = library.Find(title);
				if (book != null)
				{
					library.RemoveBook(book);
					showMessage("Успішно видалено книгу");
					ReturnToOptions();
				}
				showMessage("Такої книги не знайдено");
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
				showMessage("Введіть ім'я");
				string name = getData();
				showMessage("Введіть дату народження");
				int birthdate = int.Parse(getData());
				Author author;
				showMessage("Чи живий ще автор? 1 - ні, 2 - так");
				switch (getData())
				{
					case "1":
						showMessage("Введіть дату смерті");
						int deathdate = int.Parse(getData());
						author = new Author(name, birthdate, deathdate);
						authors.Add(author);
						showMessage("Додано автора!");
						break;
					case "2":
						author = new Author(name, birthdate);
						authors.Add(author);
						showMessage("Додано автора!");
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
				showMessage("Виберіть опцію:\n1 - Додати користувача\n2 - Обрати користувача\n3 - Дії з обраним користувачем");
				switch (getData())
				{
					case "1":
						showMessage("Введіть ім'я користувача");
						string name = getData();
						showMessage("Введіть дату народження");
						int birthdate = int.Parse(getData());
						showMessage("Введіть email адресу");
						string email = getData();
						if (birthdate >= 2010)
							users.Add(new YoungUser(name, birthdate, email));
						else users.Add(new User(name, birthdate, email));
						showMessage("Створено користувача!");
						break;
					case "2":
						showMessage("Виберіть користувача за індексом");
						int i = 0;
						foreach (User user in users)
						{
							showMessage(i + " - " + user.Name);
							i++;
						}
						i = int.Parse(getData());
						if (i >= users.Count || users[i] == null)
							throw new Exception("Немає такого користувача");
						currentuser = users[i];
						showMessage($"Обрано користувача {currentuser.Name}");
						break;
					case "3":
						if (currentuser==null)
							throw new Exception("Не обрано користувача");
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
				showMessage("Виберіть опцію:\n1 - Позичити книгу\n2 - Віддати книгу\n3 - Вивести інформацію про користувача");
				string title;
				switch (getData())
				{
					case "1":
						if(currentuser==null)
							throw new Exception("Немає такого користувача");
						showMessage("Введіть назву книги");
						title = getData();
						Book book = library.Find(title);
						if (book != null)
						{
							currentuser.TakeBook(book);
							library.RemoveBook(book);
							showMessage("Взято книгу");
							break;
						}
						throw new Exception("Не знайдено книги з такою назвою");
					case "2":
						showMessage("Введіть назву книги");
						title = getData();
						Book temp = currentuser.ReturnBook(title);
						if (temp != null)
						{
							library.AddBook(temp);
							showMessage("Повернено книгу");
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
			showMessage(library.RetrieveBookNames());
			ReturnToOptions();
		}
		public void ReturnToOptions()
		{
			showMessage("\nНатисніть будь яку кнопку");
			getData();
			Console.Clear();
			Start();
		}
		public void ReturnToOptions(Exception ex)
		{
			showMessage(ex.Message);
			ReturnToOptions();
		}
		public void Exit()
		{
			Environment.Exit(0);
		}
	}
}
