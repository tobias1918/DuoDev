﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.Entidades
{
    public class User
    {
        public int idUser { get; set; }
        public string name {  get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool rol { get; set; }
        public bool isDeleted { get; set; } //para borrar el usuario sin eliminar el registro
        //List<string> reservas { get; set; }
        
    }
}
