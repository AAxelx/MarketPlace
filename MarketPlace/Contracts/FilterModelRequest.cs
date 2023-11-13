namespace MarketPlace.API.Contracts
{
	public class FilterModelRequest
	{
        public string Name { get; set; }
        public string Status { get; set; }
        public string SortOrder { get; set; }
        public string SortKey { get; set; }
        public int Limit { get; set; }
    }
}

