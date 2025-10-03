using System;

namespace AppForSEII2526.API.Models
{
    public class RentDevice
    {
        // Propiedades principales
        public int DeviceId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int RentId { get; set; }

        // Relaciones de navegación
        public Device Device { get; set; }
        public Rental Rent { get; set; }

        // Constructor vacío
        public RentDevice() { }

        // Constructor con parámetros
        public RentDevice(int deviceId, int rentId, int quantity, double price){
            DeviceId = deviceId;
            RentId = rentId;
            Quantity = quantity;
            Price = price;
        }

        // Sobrescribir Equals
        public override bool Equals(object obj){

            return obj is RentDevice rd &&
                   rd.DeviceId == this.DeviceId &&
                   rd.RentId == this.RentId;
        }

        // Sobrescribir GetHashCode
        public override int GetHashCode(){
            return (DeviceId, RentId).GetHashCode();
        }
    }
}
