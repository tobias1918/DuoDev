using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.Entidades
{
    public class Sala
    {
        public int idSala { get; set; }
        public string nameSala { get; set; }
        public string codSala { get; set; }
        public byte floorSala { get; set; }
        public byte capacitySala { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
