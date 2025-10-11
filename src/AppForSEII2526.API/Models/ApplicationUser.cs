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
    public string Name
    {
        get;
        set;
    }

    //---------------------
    //relaciones
    //---------------------
    //Si no las inicializo peta con null posiblemente. mejor un vacio

    public IList<Purchase> Purchase { get; set; } = new List<Purchase>();
    public IList<Rental> Rentals { get; set; } = new List<Rental>();
    public IList<Receipt> Receipts { get; set; } = new List<Receipt>();
    //---------------------

    [Display(Name = "Surname")]
    public string Surname
    {
        get;
        set;
    }
}

