using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace InformNotifications.Models;

public partial class InformMessage : ObservableObject
{
	[ObservableProperty]
	string message;

	[ObservableProperty]
	DateTime date;

	public InformMessage(string message, DateTime date)
	{
		this.message = message;
		this.date = date;
	}
}
