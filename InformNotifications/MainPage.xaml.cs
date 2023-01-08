using InformNotifications.ViewModels;

namespace InformNotifications;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
