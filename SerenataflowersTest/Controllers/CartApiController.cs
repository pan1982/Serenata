using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SerenataflowersTest.Models;

namespace SerenataflowersTest.Controllers
{
    public class CartApiController : ApiController
    {
        GoodsContext db = new GoodsContext();
        // GET: api/Cart
        public IEnumerable<Cart> GetCart()
        {
            return db.GetCart();
        }

        [HttpPost]
        public void CreateItem(int id)
        {

            db.AddToCart(id);
        }

        // DELETE: api/Cart/5
        [HttpDelete]
        public void DeleteItem(int id)
        {
            db.DeleteItem(id);
        }
        [HttpDelete]
        public void ClearCart()
        {
            db.ClearCart();
        }
    }
}
