using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace VendasWeb.Services
{
    public class DepartamentosService
    {

        private readonly VendasWebContext _context;

        public DepartamentosService(VendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<Departamentos>> FindAllAsync()
        {
            return await _context.Departamentos.OrderBy(x => x.Nome).ToListAsync();
        }


    }
}

