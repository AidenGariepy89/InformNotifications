using System;
using System.Collections.Generic;
using System.Text.Json;

namespace InformNotifications.Models;

internal class Recipient
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string FullName
	{
		get { return FirstName + " " + LastName; }
	}
	private RecipientClass recipientClass;
	public string Class
	{
		get
		{
			switch (recipientClass)
			{
				case RecipientClass.Freshmen:
					return "Freshmen";
				case RecipientClass.Sophomore:
					return "Sophomore";
				case RecipientClass.Junior:
					return "Junior";
				case RecipientClass.Senior:
					return "Senior";
				case RecipientClass.Staff:
					return "Staff";
				default:
					return "Error";
			}
		}
		set
		{
			switch (value)
			{
				case "Freshmen":
					recipientClass = RecipientClass.Freshmen;
					break;
				case "Sophomore":
					recipientClass = RecipientClass.Sophomore;
					break;
				case "Junior":
					recipientClass = RecipientClass.Junior;
					break;
				case "Senior":
					recipientClass = RecipientClass.Senior;
					break;
				case "Staff":
					recipientClass = RecipientClass.Staff;
					break;
				default:
					throw new ArgumentException("Invalid RecipientClass", nameof(value));
			}
		}
	}

    public enum RecipientClass
	{
		Freshmen = 0,
		Sophomore = 1,
		Junior = 2,
		Senior = 3,
		Staff = 4
	}
	public string Number { get; set; }
	public string Email { get; set; }
	public List<string> ContactNumbers { get; set; }
	public List<string> ContactEmails { get; set; }
}
