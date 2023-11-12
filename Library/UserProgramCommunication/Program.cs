using System.Text;
using Library.UserProgramCommunication;

namespace Library
{
	public class Program
	{
		public static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;
			new Communication().Options();
		}
	}
}