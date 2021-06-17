using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Data;
using Microsoft.EntityFrameworkCore;
using VendasWeb.Services.Exceptions;

namespace VendasWeb.Services
{
    public class VendedorService
    {

        private readonly VendasWebContext _context;

        public VendedorService(VendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InserirAsync(Vendedor vendedor)
        {
            
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Vendedor> ProcurarPeloIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamentos).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoverAsync(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task AtualizarAsync(Vendedor vendedor)
        {
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == vendedor.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
