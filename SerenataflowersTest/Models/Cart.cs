using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerenataflowersTest.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string GoodName { get; set; }
        public int GoodQty { get; set; }
        public string GoodSum { get; set; }
    }
}