using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using App.PL.Services;
using App.PL.Models;

namespace App.PL.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly PeliculaService peliculaService;

        public DefaultViewModel(PeliculaService peliculaService)
        {
            this.peliculaService = peliculaService;
        }

        [Bind(Direction.ServerToClient)]
        public List<PeliculaModel> Peliculas { get; set; }

        public override async Task PreRender()
        {
            Peliculas = await peliculaService.GetAllMoviesAsync();
            await base.PreRender();
        }
    }
}
