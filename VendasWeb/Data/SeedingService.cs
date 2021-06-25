using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models.Enums;
using VendasWeb.Models;
namespace VendasWeb.Data
{
    public class SeedingService
    {
        private VendasWebContext _context;

        public SeedingService(VendasWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamentos.Any() ||
                _context.Vendedor.Any() ||
                _context.RegistroVendas.Any())
            {
                return; //Banco de dados populado
            }

            Departamentos d1 = new Departamentos(1, "Computadores");
            Departamentos d2 = new Departamentos(2, "Eletrônicos");
            Departamentos d3 = new Departamentos(3, "Fashion");
            Departamentos d4 = new Departamentos(4, "Books");


            Vendedor v1 = new Vendedor(1, "Bob Brown", "Bob@Gmail.com", new DateTime(1998, 4, 21), 1000.0, d1.Id);
            Vendedor v2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2.Id);
            Vendedor v3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1.Id);
            Vendedor v4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4.Id);
            Vendedor v5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3.Id);
            Vendedor v6 = new Vendedor(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2.Id);


            RegistroVendas r1 = new RegistroVendas(1, new DateTime(2018, 09, 25), 11000.0, StatusVendas.Faturado, v1.Id);
            RegistroVendas r2 = new RegistroVendas(2, new DateTime(2018, 09, 4), 7000.0, StatusVendas.Faturado, v2.Id);
            RegistroVendas r3 = new RegistroVendas(3, new DateTime(2018, 09, 13), 4000.0, StatusVendas.Cancelado, v3.Id);
            RegistroVendas r4 = new RegistroVendas(4, new DateTime(2018, 09, 1), 8000.0, StatusVendas.Faturado, v5.Id);
            RegistroVendas r5 = new RegistroVendas(5, new DateTime(2018, 09, 21), 3000.0, StatusVendas.Faturado, v6.Id);
            RegistroVendas r6 = new RegistroVendas(6, new DateTime(2018, 09, 15), 2000.0, StatusVendas.Faturado, v4.Id);
            RegistroVendas r7 = new RegistroVendas(7, new DateTime(2018, 09, 28), 13000.0, StatusVendas.Faturado, v2.Id);
            RegistroVendas r8 = new RegistroVendas(8, new DateTime(2018, 09, 11), 4000.0, StatusVendas.Faturado, v4.Id);
            RegistroVendas r9 = new RegistroVendas(9, new DateTime(2018, 09, 14), 11000.0, StatusVendas.Pendente, v6.Id);
            RegistroVendas r10 = new RegistroVendas(10, new DateTime(2018, 09, 7), 9000.0, StatusVendas.Faturado, v6.Id);
            RegistroVendas r11 = new RegistroVendas(11, new DateTime(2018, 09, 13), 6000.0, StatusVendas.Faturado, v2.Id);
            RegistroVendas r12 = new RegistroVendas(12, new DateTime(2018, 09, 25), 7000.0, StatusVendas.Pendente, v3.Id);
            RegistroVendas r13 = new RegistroVendas(13, new DateTime(2018, 09, 29), 10000.0, StatusVendas.Faturado, v4.Id);
            RegistroVendas r14 = new RegistroVendas(14, new DateTime(2018, 09, 4), 3000.0, StatusVendas.Faturado, v5.Id);
            RegistroVendas r15 = new RegistroVendas(15, new DateTime(2018, 09, 12), 4000.0, StatusVendas.Faturado, v1.Id);
            RegistroVendas r16 = new RegistroVendas(16, new DateTime(2018, 10, 5), 2000.0, StatusVendas.Faturado, v4.Id);
            RegistroVendas r17 = new RegistroVendas(17, new DateTime(2018, 10, 1), 12000.0, StatusVendas.Faturado, v1.Id);
            RegistroVendas r18 = new RegistroVendas(18, new DateTime(2018, 10, 24), 6000.0, StatusVendas.Faturado, v3.Id);
            RegistroVendas r19 = new RegistroVendas(19, new DateTime(2018, 10, 22), 8000.0, StatusVendas.Faturado, v5.Id);
            RegistroVendas r20 = new RegistroVendas(20, new DateTime(2018, 10, 15), 8000.0, StatusVendas.Faturado, v6.Id);
            RegistroVendas r21 = new RegistroVendas(21, new DateTime(2018, 10, 17), 9000.0, StatusVendas.Faturado, v2.Id);
            RegistroVendas r22 = new RegistroVendas(22, new DateTime(2018, 10, 24), 4000.0, StatusVendas.Faturado, v4.Id);
            RegistroVendas r23 = new RegistroVendas(23, new DateTime(2018, 10, 19), 11000.0, StatusVendas.Cancelado, v2.Id);
            RegistroVendas r24 = new RegistroVendas(24, new DateTime(2018, 10, 12), 8000.0, StatusVendas.Faturado, v5.Id);
            RegistroVendas r25 = new RegistroVendas(25, new DateTime(2018, 10, 31), 7000.0, StatusVendas.Faturado, v3.Id);
            RegistroVendas r26 = new RegistroVendas(26, new DateTime(2018, 10, 6), 5000.0, StatusVendas.Faturado, v4.Id);
            RegistroVendas r27 = new RegistroVendas(27, new DateTime(2018, 10, 13), 9000.0, StatusVendas.Pendente, v1.Id);
            RegistroVendas r28 = new RegistroVendas(28, new DateTime(2018, 10, 7), 4000.0, StatusVendas.Faturado, v3.Id);
            RegistroVendas r29 = new RegistroVendas(29, new DateTime(2018, 10, 23), 12000.0, StatusVendas.Faturado, v5.Id);
            RegistroVendas r30 = new RegistroVendas(30, new DateTime(2018, 10, 12), 5000.0, StatusVendas.Faturado, v2.Id);

            _context.Departamentos.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);

            _context.RegistroVendas.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, 
                                             r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, 
                                             r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            _context.SaveChanges();

        }


    }
}
