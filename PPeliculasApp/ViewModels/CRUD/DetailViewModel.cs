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
    public class DetailViewModel : App.PL.ViewModels.MasterPageViewModel
    {
        private readonly PeliculaService peliculaService;

        public DetailViewModel(PeliculaService peliculaService)
        {
            this.peliculaService = peliculaService;
        }

        public PeliculaModel Pelicula { get; set; }

        public override async Task PreRender()
        {
            int id = Convert.ToInt32(Context.Parameters["Id"]);
            Pelicula = await peliculaService.GetMovieByIdAsync(id);
            await base.PreRender();
        }
        public async Task DeletePelicula()
        {
            await peliculaService.DeleteMovieAsync(Pelicula.IdPelicula);
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
        }
    }
}

