using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.DTOs.ReservaDTOs
{
    public class ResponseSalasDisponiblesDTO
    {
        public int id_sala { get; set; }
        public int id_reserva { get; set; }
        public string name { get; set; }
        public string cod_sala { get; set; }
        public int floor_sala { get; set; }
        public int capacity_sala { get; set; }
        public int priority { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }


    }
}
