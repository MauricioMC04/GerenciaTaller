using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class Familia
	{
		private string nombre;
		private string descripcion;
		private bool borrado; 

		public Familia()
		{
		}

		public Familia(string _nombre, string _descripcion, bool _borrado)
		{
			this.nombre = _nombre;
			this.descripcion = _descripcion;
			this.borrado = _borrado;
		}

		public Familia(string _nombre, bool _borrado)
		{
			this.nombre = _nombre;
            this.borrado = _borrado;  
		}

        public Familia(string _nombre)
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

		public bool GetBorrado()
		{
			return this.borrado;
		}

		public bool AgregarDataBase()
		{
			if (!this.Existe())
			{
				DataBase.Query dataBase = new DataBase.Query();
				string insert = "INSERT INTO Familias VALUES ('" + this.nombre + "', '" + this.descripcion + "', " + this.borrado + ")";
				return dataBase.Agregar(insert);
			}
			return false;
		}

		public List<Familia> ConsultarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string select = "SELECT * From Familias where borrado = false";
			List<Familia> lista = dataBase.ConsultarFamilias(select);
			return lista;
		}

		public bool Existe()
		{
			if (!this.nombre.Equals(""))
			{
				DataBase.Query dataBase = new DataBase.Query();
				string select = "SELECT * From Familias where nombre = '" + this.nombre + "'";
				List<Familia> lista = dataBase.ConsultarFamilias(select);
				return lista.Count > 0;
			}
			return true;
		}

		public bool Eliminar()
		{
			DataBase.Query dataBase = new DataBase.Query();
			return dataBase.Eliminar("Familias", "nombre", "'" + this.nombre + "'") && 
				dataBase.AgregarBitacora("BitacoraBorradoFamilias", "'" + this.nombre + "'");
		}

		public bool Actualizar(string descripcion)
		{
			DataBase.Query dataBase = new DataBase.Query();
			string update = "update Familias set descripcion = '" + descripcion + "' where nombre = '" + this.nombre + "'";
			return dataBase.Actualizar(update);
		}
	}
}