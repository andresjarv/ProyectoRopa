using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROPA.Shared
{
    class Cliente
    {
        public int Id { get; set; }      
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }
}
