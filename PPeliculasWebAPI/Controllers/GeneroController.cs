using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPeliculasWebAPI.DAL;
using PPeliculasWebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPeliculasWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : Controller
    {
        private readonly PeliculasContext PeliculasContext;

        public GeneroController(PeliculasContext PeliculasContext)
        {
            this.PeliculasContext = PeliculasContext;
        }


        [HttpGet("GetGeneros")]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            var List = await PeliculasContext.Genero.Select(
                s => new GeneroDTO
                {
                    IdGenero = s.IdGenero,
                    Nombre = s.Nombre
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
    }
}
