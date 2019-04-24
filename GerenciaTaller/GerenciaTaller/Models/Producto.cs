using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
    public class Producto
    {
        private int codigo;
        private string nombre;
        private string descripcion;
        private int precio;
        private Categoria categoria;
        private bool borrado;
        private int cantidad;

        public Producto()
        {
        }

        public Producto(int _codigo, string _nombre, string _descripcion, int _precio, Categoria _categoria,
            bool _borrado, int _cantidad)
        {
            this.codigo = _codigo;
            this.nombre = _nombre;
            this.descripcion = _descripcion;
            this.precio = _precio;
            this.categoria = _categoria;
            this.borrado = _borrado;
            this.cantidad = _cantidad;
        }

        public Producto(int _codigo, string _nombre)
        {
            this.codigo = _codigo;
            this.nombre = _nombre;
        }

        public Producto(int _codigo)
        {
            this.codigo = _codigo;
        }

        public int GetCodigo()
        {
            return this.codigo;
        }

        public string GetNombre()
        {
            return this.nombre;
        }

        public string GetDescripcion()
        {
            return this.descripcion;
        }

        public int GetPrecio()
        {
            return this.precio;
        }

        public Categoria GetCategoria()
        {
            return this.categoria;
        }

        public bool GetBorrado()
        {
            return this.borrado;
        }

        public bool AgregarDataBase(int cantidad)
        {
            if (!this.Existe())
            {
                Servicio servicio = new Servicio(-1, this.nombre);
                if (!servicio.Existe())
                {
                    int mayorProducto = this.GetCodigoMayor("codigo", "Producto");
                    int mayorServicio = this.GetCodigoMayor("codigo", "Servicios");
                    this.codigo = (mayorProducto > mayorServicio) ? mayorProducto + 1 : mayorServicio + 1;
                    DataBase.Query dataBase = new DataBase.Query();
                    string insertProducto = "INSERT INTO Producto VALUES (" + this.codigo + ", '" + this.nombre + "', '" + this.descripcion + "', " + this.precio + ", '" + this.categoria.GetNombre() + "', " + this.borrado + ")";
                    if (dataBase.Agregar(insertProducto))
                    {
                        string insertInventario = "INSERT INTO Inventario VALUES(" + this.codigo + ", " + cantidad.ToString() + ")";
                        return dataBase.Agregar(insertInventario);
                    }
                }
            }
            return false;
        }

        public List<Producto> ConsultarDataBase()
        {
            DataBase.Query dataBase = new DataBase.Query();
            string select = "SELECT * From Producto where borrado = false";
            List<Producto> lista = dataBase.ConsultarProductos(select);
            return lista;
        }

        public bool Existe()
        {
            if (!this.nombre.Equals(""))
            {
                DataBase.Query dataBase = new DataBase.Query();
                string select = "SELECT * From Producto where nombre = '" + this.nombre + "'";
                List<Producto> lista = dataBase.ConsultarProductos(select);
                return lista.Count > 0;
            }
            return true;
        }

        public int GetCodigoMayor(string columna, string tabla)
        {
            DataBase.Query dataBase = new DataBase.Query();
            return dataBase.GetMayor(columna, tabla);
        }

        public bool Eliminar()
        {
            DataBase.Query dataBase = new DataBase.Query();
            return dataBase.Eliminar("Producto", "codigo", this.codigo.ToString()) &&
                dataBase.AgregarBitacora("BitacoraBorradoProductos", this.codigo.ToString());
        }

        public bool Actualizar(string nombre, string descripcion, int precio, int cantidad)
        {
            DataBase.Query dataBase = new DataBase.Query();
            string updateProducto = "update Producto set nombre = '" + nombre + "', descripcion = '" + descripcion +
                "', precio = " + precio.ToString() + " where codigo = " + this.codigo;
            string updateInventario = "update Inventario set cantidad = " + cantidad + " where codigoProducto = " + this.codigo;
            return dataBase.Actualizar(updateProducto) && dataBase.Actualizar(updateInventario);
        }

        public bool ActualizarInventario(int cantidadNueva)
        {
            DataBase.Query dataBase = new DataBase.Query();
            string update = "update Inventario set cantidad = " + cantidadNueva + " where codigoProducto = " + this.codigo;
            return dataBase.Actualizar(update);
        }
    }
}