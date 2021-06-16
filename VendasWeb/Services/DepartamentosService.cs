using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Data;

namespace VendasWeb.Services
{
    public class DepartamentosService
    {

        private readonly VendasWebContext _context;

        public DepartamentosService(VendasWebContext context)
        {
            _context = context;
        }

        public List<Departamentos> FindAll()
        {
            return _context.Departamentos.OrderBy(x => x.Nome).ToList();
        }


    }
}

