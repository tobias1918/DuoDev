using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.Entidades
{
    public class Reserva
    {
        public int idReserva { get; set; }
        public int idUsuario { get; set; }
        public int idSala { get; set; }
        public byte priority { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public string state { get; set; } //En curso,Reservado,Finalizado,Cancelado
        
    }
}
