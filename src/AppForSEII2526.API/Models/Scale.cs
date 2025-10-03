using System;
using System.Collections.Generic;

public class Scale
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Repair> Repairs { get; set; } = new List<Repair>();

    public Scale() { }
    public Scale(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override bool Equals(object obj)
    {
        return obj is Scale scale &&
               Id == scale.Id &&
               Name == scale.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}


