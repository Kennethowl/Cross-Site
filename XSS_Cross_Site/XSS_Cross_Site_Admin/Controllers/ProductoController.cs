using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSS_Cross_Site_BL;

namespace XSS_Cross_Site_Admin.Controllers
{
    public class ProductoController : Controller
    {
        ProductoBL _productoBL;

        public ProductoController()
        {
            _productoBL = new ProductoBL();
        }

        // GET: Producto
        public ActionResult Index()
        {
            var productos = _productoBL.ObtenerProductos();

            return View(productos);
        }

        public ActionResult Create()
        {
            var nuevoProducto = new Producto();

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.LimpiarVariables();

                _productoBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            return View(producto);
        }
    }
}