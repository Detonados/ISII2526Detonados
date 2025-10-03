using System;
using System.Collections.Generic;

namespace AppForSEII2526.API.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string NameModel { get; set; }

        // Relación uno-a-muchos: un Model tiene muchos Devices h
        //public IList<Device> Devices { get; set; } = new List<Device>();

        public Model() { } 

        public Model(int id, string nameModel)
        {
            Id = id;
            NameModel = nameModel;
        }

        public override bool Equals(object obj)
        {
            return obj is Model m && this.Id == m.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}