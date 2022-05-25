using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrud.Modelos
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
    }
}
