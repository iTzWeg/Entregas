using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entregas.Models;

namespace Entregas.Data
{
    class EntregasContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DBEntregas;User Id=sa;Password=Manager1;");
        }

        public DbSet<Entrega>Entrega { get; set; }
    }
}
