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
		private bool borrado;

		public Servicio()
		{
		}

		public Servicio(int _codigo, string _nombre, string _descripcion, int _precio, bool _borrado)
		{
			this.codigo = _codigo;
			this.nombre = _nombre;
			this.descripcion = _descripcion;
			this.precio = _precio;
			this.borrado = _borrado;
		}

		public Servicio(int _codigo, string _nombre)
		{
			this.codigo = _codigo;
			this.nombre = _nombre;
		}

		public int GetCodigo()
		{
			return this.codigo;
		}

		public string GetNombre()
		{
			return this.nombre;
		}

		public string GetDescripcion()
		{
			return this.descripcion;
		}

		public int GetPrecio()
		{
			return this.precio;
		}

		public bool GetBorrado()
		{
			return this.borrado;
		}

		public bool AgregarDataBase()
		{
			if (!this.Existe())
			{
				Producto producto = new Producto(-1, this.nombre);
				if (!producto.Existe())
				{
					int mayorProducto = this.GetCodigoMayor("codigo", "Producto");
					int mayorServicio = this.GetCodigoMayor("codigo", "Servicios");
					this.codigo = (mayorProducto > mayorServicio) ? mayorProducto + 1 : mayorServicio + 1;
					DataBase.Query dataBase = new DataBase.Query();
					string insert = "INSERT INTO Servicios VALUES (" + this.codigo + ", '" + this.nombre + "', '" + this.descripcion + "', " + this.precio + ", " + this.borrado + ")";
					return dataBase.Agregar(insert);
				}
			}
			return false;
		}

		public List<Servicio> ConsultarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string select = "SELECT * From Servicios borrado = false";
			List<Servicio> lista = dataBase.ConsultarServicios(select);
			return lista;
		}

		public bool Existe()
		{
			if (!this.nombre.Equals(""))
			{
				DataBase.Query dataBase = new DataBase.Query();
				string select = "SELECT * From Servicios where nombre = '" + this.nombre + "'";
				List<Servicio> lista = dataBase.ConsultarServicios(select);
				return lista.Count > 0;
			}
			return true;
		}

		public int GetCodigoMayor(string columna, string tabla)
		{
			DataBase.Query dataBase = new DataBase.Query();
			return dataBase.GetMayor(columna, tabla);
		}

		public bool Eliminar()
		{
			DataBase.Query dataBase = new DataBase.Query();
			return dataBase.Eliminar("Serivicios", "codigo", this.codigo.ToString()) &&
				dataBase.AgregarBitacora("BitacoraBorradoServicios", this.codigo.ToString());
		}

		public bool Actualizar(string nombreNuevo, string descripcionNueva, int precio)
		{
			DataBase.Query dataBase = new DataBase.Query();
			string update = "update Servicios set nombre = '" + nombreNuevo + "', descripcion = '" + descripcionNueva + "', precio = " + precio.ToString() + " where codigo = " + this.codigo;
			return dataBase.Actualizar(update);
		}
	}
}