using System;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamLast
{
	class DateOut
	{
		
		public void Selection(SqlConnection con)
		{
			try
			{
				SqlCommand command = new SqlCommand();
				bool queryNotReady = true;
				while (queryNotReady)
				{
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
						colums = "*";
					}
					Console.WriteLine("Enter table name:");
					string table_name = Console.ReadLine();
					Console.WriteLine("Would you like use condiotion colums?(true/false)");
					temp = Console.ReadLine();
					string condiotion;
					bool.TryParse(temp, out choose);
					if (choose)
					{
						Console.WriteLine("Enter condiotion:");
						condiotion = Console.ReadLine();
						condiotion = "WHERE "+ condiotion;
					}
					else
					{
						condiotion = "";
					}
					//bool choose = Convert.ToBoolean();
					Console.WriteLine("Enter values :");
					string values = Console.ReadLine();
					command.CommandText = "SELECT " + colums + " FROM " + table_name + " " + condiotion;
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
		public void UserRequest(SqlConnection con)
		{
			try
			{
				SqlCommand command = new SqlCommand();
				Console.WriteLine("Write your own query:");
				command.CommandText = Console.ReadLine();
				con.Open();
				command.Connection = con;
				Console.WriteLine("Non query?(true/false)");
				string temp = Console.ReadLine();
                bool.TryParse(temp, out bool choose);
                if (choose)
				{
					con.Open();
					command.Connection = con;
					int number = command.ExecuteNonQuery();
					con.Close();
					Console.WriteLine("Изменено объектов: {0}", number);
				}
				else
				{
					con.Open();
					command.Connection = con;
					SqlDataReader reader = command.ExecuteReader();
					if (reader.HasRows)
					{
						for (int i = 0; i < reader.FieldCount; i++)
							Console.Write($"{reader.GetName(i)}\t");
						Console.WriteLine();

						while (reader.Read())
						{
							for (int i = 0; i < reader.FieldCount; i++)
								Console.Write($"{reader[i]}\t");
							Console.WriteLine();
						}

						con.Close();
					}
					reader.Close();
				}

			}
			catch
			{
				Console.WriteLine("Uncorrect query");
			}
		}
	}

}