using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models.Enums;

namespace VendasWeb.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
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
