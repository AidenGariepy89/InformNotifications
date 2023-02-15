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

    List<Student> GetRecipientsSorted()
    {
        if (sortByName)
        {
            return students!.Where(s => s.FullName.ToLower().Contains(searchQuery.ToLower())).OrderBy(s => s.LastName).ToList();
        }
        if (sortByYear)
        {
            return students!.Where(s => s.GraduationYear.ToLower().Contains(searchQuery.ToLower())).OrderBy(s => s.GraduationYear).ToList();
        }
        if (sortByEmail)
        {
            return students!.Where(s => s.EmailAddress.ToLower().Contains(searchQuery.ToLower())).OrderBy(s => s.EmailAddress).ToList();
        }
        if (sortByNumber)
        {
            return students!.Where(s => s.PhoneNumber.ToLower().Contains(searchQuery.ToLower())).OrderBy(s => s.PhoneNumber).ToList();
        }
        return students!;
    }

    void SelectionLogic(Student student)
    {
        if (selectedStudents.Contains(student))
        {
            selectedStudents.Remove(student);
        }
        else
        {
            selectedStudents.Add(student);
        }
    }

    bool IsSelected(Student student)
    {
        return selectedStudents.Contains(student);
    }

    void SelectView()
    {
        foreach (var student in GetRecipientsSorted())
        {
            if (!selectedStudents.Contains(student))
            {
                selectedStudents.Add(student);
            }
        }
    }

    void DeselectView()
    {
        foreach (var student in GetRecipientsSorted())
        {
            selectedStudents.Remove(student);
        }
    }

    void SelectAll()
    {
        selectedStudents.Clear();
        selectedStudents.AddRange(students!);
    }

    void DeselectAll()
    {
        selectedStudents.Clear();
    }

    #endregion
}
