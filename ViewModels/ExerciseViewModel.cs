
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMaui.Models;
using ProjectMaui.Views;
using ProjectMaui.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Microsoft.Maui.Devices.Sensors;

namespace ProjectMaui.ViewModels
{
    public partial class ExerciseViewModel : BaseViewModel
    {
        ExerciseService exerciseService;
        public ObservableCollection<Exercise> Exercises { get; } = new();

        IConnectivity connectivity;

        // dependency constructor injection, injecting service, and connectivity
        // when an instance of ExerciseViewModel is created we will get objects of the injected services
        public ExerciseViewModel(ExerciseService exerciseService, IConnectivity connectivity)
        {
            Title = "Exercise Title"; // from base view model
            this.exerciseService = exerciseService;
            this.connectivity = connectivity;
        }

        [RelayCommand]
        async Task LoadExercisesAsync()
        {
            if (IsBusy) return;
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet issue", $"Check your interntet", "Ok");
                    return;
                }
                IsBusy = true;
                var exercises = await exerciseService.GetExercise();
                foreach (var exercise in exercises)
                    Exercises.Add(exercise);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", "Unable to fetch data", "Ok");

            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GoToDetailsAsync(Exercise exercise)
        {
            if (exercise == null) return;

            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailsPage)}", true,
                new Dictionary<string, object>
                {{"Exercise", exercise}});
        }
    }
}
