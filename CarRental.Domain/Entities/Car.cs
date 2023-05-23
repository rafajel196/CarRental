namespace CarRental.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }
        public decimal FuelConsumption { get; set; }
        public bool IsAvailable { get; set; }

        public CarAddress CarAddress { get; set; }
        public int CarAddressId { get; set; }
        public PriceCategory PriceCategory { get; set; }
        public int PriceCategoryId { get; set; }
    }
}
