using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLast
{
	class Facade
	{
		ConnectionString connectionString = new ConnectionString();
		
		public Facade() {}
		public void MenuCommand()
        {
			bool goWork = true;
			while (goWork)
			{
				Console.WriteLine("1.Add Data");
				Console.WriteLine("2.Modify Data");
				Console.WriteLine("3.Delete Data");
				Console.WriteLine("4.Select Data");
				Console.WriteLine("5.Use own query");
				Console.WriteLine("6.Get preseted queres");
				Console.WriteLine("7.Exit");
				string temp = Console.ReadLine();
				int.TryParse(temp, out int choose);
				switch (choose)
				{
					case 1:
						AddInfo add = new AddInfo();
						add.Adding(connectionString.GetCurrentConnection());
						break;
					case 2:
						ModifyInfo modify = new ModifyInfo();
						modify.Modifying(connectionString.GetCurrentConnection());
						break;
					case 3:
						DeleteInfo delete = new DeleteInfo();
						delete.Delet(connectionString.GetCurrentConnection());
						break;
					case 4:
						DateOut dateOutSELECT = new DateOut();
						dateOutSELECT.Selection(connectionString.GetCurrentConnection());
						break;
					case 5:
						DateOut dateOutREQUEST = new DateOut();
						dateOutREQUEST.UserRequest(connectionString.GetCurrentConnection());
						break;
					case 6:
						GetInfo getInfo = new GetInfo();
						getInfo.Presets(connectionString.GetCurrentConnection());
						break;
					case 7:
						goWork = false;
						break;
					default:
						Console.WriteLine("Uncorrected input, auto exit");
						goWork = false;
						break;
				}
			}
		}
		
	}
		
}
