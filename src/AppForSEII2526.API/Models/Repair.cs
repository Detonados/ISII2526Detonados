using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Repair
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la reparación es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
    public string Description { get; set; }

    [DataType(DataType.Currency)]
    [Display(Name = "Costo")]
    [Required(ErrorMessage = "El costo es obligatorio.")]
    [Precision(10, 2)]
    [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser positivo.")]
    public float Cost { get; set; } 

    [ForeignKey("Scale")]
    [Required(ErrorMessage = "El identificador de la balanza es obligatorio.")]
    public int ScaleId { get; set; }

    public Scale Scale { get; set; }

    public List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();

    public Repair() { }
    public Repair(int id, string name, string description, float cost, int scaleId)
    {
        Id = id;
        Name = name;
        Description = description;
        Cost = cost;
        ScaleId = scaleId;
    }

    public override bool Equals(object obj)
    {
        return obj is Repair repair &&
               Id == repair.Id &&
               Name == repair.Name &&
               Description == repair.Description &&
               Cost == repair.Cost &&
               ScaleId == repair.ScaleId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Description, Cost, ScaleId);
    }
}