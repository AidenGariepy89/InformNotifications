using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InformNotifications.ViewModels;

[QueryProperty("Message", "Message")]
[QueryProperty("Date", "Date")]
public partial class ViewMessageViewModel : ObservableObject
{
    [ObservableProperty]
    string message;

    [ObservableProperty]
    DateTime date;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
