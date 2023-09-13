using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Cross_Site_BL
{
    public class ProductoBL
    {
        Contexto _contexto;
        public List<Producto> ListaProductos { get; set; }

        public ProductoBL()
        {
            _contexto = new Contexto();
            ListaProductos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        { 
            ListaProductos = _contexto.Productos.ToList();
            return ListaProductos;
        }

        public void GuardarProducto(Producto producto)
        {
            if (producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
            }
            else
            {
                var productosEncontrados = _contexto.Productos.Find(producto.Id);
                productosEncontrados.Nombre = producto.Nombre;
                productosEncontrados.Descripcion = producto.Descripcion;
                productosEncontrados.Precio = producto.Precio;
            }

            _contexto.SaveChanges();
        }
    }
}
