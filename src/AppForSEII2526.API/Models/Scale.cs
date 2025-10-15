using System;
using System.Collections.Generic;

public class Scale
{
    [Key] // Clave primaria
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la balanza es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Name { get; set; }
    //---------------------------------------------------------------------------------------
    // Relación uno a muchos con Repair
    public List<Repair> Repairs { get; set; } = new List<Repair>();
    //---------------------------------------------------------------------------------------
    // Constructores
    public Scale() { }
    public Scale(int id, string name)
    {
        Id = id;
        Name = name;
    }
    //---------------------------------------------------------------------------------------
    // Métodos
    public override bool Equals(object obj)
    {
        return obj is Scale scale &&
               Id == scale.Id &&
               Name == scale.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}


