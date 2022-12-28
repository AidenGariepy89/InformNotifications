using System;

namespace InformNotifications.Views;

public partial class RecipientSelectionPage : ContentPage
{
	public RecipientSelectionPage()
	{
		InitializeComponent();

		BindingContext = new Models.RecipientLoader();
	}

    protected override void OnAppearing()
    {
		if (BindingContext is Models.RecipientLoader r)
		{
			r.LoadRecipients();
		}
    }

    private void addBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		if (allRecipientsList.SelectedItems.Count != 0 && allRecipientsList.SelectedItems[0] is Models.Recipient
			&& BindingContext is Models.RecipientLoader r)
		{
			List<Models.Recipient> recipients = new();
			foreach (Models.Recipient recipient in allRecipientsList.SelectedItems)
			{
				recipients.Add(recipient);
			}

			r.AddSelections(recipients);
		}
	}

    private void removeBtn_Clicked(object sender, EventArgs e)
    {
        if (selectedRecipientsList.SelectedItems.Count != 0 && selectedRecipientsList.SelectedItems[0] is Models.Recipient
			&& BindingContext is Models.RecipientLoader r)
		{
			List<Models.Recipient> recipients = new();
			foreach (Models.Recipient recipient in selectedRecipientsList.SelectedItems)
			{
				recipients.Add(recipient);
			}

            selectedRecipientsList.SelectedItems.Clear();
            r.RemoveSelections(recipients);
		}
    }

    private void clearBtn_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.RecipientLoader r)
		{
            selectedRecipientsList.SelectedItems.Clear();
            r.ClearSelection();
		}
	}

	private void testBtn_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.RecipientLoader r)
		{
			int allCount = r.AllRecipients.Count;
			int selectedCount = r.SelectedRecipients.Count;
			string text = $"{allCount}:{selectedCount}";
			testText.Text = text;
		}
	}
}
