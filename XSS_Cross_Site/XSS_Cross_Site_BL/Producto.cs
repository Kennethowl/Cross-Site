using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Cross_Site_BL
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un producto")]
        [MinLength(5, ErrorMessage = "El mínimo de carácteres es de 5")]
        [MaxLength(20, ErrorMessage = "El máximo de carácteres es de 20")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una descripción")]
        [MinLength(5, ErrorMessage = "El mínimo de carácteres es de 5")]
        [MaxLength(20, ErrorMessage = "El máximo de carácteres es de 20")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese el precio")]
        public double Precio { get; set; }

        public void LimpiarVariables()
        {
            Nombre = Sanitizer.GetSafeHtml(Nombre);
            Descripcion = Sanitizer.GetSafeHtml(Descripcion);
        }
    }
}
