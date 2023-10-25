using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaBackQuala.Models
{
    public class DatosInformacionQuala
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatoria.")]
        [StringLength(250, ErrorMessage = "La Descripción debe tener como máximo 250 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Dirección es obligatoria.")]
        [StringLength(250, ErrorMessage = "La Dirección debe tener como máximo 250 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La Identificación es obligatoria.")]
        [StringLength(50, ErrorMessage = "La Identificación debe tener como máximo 50 caracteres.")]
        public string Identificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "La Moneda es obligatoria.")]
        public int MonedaID { get; set; }

        [ForeignKey("MonedaID")]
        public virtual MonedaInformation Moneda { get; set; }
    }
}
