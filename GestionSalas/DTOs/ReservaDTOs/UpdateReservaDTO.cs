using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.DTOs.ReservaDTOs
{
    public class UpdateReservaDTO
    {
        public int idReserva { get; set; }
        public int idUsuario { get; set; }
        public int idSala { get; set; }
        public byte priority { get; set; }
        public DateTime? horaInicio { get; set; }
        public DateTime? horaFin { get; set; }
        public string? state { get; set; }

    }
}
