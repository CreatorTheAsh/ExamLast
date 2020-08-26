using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.ExceptionServices;

namespace ExamLast
{
	class GetInfo
	{
		
		public void Presets(SqlConnection con)
		{
			try
			{
				int orderPrice, OrderId;
				Console.WriteLine("enter order price");
				string temp = Console.ReadLine();
				int.TryParse(temp, out orderPrice);
				Console.WriteLine("enter product id");
				temp = Console.ReadLine();
				int.TryParse(temp, out OrderId);
				string s1 = @"select * from Orders
								where 
								OrderPrice < "+ orderPrice + @"
								AND 
								Orders.OrderId=
								(select  OrderId
								   from ProductsInOrder
								   GROUP BY OrderId
								   HAVING COUNT(ProductId) = "+ OrderId + ")";
				Console.WriteLine("First query generated: " + s1);

				int ProductId;
				Console.WriteLine("enter Product Id ");
				temp = Console.ReadLine();
				int.TryParse(temp, out ProductId);
				string s2 = @"SELECT OrderId
								FROM ProductsInOrder
								where ProductId ="+ ProductId;
				Console.WriteLine("Second query generated: " + s2);

				
				string date1, date2;
				Console.WriteLine("enter Order Id ");
				temp = Console.ReadLine();
				int.TryParse(temp, out OrderId);
				Console.WriteLine("First date in format 2000-25-10");
				date1 = Console.ReadLine();
				Console.WriteLine("Second date in format 2000-25-10");
				date2 = Console.ReadLine();
				string s3 = @"select OrderId from Orders
								where OrderId != "+ OrderId + @"
								AND
								Orders.DeliveryDate BETWEEN "+ date1 + " AND "+ date2;//string date
				Console.WriteLine("Thirthd query generated: " + s2);


				string s5 = @"select * from Orders
								where Orders.OrderId=
								(select OrderId from 
								(select TOP 1 COUNT(ProductId) AS quant , OrderId
								from ProductsInOrder
								GROUP BY OrderId
								HAVING max(ProductId)>0
								ORDER BY quant DESC) a)";
				Console.WriteLine("Fifth query generated: " + s2);
				SqlCommand command = new SqlCommand();
				con.Open();
				command.Connection = con;
				con.Close();
				command.CommandText = s1;
				DataOutput.DataOutputting(command, con);
				command.CommandText = s2;
				DataOutput.DataOutputting(command, con);
				command.CommandText = s3;
				DataOutput.DataOutputting(command, con);
				command.CommandText = s5;
				DataOutput.DataOutputting(command, con);

			}
			catch
			{
				Console.WriteLine("Uncorrect data entered");
			}
		}

	}

}