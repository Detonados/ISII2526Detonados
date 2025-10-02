using System;
using System.Collections.Generic;

namespace AppForSEII2526.API.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DeliveryAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;
        public DateTime RentalDateFrom { get; set; }
        public DateTime RentalDateTo { get; set; }
        public double TotalPrice { get; set; }

        // Relación uno-a-muchos con RentDevice
        public IList<RentDevice> RentedDevices { get; set; } = new List<RentDevice>();

        public override bool Equals(object obj) => obj is Rental r && this.Id == r.Id;
        public override int GetHashCode() => Id.GetHashCode();
    }
}