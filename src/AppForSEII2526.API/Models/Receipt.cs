using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class Receipt
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre y apellido del cliente es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre y apellido no puede superar los 100 caracteres.")]
    public string CustomerNameSurname { get; set; }

    [Required(ErrorMessage = "La dirección de entrega es obligatoria.")]
    [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres.")]
    public string DeliveryAddress { get; set; }

    [Required(ErrorMessage = "El método de pago es obligatorio.")]
    public  PaymentMethod PaymentMethodTypes { get; set; }


    [DataType(DataType.Date), Display(Name = "Fecha")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime ReceiptDate { get; set; }

    [DataType(DataType.Currency)]
    [Display(Name = "Precio Total")]
    [Required(ErrorMessage = "El precio total es obligatorio.")]
    [Precision(10, 2)]
    [Range(0, double.MaxValue, ErrorMessage = "El precio de compra debe ser positivo.")]
    public double TotalPrice { get; set; }

    public List<ReceiptItem> ReceiptItems { get; set; } = new();

    public override bool Equals(object obj)
    {
        if (obj is Receipt other)
            return Id == other.Id;
        return false;
    }

    public Receipt() { }

    public Receipt(int id, string customerNameSurname, string deliveryAddress, PaymentMethod paymentMethodTypes, DateTime receiptDate, double totalPrice)
    {
        Id = id;
        CustomerNameSurname = customerNameSurname;
        DeliveryAddress = deliveryAddress;
        PaymentMethodTypes = paymentMethodTypes;
        ReceiptDate = receiptDate;
        TotalPrice = totalPrice;
    }
}