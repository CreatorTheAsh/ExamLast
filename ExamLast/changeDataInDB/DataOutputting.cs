using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.ExceptionServices;

namespace ExamLast
{
	class DataOutput
	{
		static public void DataOutputting(SqlCommand command, SqlConnection con)
		{
			try
			{
				con.Open();
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
			catch
			{
				Console.WriteLine("Uncorrect data entered");
			}
		}
	}
}
		