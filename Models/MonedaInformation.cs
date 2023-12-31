﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaBackQuala.Models
{
    public class MonedaInformation
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<DatosInformacionQuala> DatosQuala { get; set; }

    }

}
