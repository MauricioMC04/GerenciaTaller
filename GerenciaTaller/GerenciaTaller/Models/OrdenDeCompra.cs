using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class OrdenDeCompra
	{
		private int codigo; 
		private Usuario usuario;
		private Vehiculo vehiculo;
		private string descripcion;
		private List<Producto> productos;
		private List<Servicio> servicios;
		private int total;
		private DateTime fecha;

		public OrdenDeCompra() { }

		public OrdenDeCompra(int _codigo, Usuario _usuario, Vehiculo _vehiculo, string _descripcion, 
			List<Producto> _productos, List<Servicio> _servicios, int _total, DateTime _fecha)
		{
			this.codigo = _codigo;
			this.usuario = _usuario;
			this.vehiculo = _vehiculo;
			this.descripcion = _descripcion;
			this.productos = _productos;
			this.servicios = _servicios;
			this.total = _total;
			this.fecha = _fecha;
		}

		public List<OrdenDeCompra> CosultarOrdenes()
		{
			DataBase.Query query = new DataBase.Query();
			return query.ConsultarOrdenes("Select * from OrdenesDeCompra");
		}

		public bool AgregarDataBase()
		{
			DataBase.Query query = new DataBase.Query();
			string insert = "Insert into OrdenesDeCompra values(" + 
				(query.GetMayor("codigo", "OrdenesDeCompra") + 1) + ", " + this.usuario.GetCodigo() + ", " +
				this.vehiculo.GetCodigo() + ", '" + this.descripcion + "', " + this.total + ", " + 
				this.fecha + ")";
			if (query.Agregar(insert))
			{
				foreach(Producto producto in this.productos)
				{
					insert = "Insert into ProductosPorOrdenDeCompra values(" +
						(query.GetMayor("codigo", "OrdenesDeCompra") + 1) + ", " + producto.GetCodigo() + 
						")";
					if (!query.Agregar(insert))
					{
						return false;
					}
				}
				foreach (Servicio servicio in this.servicios)
				{
					insert = "Insert into ServiciosPorOrdenDeCompra values(" +
						(query.GetMayor("codigo", "OrdenesDeCompra") + 1) + ", " + servicio.GetCodigo() +
						")";
					if (!query.Agregar(insert))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}
}