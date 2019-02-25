using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GerenciaTaller.DataBase
{
	public class Query
	{
		private string connectionString;
		private int timeOut;

		public Query()
		{
			this.connectionString = "datasource=sql9.freemysqlhosting.net;port=3306;username=sql9279347;password=vQZknnhVkp;database=sql9279347;";
			this.timeOut = 180;
		}

		public bool Agregar(string insert)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(insert, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
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

		public MySqlDataReader Consultar(string select)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			MySqlDataReader reader;
			try
			{
				databaseConnection.Open();
				reader = commandDatabase.ExecuteReader();
				databaseConnection.Close();
				return reader;
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return null;
		}
	}
}