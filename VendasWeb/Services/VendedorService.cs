using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Data;

namespace VendasWeb.Services
{
    public class VendedorService
    {

        private readonly VendasWebContext _context;

        public VendedorService(VendasWebContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Inserir(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }


    }
}
