using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace AppForSEII2526.API.Models
{
    public class Device
    {


        // Clave primaria - Unica e Irrepetible, identificador primaria de tabla
        [Key]
        public int Id { get; set; }
        //---------------------------------------------------------------------------------------
        public enum QualityType
        {
            New,
            LikeNew,
            Used,
            Refurbished
        }
        //---------------------------------------------------------------------------------------
        // Campos requeridos y restricciones (ATR)
        [Required(ErrorMessage = "La marca es obligatoria.")]
        [StringLength(50, ErrorMessage = "La marca no puede superar los 50 caracteres.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "El color es obligatorio.")]
        [StringLength(30, ErrorMessage = "El color no puede superar los 30 caracteres.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Name { get; set; }
        //----------------------------------------------------------------------------------------

        //Precios currency type
        [DataType(DataType.Currency)]
        [Display(Name = "Precio de compra")]
        [Required(ErrorMessage = "El precio de compra es obligatorio.")]
        [Precision(10, 2)]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de compra debe ser positivo.")]
        public double? PriceForPurchase { get; set; } // Opcional
        [DataType(DataType.Currency)]
        [Display(Name = "Precio de alquiler")]
        [Precision(10, 2)]
        [Required(ErrorMessage = "El precio de alquiler es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de alquiler debe ser positivo.")]
        public double PriceForRent { get; set; }
        //---------------------------------------------------------------------------------------

        // Cantidades rango minimo 1
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad para compra debe ser positiva.")]
        public int? QuantityForPurchase { get; set; } // Opcional

        [Required(ErrorMessage = "La cantidad para alquiler es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad para alquiler debe ser positiva.")]
        public int QuantityForRent { get; set; }

        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100.")]
        public int? Year { get; set; } // Opcional

        //---------------------------------------------------------------------------------------


        // Relación muchos-a-uno con Model y clave foranea
        [ForeignKey("Model")]
        [Required(ErrorMessage = "El modelo es obligatorio.")]
        public Model Model { get; set; }

        // Relación uno-a-muchos con RentDevice
        public IList<RentDevice> RentedDevices { get; set; } = new List<RentDevice>();

        //---------------------------------------------------------------------------------------

        // Otras relaciones (puedes definir las clases si las necesitas)
        public IList<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
        public IList<ReviewItem> ReviewItems { get; set; } = new List<ReviewItem>();
        //---------------------------------------------------------------------------------------

        // Métodos Equals y GetHashCode basados en Id (Primary Key)
        public override bool Equals(object obj) => obj is Device d && this.Id == d.Id;
        public override int GetHashCode() => Id.GetHashCode();
    }
}

