namespace AppForSEII2526.API.Models
{
    public class ReviewItem {
        [Key]
        public int reviewid { get; set; }
        //Clase de funcionamiento al igual qye PaymentMethod..
        [Required(ErrorMessage = "El valor es obligatorio.")]
        [Range(0, 5, ErrorMessage = "El valor debe estar entre 0 y 5.")]
        public int? Rating { get; set; }
        [Required(ErrorMessage = " El comentario no puede estar vacio.")]
        [StringLength(500, ErrorMessage = "El comentario no puede superar los 500 caracteres.")]
        public string? Comment { get; set; }

    }
}
