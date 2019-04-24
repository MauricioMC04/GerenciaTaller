using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
    public class Consulta
    {
        private List<Familia> familias;

        public Consulta()
        {

        }

        public Consulta(List<Familia> _familia)
        {
            this.familias = _familia;
        }

        public List<Familia> GetFamilias()
        {
            return this.familias;
        }

        private List<Categoria> categorias;

        

        public Consulta(List<Categoria> _categorias)
        {
            this.categorias = _categorias;
        }

        public List<Categoria> GetCategorias()
        {
            return this.categorias;
        }

        private List<Producto> productos;



        public Consulta(List<Producto> _productos)
        {
            this.productos = _productos;
        }

        public List<Producto> GetProductos()
        {
            return this.productos;
        }

        private List<Servicio> servicio;



        public Consulta(List<Servicio> _servicio)
        {
            this.servicio = _servicio;
        }

        public List<Servicio> GetServicio()
        {
            return this.servicio;
        }
    }
}