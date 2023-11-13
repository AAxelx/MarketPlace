using System;
namespace MarketPlace.SAL.Models
{
    public class FilterModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string SortOrder { get; set; }
        public string SortKey { get; set; }
        public int Limit { get; set; }
    }

}

