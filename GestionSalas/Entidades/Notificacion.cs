using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.Entidades
{
    public class Notificacion
    {
        public int idNotificacion {get;set;}
        public int idUser { get;set;}
        public string titulo { get;set;}
        public string mensaje { get;set;}

    }
}
