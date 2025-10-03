using System;
using System.Collections.Generic;

public class ReceiptItem
{
    public string Model { get; set; }
    public int ReceiptId { get; set; }
    public int RepairId { get; set; }

    public Repair Repair { get; set; }

    public ReceiptItem() { }
    public ReceiptItem(string model, int receiptId, int repairId)
    {
        Model = model;
        ReceiptId = receiptId;
        RepairId = repairId;
    }

    public override bool Equals(object obj)
    {
        return obj is ReceiptItem item &&
               Model == item.Model &&
               ReceiptId == item.ReceiptId &&
               RepairId == item.RepairId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Model, ReceiptId, RepairId);
    }
}

public enum PaymentMethodTypes
{
    Cash,
    CreditCard,
    DebitCard,
    Transfer
}
