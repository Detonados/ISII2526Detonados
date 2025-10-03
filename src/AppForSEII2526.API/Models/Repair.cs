using System;
using System.Collections.Generic;

public class Repair
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Cost { get; set; } 
    public int ScaleId { get; set; }

    public Scale Scale { get; set; }
    public List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();

    public Repair() { }
    public Repair(int id, string name, string description, float cost, int scaleId)
    {
        Id = id;
        Name = name;
        Description = description;
        Cost = cost;
        ScaleId = scaleId;
    }

    public override bool Equals(object obj)
    {
        return obj is Repair repair &&
               Id == repair.Id &&
               Name == repair.Name &&
               Description == repair.Description &&
               Cost == repair.Cost &&
               ScaleId == repair.ScaleId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Description, Cost, ScaleId);
    }
}