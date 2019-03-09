using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class Producto
	{
		private int codigo;
		private string nombre;
		private string descripcion;
		private int precio;
		private Categoria categoria;

		public Producto()
		{
		}

		public Producto(int _codigo, string _nombre, string _descripcion, int _precio, Categoria _categoria)
		{
			this.codigo = _codigo;
			this.nombre = _nombre;
			this.descripcion = _descripcion;
			this.precio = _precio;
			this.categoria = _categoria;
		}

		public int GetCodigo()
		{
			return codigo;
		}

		public string GetNombre()
		{
			return nombre;
		}
			
		public string GetDescripcion()
		{
			return descripcion;
		}
			
		public int GetPrecio()
		{
			return precio;
		}
			
		public Categoria GetCategoria()
		{
			return categoria;
		}

		public bool AgregarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string insert = "INSERT INTO Producto VALUES (" + this.codigo + ", '" + this.nombre + "', '" +
				this.descripcion + "', " + this.precio + ", '" + this.categoria.GetNombre() + "')";
			return dataBase.Agregar(insert);
		}

		public List<Producto> ConsultarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string select = "SELECT * From Producto";
			List<Producto> lista = dataBase.ConsultarProductos(select);
			return lista;
		}
	}
}