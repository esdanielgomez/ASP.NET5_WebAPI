using System;
using System.Collections.Generic;

#nullable disable

namespace PPeliculasWebAPI.DAL.Entities
{
    public partial class Genero
    {
        public Genero()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int IdGenero { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
