using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppForSEII2526.API.Models
{
    public class PurchaseItem
    {
        [Key] // Clave primaria
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Device")]
        public int DeviceId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public Device Device { get; set; }
        public Purchase Purchase { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not PurchaseItem other) return false;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public PurchaseItem()
        {
        }
    }
}
