using System;
using System.Collections.Generic;

namespace AppForSEII2526.API.Models
{
    public class Purchase
    {
        //hola
        public string CustomerUserName { get; set; }
        public string CustomerUserSurname { get; set; }
        public string DeliveryAddress { get; set; }
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
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
