using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace AppForSEII2526.API.Models
{
    public class Purchase
    {
        [Key] // Clave primaria
        public int Id { get; set; }
        //---------------------------------------------------------------------------------------
       // Campos requeridos y restricciones (ATR)
        [Required(ErrorMessage = "La dirección de entrega es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La dirección de entrega no puede superar los 200 caracteres.")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "Añade una forma de pago.")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required(ErrorMessage = "La fecha de compra es obligatoria.")]
        [DataType(DataType.Date), Display(Name = "Fecha de Compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "El precio total es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio total debe ser igual o mayor que 0.")]
        
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "La cantidad total es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser igual o mayor que 1.")]
        [DataType(DataType.Currency)]
        public int TotalQuantity { get; set; }
        //  ---------------------------------------------------------------------------------------
        // Relación uno n con PurchaseItem
        public IList<PurchaseItem> PurchaseItems { get; set; }
        //  ---------------------------------------------------------------------------------------
        // relación con ApplicationUser
        public ApplicationUser ApplicationUser { get; set; }
        //  ---------------------------------------------------------------------------------------
        // Métodos Equals y GetHashCode
        public override bool Equals(object obj)
        {
            if (obj is not Purchase other) return false;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public Purchase()
        {
            PurchaseItems = new List<PurchaseItem>();
        }
    }
}
