using System;

public class ReceiptItem
{
    public string Model { get; set; }
    public int ReceiptId { get; set; }
    public int RepairId { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is ReceiptItem other)
            return ReceiptId == other.ReceiptId && RepairId == other.RepairId && Model == other.Model;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ReceiptId, RepairId, Model);
    }

    public ReceiptItem() { }

    public ReceiptItem(string model, int receiptId, int repairId)
    {
        Model = model;
        ReceiptId = receiptId;
        RepairId = repairId;
    }
}
