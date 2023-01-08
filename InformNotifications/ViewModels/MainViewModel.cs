using InformNotifications.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace InformNotifications.ViewModels;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty]
	ObservableCollection<InformMessage> messageHistory;

	public MainViewModel()
	{
		messageHistory = new ObservableCollection<InformMessage>();
		messageHistory.Add(new InformMessage("This is a test message", DateTime.Now));
		messageHistory.Add(new InformMessage("Sometimes GCA can be a sad place...", DateTime.Now));
	}

	[RelayCommand]
	void ClearHistory()
	{
		messageHistory.Clear();
	}
}
