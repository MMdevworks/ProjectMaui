using System.Collections.ObjectModel;
using ProjectMaui.Models;
using ProjectMaui.Views;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectMaui.ViewModels
{
    public partial class ExerciseViewModel : BaseViewModel
    {
        ExerciseService exerciseService;
        public ObservableCollection<Exercise> Exercises { get; } = new();

        IConnectivity connectivity;

        [ObservableProperty]
        private string muscle;
        public List<string> MuscleList { get; } = new List<string> { "abdominals", "abductors", "adductors", "biceps", "calves", "chest", "forearms", "glutes", "hamstrings", "lats", "lower_back", "middle_back", "neck", "quadriceps", "traps", "triceps" };

        public List<string> FormattedMuscleList
        {
            get{return GetFormattedMuscleList();}
        }
        public List<string> GetFormattedMuscleList()
        {
            return MuscleList.Select(m => m.Replace('_', ' ').ToUpper()).ToList();
        }
        // dependency constructor injection, injecting service, and connectivity
        // when an instance of ExerciseViewModel is created we will get objects of the injected services
        public ExerciseViewModel(ExerciseService exerciseService, IConnectivity connectivity)
        {
            this.exerciseService = exerciseService;
            this.connectivity = connectivity;

            Debug.WriteLine("ExerciseViewModel initialized.");
        }

        partial void OnMuscleChanged(string value)
        {
            LoadExercisesCommand.Execute(null);
        }

        [RelayCommand] //[RelayCommand] attribute to a method, it automatically generates a command for that method ie LoadExerciseCommand
        async Task LoadExercisesAsync()
        {
            if (IsBusy || string.IsNullOrWhiteSpace(Muscle)) return;
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet issue", "Check your interntet", "Ok");
                    return;
                }
                IsBusy = true;

                Exercises.Clear();
                
                string formattedMuscle = Muscle.Replace(" ", "_").ToLower();
                var exercises = await exerciseService.GetExercise(formattedMuscle);
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
