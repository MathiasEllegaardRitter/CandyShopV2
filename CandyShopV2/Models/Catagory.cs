using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Models
{
    public class Catagory
    {
        public int CatagoryId { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryName { get; set; }
        public List<Candy> Candies { get; set; }
    }
}
