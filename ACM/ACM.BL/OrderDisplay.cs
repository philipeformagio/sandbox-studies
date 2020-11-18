using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class OrderDisplay
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public List<OrderDisplayItem> OrderDisplayItemList { get; set; }
    }
}
