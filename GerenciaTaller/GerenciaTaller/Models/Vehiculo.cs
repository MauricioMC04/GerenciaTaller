using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class Vehiculo
	{
		private int codigo;

		public Vehiculo() { }

		public Vehiculo(int _codigo)
		{
			this.codigo = _codigo;
		}

		public int GetCodigo()
		{
			return this.codigo;
		}
	}
}