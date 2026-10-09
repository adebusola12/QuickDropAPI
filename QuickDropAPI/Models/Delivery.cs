namespace QuickDropAPI.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public string RecipientName { get; set; }

        public string RecipientPhone { get; set; }

        public string PackageDescription { get; set; }

        public decimal DeliveryFee { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}