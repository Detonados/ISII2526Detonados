using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataType = System.ComponentModel.DataAnnotations.DataType;
namespace AppForSEII2526.API.Models
{
    public class RentDevice
    {
        // Clave primaria compuesta (DeviceId + RentId) Doable
        [Key, Column(Order = 0)]
        [Required(ErrorMessage = "El identificador del dispositivo es obligatorio.")]
        public int DeviceId { get; set; }

        [Key, Column(Order = 1)]
        [Required(ErrorMessage = "El identificador del alquiler es obligatorio.")]
        public int RentId { get; set; }
        //---------------------------------------------------------------------------------------

        // Precios
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser positivo.")]
        [Precision(18, 2)]
        public double Price { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Quantity { get; set; }
        //---------------------------------------------------------------------------------------
        // Relaciones muchos-a-uno con otras tablas
        public IList<Device> Devices { get; set; } = new List<Device>();
        public IList<Rental> Rental { get; set; } = new List<Rental>();
        //---------------------------------------------------------------------------------------
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
        //---------------------------------------------------------------------------------------

        // Metodos overload equals y gethashcode

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
