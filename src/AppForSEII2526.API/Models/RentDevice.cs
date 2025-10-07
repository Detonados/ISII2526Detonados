using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppForSEII2526.API.Models
{
    public class RentDevice
    {
        // Clave primaria compuesta (DeviceId + RentId)
        [Key, Column(Order = 0)]
        [Required(ErrorMessage = "El identificador del dispositivo es obligatorio.")]
        public int DeviceId { get; set; }

        [Key, Column(Order = 1)]
        [Required(ErrorMessage = "El identificador del alquiler es obligatorio.")]
        public int RentId { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser positivo.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Quantity { get; set; }
        public IList<Device> Devices { get; set; } = new List<Device>();
        public IList<Rental> Rental { get; set; } = new List<Rental>();

        // Constructor vacío
        public RentDevice() { }

        // Constructor con parámetros
        public RentDevice(int deviceId, int rentId, int quantity, double price)
        {
            DeviceId = deviceId;
            RentId = rentId;
            Quantity = quantity;
            Price = price;
        }

        // Sobrescribir Equals
        public override bool Equals(object obj)
        {

            return obj is RentDevice rd &&
                   rd.DeviceId == this.DeviceId &&
                   rd.RentId == this.RentId;
        }

        // Sobrescribir GetHashCode
        public override int GetHashCode()
        {
            return (DeviceId, RentId).GetHashCode();
        }
    }
}
