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
            Familia familia = new Familia();
            Consulta consulta = new Consulta(familia.ConsultarDataBase());
            int a = 0;
            return View(consulta);
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
            Models.Familia familia = new Models.Familia(nombre, descripcion, false);
            //if (!familia.Existe())
            //{
            familia.AgregarDataBase();
            return View("Index");
            //}
        }

        public ActionResult GuardarCategoria(FormCollection form)
        {
            var familia = form["cmbFamilias"];
            var nombre = form["txtNombre"];
            var descripcion = form["txtDescripcion"];
            Models.Categoria categoria = new Models.Categoria(nombre, descripcion, new Models.Familia(familia, false), false);
            if (!categoria.Existe())
            {
                categoria.AgregarDataBase();
            }
            return View("Index");
        }

        public ActionResult ProductosAgregar()
        {
            Models.Categoria cat = new Categoria();
            List<Categoria> lisC = cat.ConsultarDataBase();
            var model = lisC;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductosAgregar(FormCollection form)
        {
            try
            {
                var cod = int.Parse(form["txtCod"]);
                var pre = int.Parse(form["txtPrecio"]);
                var categoria = form["cmbCategorias"];
                Models.Categoria cat = new Categoria(categoria);
                var nombre = form["txtNombre"];
                var descripcion = form["txtDescripcion"];
                Models.Producto prod = new Producto(cod, nombre, descripcion, pre, cat, false);
                var res = prod.AgregarDataBase(0);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult ServiciosAgregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServiciosAgregar(FormCollection form)
        {
            try
            {
                var cod = int.Parse(form["txtCod"]);
                var pre = int.Parse(form["txtPrecio"]);
                var nombre = form["txtNombre"];
                var descripcion = form["txtDescripcion"];
                Models.Servicio ser = new Servicio(cod, nombre, descripcion, pre, false);
                ser.AgregarDataBase();
                return RedirectToAction("Index");
            }
            catch { return RedirectToAction("Index"); }
        }
    }
}