using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPeliculasWebAPI.DAL;
using PPeliculasWebAPI.DAL.Entities;
using PPeliculasWebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PPeliculasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : Controller
    {
        private readonly PeliculasContext PeliculasContext;

        public PeliculaController(PeliculasContext PeliculasContext)
        {
            this.PeliculasContext = PeliculasContext;
        }

        [HttpGet("GetPeliculas")]
        public async Task<ActionResult<List<PeliculaDTO>>> Get()
        {
            var listado = await PeliculasContext.Pelicula.Select(
                s => new PeliculaDTO
                {
                    IdPelicula = s.IdPelicula,
                    Nombre = s.Nombre,
                    FechaEstreno = s.FechaEstreno,
                    DuracionMinutos = s.DuracionMinutos,
                    Sinopsis = s.Sinopsis,
                    IdGenero = s.IdGenero,
                    NombreGenero = s.IdGeneroNavigation.Nombre
                }
            ).ToListAsync();

            if (listado.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return listado;
            }
        }

        [HttpGet("GetPeliculaPorId")]
        public async Task<ActionResult<PeliculaDTO>> GetPeliculaById(int IdPelicula)
        {
            PeliculaDTO Pelicula = await PeliculasContext.Pelicula.Select(
                    s => new PeliculaDTO
                    {
                        IdPelicula = s.IdPelicula,
                        Nombre = s.Nombre,
                        FechaEstreno = s.FechaEstreno,
                        DuracionMinutos = s.DuracionMinutos,
                        Sinopsis = s.Sinopsis,
                        IdGenero = s.IdGenero,
                        NombreGenero = s.IdGeneroNavigation.Nombre
                    })
                .FirstOrDefaultAsync(s => s.IdPelicula == IdPelicula);

            if (Pelicula == null)
            {
                return NotFound();
            }
            else
            {
                return Pelicula;
            }
        }

        [HttpPost("InsertPelicula")]
        public async Task<HttpStatusCode> InsertPelicula(PeliculaDTO pelicula)
        {
            var entity = new Pelicula()
            {
                IdPelicula = pelicula.IdPelicula,
                Nombre = pelicula.Nombre,
                FechaEstreno = pelicula.FechaEstreno,
                DuracionMinutos = pelicula.DuracionMinutos,
                Sinopsis = pelicula.Sinopsis,
                IdGenero = pelicula.IdGenero
            };

            PeliculasContext.Pelicula.Add(entity);
            await PeliculasContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        [HttpPut("UpdatePelicula")]
        public async Task<HttpStatusCode> UpdatePelicula(PeliculaDTO pelicula)
        {
            var entity = await PeliculasContext.Pelicula.FirstOrDefaultAsync(s => s.IdPelicula == pelicula.IdPelicula);


            entity.IdPelicula = pelicula.IdPelicula;
            entity.Nombre = pelicula.Nombre;
            entity.FechaEstreno = pelicula.FechaEstreno;
            entity.DuracionMinutos = pelicula.DuracionMinutos;
            entity.Sinopsis = pelicula.Sinopsis;
            entity.IdGenero = pelicula.IdGenero;

            await PeliculasContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeletePelicula/{IdPelicula}")]
        public async Task<HttpStatusCode> DeletePelicula(int IdPelicula)
        {
            var entity = new Pelicula()
            {
                IdPelicula = IdPelicula
            };

            PeliculasContext.Pelicula.Attach(entity);
            PeliculasContext.Pelicula.Remove(entity);

            await PeliculasContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
