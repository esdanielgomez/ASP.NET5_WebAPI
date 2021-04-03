using App.PL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.PL.Services
{
    public class PeliculaService
    {
        private readonly string URLbase = "URL_API";
        private string id;

        public async Task<List<PeliculaModel>> GetAllMoviesAsync()
        {
            List<PeliculaModel> usersList = new List<PeliculaModel>();
            using (var httpClient = new HttpClient())
            {
                string URL = URLbase + "/GetPeliculas";
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
                usersList = JsonConvert.DeserializeObject<List<PeliculaModel>>(apiResponse);
            }
            return usersList;
        }

        public async Task<PeliculaModel> GetMovieByIdAsync(int Id)
        {
            string URL = URLbase + "/GetPeliculaPorId?IdPelicula=" + Id;
            PeliculaModel User = new PeliculaModel();

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
                User = JsonConvert.DeserializeObject<PeliculaModel>(apiResponse);
            }
            return User;
        }

        public async Task InsertMovieAsync(PeliculaModel pelicula)
        {
            string URL = URLbase + "/InsertPelicula";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(pelicula), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task UpdateMovieAsync(PeliculaModel user)
        {
            string URL = URLbase + "/UpdatePelicula";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task DeleteMovieAsync(int Id)
        {
            string URL = URLbase + "/DeletePelicula/" + Id;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
