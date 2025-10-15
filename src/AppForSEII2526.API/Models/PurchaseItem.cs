using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace AppForSEII2526.API.Models
{
    [PrimaryKey(nameof(PurchaseId), nameof(DeviceId))]
    public class PurchaseItem
    {
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [MaxLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El identificador del dispositivo es obligatorio.")]
        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public Device Device { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser igual o mayor que 0.")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        //Claves foránea
        [Required(ErrorMessage = "El identificador de la compra es obligatorio.")]
        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Quantity { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is PurchaseItem other)
                return PurchaseId == other.PurchaseId && DeviceId == other.DeviceId && Description == other.Description;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PurchaseId, DeviceId, Description);
        }

        public PurchaseItem()
        {
        }
    }
}
