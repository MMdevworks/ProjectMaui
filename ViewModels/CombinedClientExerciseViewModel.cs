using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaui.ViewModels
{
    public partial class CombinedClientExerciseViewModel : BaseViewModel
    {
        public ClientDetailsViewModel ClientDetailsViewModel { get; }
        public ExerciseViewModel ExerciseViewModel { get; }

        public CombinedClientExerciseViewModel(ClientDetailsViewModel cdvm, ExerciseViewModel exvm)
        {
            ClientDetailsViewModel = cdvm;
            ExerciseViewModel = exvm;
        }
    }
}
