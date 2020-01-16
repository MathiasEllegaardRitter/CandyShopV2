using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CandyId { get; set; }
        public float Amount { get; set; }
        public Candy Candy { get; set; }
        public Order Order { get; set; }
        public decimal Price { get; set; }
    }
}
