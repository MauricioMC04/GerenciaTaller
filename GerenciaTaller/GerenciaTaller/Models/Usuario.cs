using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class Usuario
	{
		private int codigo;

		public Usuario() { }

		public Usuario(int _codigo)
		{
			this.codigo = _codigo;
		}

		public int GetCodigo()
		{
			return this.codigo;
		}
	}
}