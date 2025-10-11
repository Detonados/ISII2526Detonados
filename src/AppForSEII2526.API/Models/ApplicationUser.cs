using Microsoft.AspNetCore.Identity;

namespace AppForSEII2526.API.Models;

public class ApplicationUser : IdentityUser //hereda de IdentityUser
{

    /*---------------------------------------------------------------------------------------
    Esta clase tiene herencia y no hereda surname, por lo que hay que definirlo
    todo lo demas lo hereda de IdentityUser (: IdentityUser)
    Declaramos name porque en la identityUser el UserName no es el nombre real, si no que puede ser nickname correo etc.
    por lo que name, no es un dato redundado
    *///--------------------------------------------------------------------------------------
    //ATRIBUTOS
    //---------------------------------------------------------------------------------------
    [Display(Name = "Surname")]
    public string Surname { get; set; }
    [Display(Name = "Name")]
    public string Name { get; set; }
    //---------------------------------------------------------------------------------------
    //constructores
    public ApplicationUser() { } //constructor vacio
    public ApplicationUser(string id, string name, string surname, string userName) //constructor lleno
    {
        Id = id;
        Name = name;
        Surname = surname;
        UserName = userName;
        Email = userName;
    }



    //---------------------
    //relaciones
    //---------------------
    //Si no las inicializo peta con null posiblemente. mejor un vacio
    //tipo lista porque es una relacion uno a muchos
    public IList<Purchase> Purchase { get; set; } = new List<Purchase>();
    public IList<Rental> Rentals { get; set; } = new List<Rental>();
    public IList<Receipt> Receipts { get; set; } = new List<Receipt>();
    //---------------------

    
}

