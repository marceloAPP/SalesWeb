using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class VendedoresFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
