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
			Producto p = new Producto(3, "Producto 4", "Descripcion 4", 1000, new Categoria("Categoria 1"), false);
			p.Eliminar();
			DataBase.Query s = new DataBase.Query();
			List<BitacoraBorrado> lista = s.ConsultarBitacoras();
			int a = 0;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
			return View();
		}
        public ActionResult Familia()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult FamiliasAgregar()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult CategoriasAgregar()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}

        public ActionResult GuardarFamilia(FormCollection form)
        {
            var nombre = form["txtNombre"];
            var descripcion = form["txtDescripcion"];
            Models.Familia familia = new Models.Familia(nombre, descripcion);
            //if (!familia.Existe())
            //{
            familia.AgregarDataBase();
            return View("Index");
            //}
        }

        public ActionResult GuardarCategoria(FormCollection form)
        {
            var familia = form["txtFamilia"];
            var nombre = form["txtNombre"];
            var descripcion = form["txtDescripcion"];
            Models.Categoria categoria = new Models.Categoria(nombre, descripcion, new Models.Familia(familia));
            //if (!categoria.Existe())
            //{
            categoria.AgregarDataBase();
            return View("Index");
            //}
        }
    }
}