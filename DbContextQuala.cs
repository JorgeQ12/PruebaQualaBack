using Microsoft.EntityFrameworkCore;
using PruebaBackQuala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaBackQuala
{
    public class DbContextQuala : DbContext
    {
        public DbSet<DatosInformacionQuala> DatosInformacionQuala { get; set; }
        public DbSet<MonedaInformation> MonedaInformation { get; set; }
        public DbContextQuala(DbContextOptions<DbContextQuala> options): base(options)
        {

        }
    }
}
