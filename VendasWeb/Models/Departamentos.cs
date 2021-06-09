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
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamentos()
        {
        }

        public Departamentos(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendas(Vendedor vendores) 
        {
            Vendedores.Add(vendores);
        }


        public double TotalVendas(DateTime inicio, DateTime final)
        {
            return Vendedores.Sum(vendedores => vendedores.TotalVendas(inicio, final));
        }
    }
}
