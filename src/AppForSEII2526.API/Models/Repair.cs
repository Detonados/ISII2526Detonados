using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class Repair
{
    [Key] //Clave primaria
    public int Id { get; set; }

    //---------------------------------------------------------------------------------------
    //DataType Descripcion opcional
    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(100, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
    public string? Description { get; set; }

    //---------------------------------------------------------------------------------------
    //DataType precios

    [DataType(DataType.Currency)]
    [Display(Name = "Costo")]
    [Required(ErrorMessage = "El costo es obligatorio.")]
    [Precision(10, 2)]
    [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser positivo.")]
    public double Cost { get; set; }

    //---------------------------------------------------------------------------------------
    // Campos requeridos y restricciones (ATR) String
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Name { get; set; }
    //---------------------------------------------------------------------------------------
    // Relación muchos-a-uno con Scale y clave foranea
    [ForeignKey("Scale")]
    [Required(ErrorMessage = "El identificador de la balanza es obligatorio.")]
    public int ScaleId { get; set; }

    public Scale Scale { get; set; }
    //---------------------------------------------------------------------------------------
    // Relación uno n con ReceiptItem
    public List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
    //---------------------------------------------------------------------------------------
    //Constructores
    public Repair() { }
    public Repair(int id, string description, double cost, int scaleId)
    {
        Id = id;
        
        Description = description;
        Cost = cost;
        ScaleId = scaleId;
    }
    //---------------------------------------------------------------------------------------
    //metodos
    public override bool Equals(object obj)
    {
        return obj is Repair repair &&
               Id == repair.Id &&
              
               Description == repair.Description &&
               Cost == repair.Cost &&
               ScaleId == repair.ScaleId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Description, Cost, ScaleId);
    }
}