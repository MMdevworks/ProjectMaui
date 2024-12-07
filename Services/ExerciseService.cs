using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ProjectMaui.Models;

namespace ProjectMaui.Services
{
    class ExerciseService
    {
        HttpClient httpClient;

        public ExerciseService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Env.API_BASE_URL)
            };
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", Env.API_KEY);
        }

        public async Task<List<Exercise>> GetExercise(string muscle)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                throw new InvalidOperationException("No internet connection.");

            var response = await httpClient.GetFromJsonAsync<List<Exercise>>($"exercises?muscle={muscle}");
            return response ?? new List<Exercise>();
        }
    }
}
