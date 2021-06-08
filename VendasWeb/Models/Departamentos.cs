using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models
{
    public class Departamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

        public Departamentos()
        {
        }

        public Departamentos(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendas(Vendas vendas) 
        {
            Vendas.Add(vendas);
        }


        public double TotalVendas(DateTime inicio, DateTime final)
        {
            return Vendas.Sum(vendedores => vendedores.TotalVendas(inicio, final));
        }
    }
}
