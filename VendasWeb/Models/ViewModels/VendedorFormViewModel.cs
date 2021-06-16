using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models.ViewModels
{
    public class VendedorFormViewModel
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
        public double SalarioBase { get; set; }
        public Departamentos Departamentos { get; set; }
        public int DepartamentosId { get; set; }
        public ICollection<RegistroVendas> RegistroVendas { get; set; } = new List<RegistroVendas>();
        public ICollection<Departamentos> Departamentoss { get; set; }

        

    }
}
