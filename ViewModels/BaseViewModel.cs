using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectMaui.ViewModels
{
    // includes shared properties for all other models (page title, app busy status) 
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel() { }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy; //toggle
    }
}
