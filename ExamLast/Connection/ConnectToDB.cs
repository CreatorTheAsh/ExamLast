using System;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamLast
{
    class ConnectionString
    {
        private string currentString;
        private SqlConnection connection;
        public ConnectionString()
        {
            currentString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(currentString);
        }
        public SqlConnection GetCurrentConnection()
        {
            return connection;
        }
        public void UpdateConnection()
        {
            connection.Close();
            connection.ConnectionString = currentString;
        }
        public void ChangerCurrentString(string key, string value)
        {//change config file;
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
        public void ConnectionInfo()
        {
            connection.Open();
            Console.WriteLine("Подключение открыто");
            // Вывод информации о подключении
            Console.WriteLine("Свойства подключения:");
            Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
            Console.WriteLine("\tБаза данных: {0}", connection.Database);
            Console.WriteLine("\tСервер: {0}", connection.DataSource);
            Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
            Console.WriteLine("\tСостояние: {0}", connection.State);
            Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
            connection.Close();
            Console.WriteLine("Подключение закрыто...");
        }
    }
}
