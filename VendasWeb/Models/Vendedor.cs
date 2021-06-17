using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace VendasWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} Requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Tamanho do {0} é entre {2} e {1} letras")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} Requerido")]
        [EmailAddress(ErrorMessage ="Coloque um email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} Requerido")]
        [Display(Name ="Aniversário" )]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Aniversario { get; set; }

        [Required(ErrorMessage = "Campo {0} Requerido")]
        [Range(100.0, 50000.00, ErrorMessage ="Coloque um {0} entre {1} a {2}")]
        [Display(Name ="Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamentos Departamentos { get; set; }
        public int DepartamentosId { get; set; }
        public ICollection<RegistroVendas> RegistroVendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, double salarioBase, int departamentosId)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            SalarioBase = salarioBase;
            DepartamentosId = departamentosId;
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
