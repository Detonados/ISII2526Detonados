using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppForSEII2526.API.Models
{
    public class Purchase
    {
        [Key] // Clave primaria
        public int Id { get; set; }

        [Required] // Requisito
        [MaxLength(100)]
        public string CustomerUserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerUserSurname { get; set; }

        [Required]
        [MaxLength(200)]
        public string DeliveryAddress { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TotalQuantity { get; set; }

        // Relación uno n con PurchaseItem
        public IList<PurchaseItem> PurchaseItems { get; set; }

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
