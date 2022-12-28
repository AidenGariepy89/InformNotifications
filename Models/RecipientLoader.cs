using System;
using System.Collections.ObjectModel;

namespace InformNotifications.Models;

internal class RecipientLoader
{
	public ObservableCollection<Recipient> AllRecipients { get; set; }
	public ObservableCollection<Recipient> SelectedRecipients { get; set; }

	public RecipientLoader()
	{
		AllRecipients = new ObservableCollection<Recipient>();
		SelectedRecipients = new ObservableCollection<Recipient>();
	}

	public void AddSelections(List<Recipient> recipients)
	{
		foreach (var recipient in recipients)
		{
			if (!SelectedRecipients.Contains(recipient))
			{
				SelectedRecipients.Add(recipient);
			}
		}
	}

	public void RemoveSelections(List<Recipient> recipients)
	{
		foreach (var recipient in recipients)
		{
			if (SelectedRecipients.Contains(recipient))
			{
				SelectedRecipients.Remove(recipient);
			}
		}
	}

	public void ClearSelection()
	{
		SelectedRecipients.Clear();
	}

	public void LoadRecipients()
	{
		AllRecipients.Clear();
		//SelectedRecipients.Clear();

		var aiden = new Recipient
		{
			FirstName = "Aiden",
			LastName = "Gariepy",
			Class = "Senior",
			Email = "aidengariepy89@gmail.com",
			ContactEmails = new List<string> { "sgariepy@gcasda.org", "lgariepy@gcasda.org" }
		};
		var samantha = new Recipient
		{
			FirstName = "Samantha",
			LastName = "Gariepy",
            Class = "Freshmen",
			Email = "samgar26@gcasda.org",
			ContactEmails = new List<string>{ "sgariepy@gcasda.org", "lgariepy@gcasda.org" }
		};
		var billy = new Recipient
		{
			FirstName = "Billy",
			LastName = "Bob",
            Class = "Junior",
			Email = "billybobminecraft89@gmail.com",
			ContactEmails = new List<string>{ "asdfqwerty@gmail.com" }
		};

		string[] test =
		{
			"Cody", "Anderson",
			"Natasha", "Draia",
			"Deion", "Hareg",
			"Jesse", "Thompson",
			"Olivia", "ForgotLastName",
			"Leah", "Cunningham",
			"Hannah", "Walker",
			"Mark", "Torsney",
			"Jack", "Boggess",
			"Ryan", "Kelch",
			"Serge", "Gariepy",
			"LeAnn", "Gariepy",
			"Rylan", "Yamamoto",
			"Marty", "Briggs",
			"Lyra", "Lacson",
			"Harry", "ForgotLastName",
			"Bruce", "Boggess",
			"Kitso", "the Cat"
		};

		for (var i = 0; i < test.Length; i+=2)
		{
			var temp = new Recipient
			{
				FirstName = test[i],
				LastName = test[i+1],
				Class = "Staff"
			};

			AllRecipients.Add(temp);
		}

		AllRecipients.Add(aiden);
		AllRecipients.Add(samantha);
		AllRecipients.Add(billy);
	}
}
