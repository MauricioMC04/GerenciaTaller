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
		private bool borrado;

		public Categoria()
		{
		}

		public Categoria(string _nombre, string _descripcion, Familia _familia, bool _borrado)
		{
			this.nombre = _nombre;
			this.descripcion = _descripcion;
			this.familia = _familia;
			this.borrado = _borrado;
		}

		public Categoria(string _nombre)
		{
			this.nombre = _nombre;
		}

		public string GetNombre()
		{
			return this.nombre;
		}

		public string GetDescripcion()
		{
			return this.descripcion;
		}

		public Familia GetFamilia()
		{
			return this.familia;
		}

		public bool GetBorrado()
		{
			return this.borrado;
		}

		public bool AgregarDataBase()
		{
			if (!this.Existe())
			{
				DataBase.Query dataBase = new DataBase.Query();
				string insert = "INSERT INTO Categorias VALUES ('" + this.nombre + "', '" + this.descripcion + "', '" + this.familia.GetNombre() + "', " + this.borrado + ")";
				return dataBase.Agregar(insert);
			}
			return false;
		}

		public List<Categoria> ConsultarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string select = "SELECT * From Categorias where borrado = false";
			List<Categoria> lista = dataBase.ConsultarCategorias(select);
			return lista;
		}

		public bool Existe()
		{
			if (!this.nombre.Equals(""))
			{
				DataBase.Query dataBase = new DataBase.Query();
				string select = "SELECT * From Categorias where nombre = '" + this.nombre + "'";
				List<Categoria> lista = dataBase.ConsultarCategorias(select);
				return lista.Count > 0;
			}
			return true;
		}

		public bool Eliminar()
		{
			DataBase.Query dataBase = new DataBase.Query();
			return dataBase.Eliminar("Categorias", "nombre", "'" + this.nombre + "'") &&
				dataBase.AgregarBitacora("BitacoraBorradoCategorias", "'" + this.nombre + "'");
		}

		public bool Actualizar(string descripcionNueva)
		{
			DataBase.Query dataBase = new DataBase.Query();
			string update = "update Categorias set descripcion = '" + descripcionNueva + "' where nombre = '" + this.nombre + "'";
			return dataBase.Actualizar(update);
		}
	}
}