using InformNotifications.ViewModels;
using InformNotifications.Views;

namespace InformNotifications;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ViewMessagePage), typeof(ViewMessagePage));
	}
}
