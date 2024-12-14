using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProjectMaui;
using ProjectMaui.Models;

public class ExerciseService
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

        var response = await httpClient.GetFromJsonAsync<List<Exercise>>($"exercises?muscle={muscle}"); //($"exercises?muscle={muscle}");
        return response ?? new List<Exercise>();
    }
}

//using appsettings
//public ExerciseService(IConfiguration config)
//{
//    var baseUrl = config["API:BaseUrl"];
//    var apiKey = config["API:ApiKey"];
//    httpClient = new HttpClient
//    {
//        BaseAddress = new Uri(baseUrl)
//    };
//    httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
//}