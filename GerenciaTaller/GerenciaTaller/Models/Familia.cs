﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
	public class Familia
	{
		private string nombre;
		private string descripcion;

		public Familia()
		{
		}

		public Familia(string _nombre, string _descripcion)
		{
			this.nombre = _nombre;
			this.descripcion = _descripcion;
		}

		public String GetNombre()
		{
			return this.nombre;
		}

		public bool AgregarDataBase()
		{
			DataBase.Query dataBase = new DataBase.Query();
			string insert = "INSERT INTO Familias VALUES ('" + this.nombre + "', '" + this.descripcion + "')";
			return dataBase.Agregar(insert);
		}
	}
}