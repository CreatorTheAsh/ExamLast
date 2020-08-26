using System;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamLast
{
	class AddInfo
	{
		public void Adding(SqlConnection con)
		{
			try
			{
				SqlCommand command = new SqlCommand();
				bool queryNotReady = true;
					while (queryNotReady) {
					Console.WriteLine("Enter table name:");
					string table_name = Console.ReadLine();

					Console.WriteLine("Would you like to choose colums?(true/false)");
					string temp = Console.ReadLine();
					string colums;
                    bool.TryParse(temp, out bool choose);
                    if (choose)
					{
						Console.WriteLine("Enter colums");
						colums = Console.ReadLine();
						colums = "(" + colums + ")";
					}
					else
					{
						colums = "";
					}
					//bool choose = Convert.ToBoolean();
					Console.WriteLine("Enter values :");
					string values = Console.ReadLine();
					command.CommandText = "INSERT INTO " + table_name + colums + "\nVALUES " + "(" + values + ");";
					Console.WriteLine("Yor query:");
					Console.WriteLine(command.CommandText);
					Console.WriteLine("Would you like to change query?(true/false)");
					temp = Console.ReadLine();
					bool.TryParse(temp, out queryNotReady);
				}
				con.Open();
				command.Connection = con;
				int number = command.ExecuteNonQuery();
				con.Close();
				Console.WriteLine("Добавлено объектов: {0}", number);
			}
			catch
			{
				Console.WriteLine("Uncorrect data entered");
			}
		}
	}

}