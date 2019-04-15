using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GerenciaTaller.Models;
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
			catch (MySqlException ex)
			{
				databaseConnection.Close();
				return false;
			}
			return true;
		}

		public List<Producto> ConsultarProductos(string select)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			List<Producto> lista = new List<Producto>();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							lista.Add(new Producto(reader.GetInt32(0), reader.GetString(1), 
								reader.GetString(2), reader.GetInt32(3), new Categoria(reader.GetString(4)),
								reader.GetBoolean(5), this.ConsultarInventario(reader.GetInt32(0))));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return lista;
		}

		private int ConsultarInventario(int codigoProducto)
		{
			string select = "select * from Inventario where codigoProducto = " + codigoProducto;
			int cantidad = 0;
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							cantidad = reader.GetInt32(1);
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return cantidad;
		}

		public List<Servicio> ConsultarServicios(string select)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			List<Servicio> lista = new List<Servicio>();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							lista.Add(new Servicio(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetBoolean(4)));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return lista;
		}

		public List<Categoria> ConsultarCategorias(string select)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			List<Categoria> lista = new List<Categoria>();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							lista.Add(new Categoria(reader.GetString(0), reader.GetString(1), new Familia(reader.GetString(2)), reader.GetBoolean(3)));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return lista;
		}

		public List<Familia> ConsultarFamilias(string select)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			List<Familia> lista = new List<Familia>();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							lista.Add(new Familia(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2)));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return lista;
		}

		public int GetMayor(string columna, string tabla)
		{
			string select = "select ifnull(max(" + columna + "), 0) from " + tabla;
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			int mayor = -1;
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							mayor = reader.GetInt32(0);
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return mayor;			
		}

		public bool Eliminar(string tabla, string columna, string valor)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			string update = "update " + tabla + " set borrado = true where " + columna + " = " + valor;
			MySqlCommand commandDatabase = new MySqlCommand(update, databaseConnection);
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

		public bool Actualizar(string update)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(update, databaseConnection);
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

		public bool AgregarBitacora(string tabla, string valor)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			string insert = "insert into " + tabla + " Values (" + valor + ", now())";
			MySqlCommand commandDatabase = new MySqlCommand(insert, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			try
			{
				databaseConnection.Open();
				MySqlDataReader myReader = commandDatabase.ExecuteReader();
				databaseConnection.Close();
			}
			catch (MySqlException ex)
			{
				databaseConnection.Close();
				return false;
			}
			return true;
		}

		public List<BitacoraBorrado> ConsultarBitacoras()
		{
			string select = "select * from ";
			string[] tablas = {"BitacoraBorradoFamilias", "BitacoraBorradoCategorias", "BitacoraBorradoProductos",
				"BitacoraBorradoServicios" };
			List<BitacoraBorrado> lista = new List<BitacoraBorrado>();
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			for(int i = 0;  i < tablas.Length; i++)
			{
				MySqlCommand commandDatabase = new MySqlCommand(select + tablas[i], databaseConnection);
				commandDatabase.CommandTimeout = timeOut;
				try
				{
					databaseConnection.Open();
					MySqlDataReader reader = commandDatabase.ExecuteReader();
					if (reader != null)
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								lista.Add(new BitacoraBorrado(tablas[i] + ": " + reader.GetString(0), 
									reader.GetDateTime(1)));
							}
						}
					}
					databaseConnection.Close();
				}
				catch (Exception ex)
				{
					databaseConnection.Close();
				}
			}
			return lista;
		}

		public List<OrdenDeCompra> ConsultarOrdenes(string select)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			List<OrdenDeCompra> lista = new List<OrdenDeCompra>();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							lista.Add(new OrdenDeCompra(reader.GetInt32(0), new Usuario(reader.GetInt32(1)), 
								new Vehiculo(reader.GetInt32(2)), reader.GetString(3), 
								this.ConsultarProductosPorOrden(reader.GetInt32(0)), 
								this.ConsultarServiciosPorOrden(reader.GetInt32(0)), reader.GetInt32(4), 
								reader.GetDateTime(5)));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return lista;
		}

		private List<Producto> ConsultarProductosPorOrden(int codigoOrden)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			string select = "Select * from ProductosPorOrdenDeCompra where codigoOrden = " + codigoOrden;
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			List<Producto> lista = new List<Producto>();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							lista.Add(this.ConsultarProductoPorCodigo(reader.GetInt32(1)));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return lista;
		}

		private Producto ConsultarProductoPorCodigo(int codigo)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			string select = "Select * from Producto where codigo = " + codigo;
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			Producto producto = new Producto();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							producto = new Producto(reader.GetInt32(0), reader.GetString(1),
								reader.GetString(2), reader.GetInt32(3), new Categoria(reader.GetString(4)),
								reader.GetBoolean(5), this.ConsultarInventario(reader.GetInt32(0)));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return producto;
		}

		private List<Servicio> ConsultarServiciosPorOrden(int codigoOrden)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			string select = "Select * from ServiciosPorOrdenDeCompra where codigoOrden = " + codigoOrden;
			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			List<Servicio> lista = new List<Servicio>();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							lista.Add(this.ConsultarServicioPorCodigo(reader.GetInt32(1)));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return lista;
		}

		private Servicio ConsultarServicioPorCodigo(int codigo)
		{
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			string select = "Select * from Servicios where codigo = " + codigo;
 			MySqlCommand commandDatabase = new MySqlCommand(select, databaseConnection);
			commandDatabase.CommandTimeout = timeOut;
			Servicio servicio = new Servicio();
			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				if (reader != null)
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							servicio = new Servicio(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetBoolean(4));
						}
					}
				}
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				databaseConnection.Close();
			}
			return servicio;
		}
	}
}