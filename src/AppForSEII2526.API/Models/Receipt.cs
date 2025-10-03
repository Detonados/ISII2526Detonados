public enum PaymentMethodTypes
{
   Tarjeta de credito, 
   PayPal,
   Efectivo
}

public class Receipt
{
    public string CustomerNameSurname { get; set; }
    public string DeliveryAddress { get; set; }
    public int Id { get; set; }
    public PaymentMethodTypes PaymentMethod { get; set; }
    public DateTime ReceiptDate { get; set; }
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