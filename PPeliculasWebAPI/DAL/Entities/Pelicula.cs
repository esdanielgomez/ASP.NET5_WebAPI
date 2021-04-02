using System;
using System.Collections.Generic;

#nullable disable

namespace PPeliculasWebAPI.DAL.Entities
{
    public partial class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEstreno { get; set; }
        public int DuracionMinutos { get; set; }
        public string Sinopsis { get; set; }
        public int IdGenero { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
    }
}
