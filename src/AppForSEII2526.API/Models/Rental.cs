using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppForSEII2526.API.Models
{
    public class Rental
    {
        // Clave primaria
        [Key]
        public int Id { get; set; }

        // Campos requeridos y restricciones
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "La dirección de entrega es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres.")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required(ErrorMessage = "La fecha de alquiler es obligatoria.")]
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "La fecha de inicio del alquiler es obligatoria.")]
        public DateTime RentalDateFrom { get; set; }

        [Required(ErrorMessage = "La fecha de fin del alquiler es obligatoria.")]
        public DateTime RentalDateTo { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio total debe ser positivo.")]
        public double TotalPrice { get; set; }

        // Relación uno-a-muchos con RentDevice
        public IList<RentDevice> RentedDevices { get; set; } = new List<RentDevice>();

        public override bool Equals(object obj) => obj is Rental r && this.Id == r.Id;
        public override int GetHashCode() => Id.GetHashCode();
    }
}