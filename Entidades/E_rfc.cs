using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_rfc
    {
        public int idUsuario { get; set; }

        public string nombre { get; set; }

        public string apellidoPa { get; set; }

        public string apellidoMa { get; set; }

        public DateTime fechaNac { get; set; }
        public string  RFC { get; set; }
    }
}
