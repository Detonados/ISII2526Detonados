using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ReceiptItem
{
    [Required(ErrorMessage = "El modelo es obligatorio.")]
    [StringLength(100, ErrorMessage = "El modelo no puede superar los 100 caracteres.")]
    public string Model { get; set; }

    [Key, Column(Order = 0)]
    [ForeignKey("Receipt")]
    [Required(ErrorMessage = "El identificador del recibo es obligatorio.")]
    public int ReceiptId { get; set; }

    public Receipt Receipt { get; set; }
    public Repair Repair { get; set; }

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
