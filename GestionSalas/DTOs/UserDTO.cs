using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Entity.DTOs
{
    public class UserDTO
    {
        public int idUser { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
