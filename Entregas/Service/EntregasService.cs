using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entregas.Data;
using Entregas.Models;

namespace Entregas.Service
{
    class EntregasService
    {
        private readonly EntregasContext _context;

        public EntregasService(EntregasContext context)
        {
            _context = context;
        }

        public List<Entrega> findByAll()
        {
            List<Entrega> entregas =  _context.Entrega.ToList();
            return entregas;
        }
        public void  Insert(Entrega obj)
        {
            _context.Add(obj);
             _context.SaveChanges();
        }
    }
}
