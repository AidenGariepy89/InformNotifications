using System;

namespace InformNotifications.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
	public string ItemId
	{
		set { LoadNote(value); }
	}

	public NotePage()
	{
		InitializeComponent();

		string appData = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appData, randomFileName));
	}

	private void LoadNote(string fileName)
	{
		Models.Note noteModel = new();
		noteModel.Filename = fileName;

		if (File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;
	}

	private async void SaveBtn_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.Note note)
		{
			File.WriteAllText(note.Filename, TextEditor.Text);
		}
		await Shell.Current.GoToAsync("..");
	}

	private async void DeleteBtn_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.Note note)
		{
			if (File.Exists(note.Filename))
			{
				File.Delete(note.Filename);
			}
		}

		await Shell.Current.GoToAsync("..");
	}
}
