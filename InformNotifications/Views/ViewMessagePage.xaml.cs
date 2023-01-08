using InformNotifications.ViewModels;

namespace InformNotifications.Views;

public partial class ViewMessagePage : ContentPage
{
	public ViewMessagePage(ViewMessageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
