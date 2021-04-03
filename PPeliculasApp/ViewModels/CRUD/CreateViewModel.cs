using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.PL.Models;
using App.PL.Services;
using DotVVM.Framework.ViewModel;

namespace App.PL.ViewModels.CRUD
{
    public class CreateViewModel : App.PL.ViewModels.MasterPageViewModel
    {
        private readonly PeliculaService peliculaService;

        public PeliculaModel Pelicula { get; set; } = new PeliculaModel { IdGenero = 1, FechaEstreno = DateTime.Now};

        public CreateViewModel(PeliculaService peliculaService)
        {
            this.peliculaService = peliculaService;
        }


        public async Task AddPelicula()
        {
            await peliculaService.InsertMovieAsync(Pelicula);
            Context.RedirectToRoute("Default");
        }
    }
}

