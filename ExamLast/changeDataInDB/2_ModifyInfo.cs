using System;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamLast
{
    class ModifyInfo
    {
		public void Modifying(SqlConnection con)
		{
			try
			{
				SqlCommand command = new SqlCommand();
				bool queryNotReady = true;
				while (queryNotReady)
				{
					Console.WriteLine("Enter table name:");
					string table_name = Console.ReadLine();

					Console.WriteLine("Enter changes for colums:");
					string changes = Console.ReadLine();
					Console.WriteLine("Enter condition :");
					string condition = Console.ReadLine();
					command.CommandText = "UPDATE  " + table_name + "\nSET "+ changes+ "\nWHERE "+ condition+";";
					Console.WriteLine("Yor query:");
					Console.WriteLine(command.CommandText);
					Console.WriteLine("Would you like to change query?(true/false)");
					string temp = Console.ReadLine();
					bool.TryParse(temp, out queryNotReady);
				}
				con.Open();
				command.Connection = con;
				int number = command.ExecuteNonQuery();
				con.Close();
				Console.WriteLine("Изменено объектов: {0}", number);
			}
			catch
			{
				Console.WriteLine("Uncorrect data entered");
			}
		}
	}

}