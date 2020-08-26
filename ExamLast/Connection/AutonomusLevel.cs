using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ExamLast
{
	class AutonomusLevel
	{
		SqlCommand Command;
		DataSet DataBaseSet = new DataSet();
		public AutonomusLevel(SqlCommand Command)
		{
			this.Command = Command;
		}
		public AutonomusLevel() { }
		public void LoadDataFromDB()
		{
			try
			{
				if (Command == null)
				{
					Console.WriteLine("Empty command");
				}
				else
				{
					SqlDataAdapter adapter = new SqlDataAdapter(Command);
					adapter.Fill(DataBaseSet);
				}
			}
			catch { Console.WriteLine("Uncorrect comand or corupted connection"); }
		}
	}

}