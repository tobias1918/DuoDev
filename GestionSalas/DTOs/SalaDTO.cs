using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.DTOs
{
    public class SalaDTO
    {
        public int idSala { get; set; }
        public string nameSala { get; set; }
        public string numSala { get; set; }
        public int pisoSala { get; set; }
        public short capacidadSala { get; set; }
        public bool disponibilidad { get; set; }
    }
}
