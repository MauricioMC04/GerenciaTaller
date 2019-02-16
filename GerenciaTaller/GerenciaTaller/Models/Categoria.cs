using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class Categoria
	{
		private string nombre;
		private string descripcion;
		private Familia familia;

		public Categoria()
		{
		}

		public Categoria(string _nombre, string _descripcion, Familia _familia)
		{
			this.nombre = _nombre;
			this.descripcion = _descripcion;
			this.familia = _familia;
		}

		public string GetNombre()
		{
			return this.nombre;
		}

		public bool AgregarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string insert = "INSERT INTO Categorias VALUES ('" + this.nombre + "', '" + this.descripcion + "'" +
				", '" + this.familia.GetNombre() + "')";
			return dataBase.Agregar(insert);
		}
	}
}