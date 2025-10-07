using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public PaymentMethodTypes PaymentMethod { get; set; }

    [Required(ErrorMessage = "La fecha del recibo es obligatoria.")]
    public DateTime ReceiptDate { get; set; }

    [Required(ErrorMessage = "El precio total es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio total debe ser un valor positivo.")]
    public double TotalPrice { get; set; }

    public List<ReceiptItem> ReceiptItems { get; set; } = new();

    public override bool Equals(object obj)
    {
        if (obj is Receipt other)
            return Id == other.Id;
        return false;
    }

    public Receipt() { }

    public Receipt(int id, string customerNameSurname, string deliveryAddress, PaymentMethodTypes paymentMethod, DateTime receiptDate, double totalPrice)
    {
        Id = id;
        CustomerNameSurname = customerNameSurname;
        DeliveryAddress = deliveryAddress;
        PaymentMethod = paymentMethod;
        ReceiptDate = receiptDate;
        TotalPrice = totalPrice;
    }
}