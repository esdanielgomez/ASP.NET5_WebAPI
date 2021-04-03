using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PL.Models
{
    public class PeliculaModel
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEstreno { get; set; }
        public int DuracionMinutos { get; set; }
        public string Sinopsis { get; set; }
        public int IdGenero { get; set; }
        public string NombreGenero { get; set; }
    }
}
