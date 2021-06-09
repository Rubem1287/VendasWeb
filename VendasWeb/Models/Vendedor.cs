using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace VendasWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
        public double SalarioBase { get; set; }
        public Departamentos Departamentos { get; set; }
        public ICollection<RegistroVendas> RegistroVendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, double salarioBase, Departamentos departamentos)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            SalarioBase = salarioBase;
            Departamentos = departamentos;
        }

        public void AddVendas(RegistroVendas rv)
        {
            RegistroVendas.Add(rv);
        }

        public void RemoveVendas(RegistroVendas rv)
        {
            RegistroVendas.Remove(rv);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return RegistroVendas.Where(rv => rv.Date >= inicial && rv.Date <= final).Sum(rv => rv.Quantidade);
        }

    }
}
