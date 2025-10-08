using Microsoft.AspNetCore.Identity;

namespace AppForSEII2526.API.Models;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
    }
    public ApplicationUser(string id, string name, string surname, string userName)
    {
        Id = id;
        Name = name;
        Surname = surname;
        UserName = userName;
        Email = userName;
    }

    [Display(Name = "Name")]
    public string? Name
    {
        get;
        set;
    }

    //---------------------
    public IList<Purchase> Purchase { get; set; }
    public IList<Rental> Rentals { get; set; }

    //---------------------

    [Display(Name = "Surname")]
    public string? Surname
    {
        get;
        set;
    }
}

