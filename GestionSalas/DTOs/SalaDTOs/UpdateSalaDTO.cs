using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.DTOs.SalaDTOs
{
    public class UpdateSalaDTO
    {
        public int idSala { get; set; }
        public string? nameSala { get; set; }
        public string? codSala { get; set; }
        public byte? floorSala { get; set; }
        public byte? capacitySala { get; set; }
    }
}
