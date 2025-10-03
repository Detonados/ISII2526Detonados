using System.Collections.Generic;



    public class Device
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public double PriceForPurchase { get; set; }
        public double PriceForRent { get; set; }
        public int QuantityForPurchase { get; set; }
        public int QuantityForRent { get; set; }
        public int Year { get; set; }

        // Relación muchos-a-uno con Model

        public Model Model { get; set; }

        // Relación uno-a-muchos con RentDevice
        //public IList<RentDevice> RentedDevices { get; set; } = new List<RentDevice>();

        // Otras relaciones (puedes definir las clases si las necesitas)
        //public IList<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
        //public IList<ReviewItem> ReviewItems { get; set; } = new List<ReviewItem>();

        public override bool Equals(object obj) => obj is Device d && this.Id == d.Id;
        public override int GetHashCode() => Id.GetHashCode();
    }

