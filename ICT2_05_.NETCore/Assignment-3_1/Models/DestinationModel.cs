namespace Assignment_3_1.Models
{
    public class DestinationModel
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public string Country { get; set; }

        public int EstimatedCost { get; set; }

        public string BestSeason { get; set; }
    }
}
