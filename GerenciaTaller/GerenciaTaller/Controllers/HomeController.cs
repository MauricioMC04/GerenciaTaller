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
			Producto producto = new Producto();
			List<Producto> list = producto.ConsultarDataBase();
			Categoria categoria = new Categoria();
			List<Categoria> listCat = categoria.ConsultarDataBase();
			Servicio servicio = new Servicio();
			List<Servicio> listSer = servicio.ConsultarDataBase();
			Familia familia = new Familia();
			List<Familia> listFa = familia.ConsultarDataBase();
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