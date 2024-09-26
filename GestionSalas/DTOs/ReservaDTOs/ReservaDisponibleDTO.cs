using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.DTOs.ReservaDTOs
{
    public class ReservaDisponibleDTO
    {
        public int piso { get; set; }
        public int capacidad { get; set; }
        public int hora { get; set; }
        public int minutos { get; set; }
        public int duracion { get; set; }
        public int prioridad  { get; set; }


    }
}
