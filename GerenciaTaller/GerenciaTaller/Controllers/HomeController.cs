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
			Producto p = new Producto(3, "Producto 4", "Descripcion 4", 1000, new Categoria("Categoria 1"), false, 0);
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

        public ActionResult OrdenServicio()
        {
            List<string> l1 = new List<string>();
            Producto prod = new Producto();
            Servicio ser = new Servicio();
            foreach (Producto item in prod.ConsultarDataBase())
            {
                l1.Add(item.GetNombre());
            }
            foreach (Servicio item in ser.ConsultarDataBase())
            {
                l1.Add(item.GetNombre());
            }

            return View(l1);
        }

        public ActionResult Familia()
        {
            ViewBag.Message = "Your application description page.";
            Familia familia = new Familia();
            Consulta consulta = new Consulta(familia.ConsultarDataBase());
            return View(consulta);
        }
        public ActionResult Categoria()
        {
            ViewBag.Message = "Your application description page.";
            Categoria categoria = new Categoria();
            Consulta consulta = new Consulta(categoria.ConsultarDataBase());
            return View(consulta);
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

        //muestra la ventana 
        public ActionResult ProductosAgregar()
        {
            Models.Categoria cat = new Categoria();
            List<Categoria> lisC = cat.ConsultarDataBase();
            var model = lisC;
            return View(model);
        }

        //agrega
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
                Models.Producto prod = new Producto(cod, nombre, descripcion, pre, cat, false, 0);
                var res = prod.AgregarDataBase(0);
                return RedirectToAction("Producto");
            }
            catch
            {
                return RedirectToAction("Producto");
            }

        }
        
        public ActionResult ServiciosAgregar()
        {
            return View();
        }
        //agrega
        [HttpPost]
        public ActionResult ServiciosAgregar(FormCollection form)
        {
            try
            {
                //var cod = int.Parse(form["txtCod"]);
                var pre = int.Parse(form["txtPrecio"]);
                var nombre = form["txtNombre"];
                var descripcion = form["txtDescripcion"];
                Models.Servicio ser = new Servicio(0, nombre, descripcion, pre, false);
                ser.AgregarDataBase();
                return RedirectToAction("Servicio");
            }
            catch { return RedirectToAction("Servicio"); }
        }
        //muestra la ventana 
        public ActionResult Inventario()
        {
            return View();
        }
        //muestra la ventana 
        public ActionResult Producto()
        {
            Models.Producto prod = new Producto();
            Consulta model = new Consulta(prod.ConsultarDataBase());
            return View(model);
        }
        //muestra la ventana 
        public ActionResult Servicio()
        {
            Models.Servicio serv = new Servicio();
            Consulta model = new Consulta(serv.ConsultarDataBase());
            return View(model);
        }

        public ActionResult ProductoEliminar(int id)
        {
            try {
                Models.Producto prod = new Producto(id, "");
                prod.Eliminar();
                return RedirectToAction("Producto");
            } catch { return RedirectToAction("Producto"); }
            
        }

        public ActionResult ServicioEliminar(int id)
        {
            try {
                Models.Servicio ser = new Servicio(id, "");
                ser.Eliminar();
                return RedirectToAction("Servicio");
            } catch { return RedirectToAction("Servicio"); }
            
        }

        public ActionResult FamiliaEliminar(string nombre)
        {

            Models.Familia fam = new Familia(nombre);
            fam.Eliminar();
            return RedirectToAction("Familia");
        }

        public ActionResult CategoriaEliminar(string nombre)
        {


            Models.Categoria cat = new Categoria(nombre);
            cat.Eliminar();
            return RedirectToAction("Categoria");
        }

        public ActionResult ProductosEditar(FormCollection form)
        {
            try
            {
                Models.Producto productoEditar = new Models.Producto(Convert.ToInt32(form["txtCodigo"]));
                productoEditar.Actualizar(form["txtNombre"], form["txtDescripcion"], Convert.ToInt32(form["txtPrecio"]), Convert.ToInt32(form["Cantidad"]));
            }
            catch { }

            Producto producto = new Producto();
            Consulta consulta = new Consulta(producto.ConsultarDataBase());
            return View("Producto", consulta);
        }
        
        public ActionResult ServiciosEditar(FormCollection form)
        {
            try
            {
                Models.Servicio serviciosEditar = new Models.Servicio(Convert.ToInt32(form["txtCodigo"]));
                serviciosEditar.Actualizar(form["txtNombre"], form["txtDescripcion"], Convert.ToInt32(form["txtPrecio"]));
            }
            catch { }

            Servicio servicio = new Servicio();
            Consulta consulta = new Consulta(servicio.ConsultarDataBase());
            return View("Servicio", consulta);
        }

        public ActionResult CategoriaEditar(FormCollection form)
        {
            try
            {
                Models.Categoria categoriaEditar = new Models.Categoria(form["txtNombre"]);
                categoriaEditar.Actualizar(form["txtDescripcion"]);
            }
            catch {}
            Categoria categoria = new Categoria();
            Consulta consulta = new Consulta(categoria.ConsultarDataBase());
            return View("Categoria", consulta);
        }

        public ActionResult FamiliaEditar(FormCollection form)
        {
            try
            {
                Models.Familia familiaEditar = new Models.Familia(form["txtNombre"]);
                familiaEditar.Actualizar(form["txtDescripcion"]);
            }
            catch { }
            Familia familia = new Familia();
            Consulta consulta = new Consulta(familia.ConsultarDataBase());
            return View("Familia", consulta);
        }
    }
}