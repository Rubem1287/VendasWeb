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
        public Vendas Vendas { get; set; }

        public RegistroVendas()
        {
        }

        public RegistroVendas(int id, DateTime date, double quantidade, StatusVendas status, Vendas vendas)
        {
            Id = id;
            Date = date;
            Quantidade = quantidade;
            Status = status;
            Vendas = vendas;
        }
    }
}
