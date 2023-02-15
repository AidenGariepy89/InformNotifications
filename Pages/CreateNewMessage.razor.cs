using Microsoft.AspNetCore.Components;
using InformNotifications.Models;

namespace InformNotifications.Pages;

public partial class CreateNewMessage : ComponentBase
{   
    #region Enums

    enum FilterTypes
    {
        ByName,
        ByYear,
        ByEmail,
        ByNumber
    }
    enum Relation
    {
        OnlyStudent,
        OnlyParents,
        Both
    }
    enum DeliverProtocol
    {
        SMS,
        Email,
        Both
    }
    
    #endregion

    #region Methods

    void CancelMessage()
    {
        NavigationManager.NavigateTo("/");
    }

    void FilterOptions(FilterTypes filterTypes)
    {
        switch (filterTypes)
        {
            case FilterTypes.ByName:
                sortByName = true;
                sortByYear = false;
                sortByEmail = false;
                sortByNumber = false;
                break;
            case FilterTypes.ByYear:
                sortByName = false;
                sortByYear = true;
                sortByEmail = false;
                sortByNumber = false;
                break;
            case FilterTypes.ByEmail:
                sortByName = false;
                sortByYear = false;
                sortByEmail = true;
                sortByNumber = false;
                break;
            case FilterTypes.ByNumber:
                sortByName = false;
                sortByYear = false;
                sortByEmail = false;
                sortByNumber = true;
                break;
        }
    }

    List<Recipient> GetRecipientsSorted()
    {
        if (sortByName)
        {
            return recipients!.Where(r => r.Student.FullName.ToLower().Contains(searchQuery.ToLower())).OrderBy(r => r.Student.LastName).ToList();
        }
        if (sortByYear)
        {
            return recipients!.Where(r => r.Student.GraduationYear.ToLower().Contains(searchQuery.ToLower())).OrderBy(r => r.Student.GraduationYear).ToList();
        }
        if (sortByEmail)
        {
            return recipients!.Where(r => r.Student.EmailAddress.ToLower().Contains(searchQuery.ToLower())).OrderBy(r => r.Student.EmailAddress).ToList();
        }
        if (sortByNumber)
        {
            return recipients!.Where(r => r.Student.PhoneNumber.ToLower().Contains(searchQuery.ToLower())).OrderBy(r => r.Student.PhoneNumber).ToList();
        }
        return recipients!;
    }

    void SelectionLogic(Recipient recipient)
    {
        if (selectedRecipients.Contains(recipient))
        {
            selectedRecipients.Remove(recipient);
        }
        else
        {
            selectedRecipients.Add(recipient);
        }
    }

    bool IsSelected(Recipient recipient)
    {
        return selectedRecipients.Contains(recipient);
    }

    void SelectView()
    {
        foreach (var recipient in GetRecipientsSorted())
        {
            if (!selectedRecipients.Contains(recipient))
            {
                selectedRecipients.Add(recipient);
            }
        }
    }

    void DeselectView()
    {
        foreach (var recipient in GetRecipientsSorted())
        {
            selectedRecipients.Remove(recipient);
        }
    }

    void SelectAll()
    {
        selectedRecipients.Clear();
        selectedRecipients.AddRange(recipients!);
    }

    void DeselectAll()
    {
        selectedRecipients.Clear();
    }

    #endregion
}
