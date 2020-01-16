using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Models
{
    public class Candy
    {
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbNail { get; set; }
        public  bool IsOnSale { get; set; }
        public  bool IsOnStock { get; set; }
        public Catagory Catagory { get; set; }
        public int CatagoryId { get; set; }
        public decimal Price { get; set; }
    }

}
