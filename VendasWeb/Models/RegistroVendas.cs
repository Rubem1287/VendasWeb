using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models.Enums;

namespace VendasWeb.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Quantidade { get; set; }
        public StatusVendas Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVendas()
        {
        }

        public RegistroVendas(int id, DateTime date, double quantidade, StatusVendas status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            Quantidade = quantidade;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
