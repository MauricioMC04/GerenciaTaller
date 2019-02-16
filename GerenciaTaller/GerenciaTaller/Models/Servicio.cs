using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class Servicio
	{
		private int codigo;
		private string nombre;
		private string descripcion;
		private int precio;

		public Servicio()
		{
		}

		public Servicio(int _codigo, string _nombre, string _descripcion, int _precio)
		{
			this.codigo = _codigo;
			this.nombre = _nombre;
			this.descripcion = _descripcion;
			this.precio = _precio;
		}

		public bool AgregarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string insert = "INSERT INTO Servicios VALUES (" + this.codigo + ", '" + this.nombre + "', '" + 
				this.descripcion + "', " + this.precio + ")";
			return dataBase.Agregar(insert);
		}
	}
}