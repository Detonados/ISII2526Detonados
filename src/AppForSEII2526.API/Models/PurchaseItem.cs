namespace AppForSEII2526.API.Models
{
    public class PurchaseItem
    {
        // Atributos en el orden del diagrama
        public string Description { get; set; }
        public int DeviceId { get; set; }
        public double Price { get; set; }
        public int PurchaseId { get; set; }
        public int Quantity { get; set; }

        // Métodos en el orden del diagrama
        public override bool Equals(object obj)
        {
            if (obj is not PurchaseItem other) return false;
            return DeviceId == other.DeviceId && PurchaseId == other.PurchaseId;
        }

        public override int GetHashCode()
        {
            return (DeviceId, PurchaseId).GetHashCode();
        }

        public PurchaseItem()
        {
        }
    }
}
