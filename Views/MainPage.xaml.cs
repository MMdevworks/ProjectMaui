using ProjectMaui.Models;
using ProjectMaui.Services;
using ProjectMaui.ViewModels;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace ProjectMaui.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}