using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GerenciaTaller.DataBase
{
	public class Query
	{
		public bool Agregar(string insert)
		{
			string connectionString = "datasource=sql9.freemysqlhosting.net;port=3306;username=sql9279347;password=vQZknnhVkp;database=sql9279347;";
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(insert, databaseConnection);
			commandDatabase.CommandTimeout = 180;
			try
			{
				databaseConnection.Open();
				MySqlDataReader myReader = commandDatabase.ExecuteReader();
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
				return false;
			}
			return true;
		}
	}
}