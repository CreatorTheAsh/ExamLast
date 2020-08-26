using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLast
{
	class Program
	{
		public static void Main()
		{
			try
			{
				Facade facade = new Facade();
				facade.MenuCommand();

				Console.ReadKey();

			}
			catch
			{
				Console.WriteLine("Something gone wrong.");
				Console.ReadKey();
			}
		}
	}
}
