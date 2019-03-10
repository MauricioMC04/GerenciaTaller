using GerenciaTaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciaTaller.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			Producto p = new Producto(4, "Producto 4", "Descripcion 4", 1000, new Categoria("Categoria 1"), false);
			bool s = p.ActualizarInventario(70);
			bool d = p.Actualizar("Producto 4 Editado", "Descripcion 4 Editado", 9999);
			int a = 0;
			return View();	
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}
	}
}