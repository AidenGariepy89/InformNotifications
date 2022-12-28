using System;

namespace InformNotifications.Views;

public partial class TestView : ContentPage
{
	public TestView()
	{
		InitializeComponent();
	}

	private void CrazyBtn_Clicked(object sender, EventArgs e)
	{
		scaryText.IsVisible = !scaryText.IsVisible;
	}
}
