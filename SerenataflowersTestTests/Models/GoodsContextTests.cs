using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerenataflowersTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace SerenataflowersTest.Models.Tests
{
    [TestClass()]
    public class GoodsContextTests
    {
        GoodsContext controller = new GoodsContext();

        [TestMethod()]
        public void GetDataTest_by_id() 
        {
            var testGood = TestGood();
            var controller = new GoodsContext();
            var resultActual = controller.GetData(1).ToList();
            
            Assert.AreEqual(testGood[0].Id, resultActual[0].Id);
        }

        [TestMethod()]
        public void GetDataTest() // Check returning all data
        {
            var testGood = TestGood();
            
            var resultActual = controller.GetData().ToList();

            Assert.AreEqual(testGood.Count(), resultActual.Count());
        }

        [TestMethod()]
        public void GetCartTest()
        {
            var testCart = TestCart();
            var resultActual = controller.GetCart().ToList();

            Assert.AreEqual(testCart.Count(), resultActual.Count());
        }

        [TestMethod()]
        public void AddToCartTest()
        {
            bool expected = true;
            bool real = controller.AddToCart(1);
            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void DeleteItemTest()
        {
            bool expected = true;
            bool real = controller.DeleteItem(1);
            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void ClearCartTest()
        {
            bool expected = true;
            bool real = controller.ClearCart();
            Assert.AreEqual(expected, real);
        }

        public List<Good> TestGood()
        {
            List<Good> list =  new List<Good> { new Good { Id = 1, Name = "FORD E150", Manufacturer = "FORD", Model = "E150", Price = "500" },
                               new Good { Id = 5, Name = "Plymouth", Manufacturer = "Plymouth", Model = "2000", Price = "100" },
                               new Good { Id = 6, Name = "FORD Mustang GT 4.6", Manufacturer = "FORD", Model = "Mustang GT 4.6", Price = "2500" },
                               new Good { Id = 7, Name = "DODGE CHALLENGER", Manufacturer = "DODGE", Model = "CHALLENGER", Price = "1000" },
                               new Good { Id = 8, Name = "Chevrolet Corvette Convertible", Manufacturer = "Chevrolet", Model = "Corvette Convertible", Price = "1200" } };
            
            return list;

        }

        public List<Cart> TestCart()
        {
            List<Cart> list = new List<Cart> { new Cart { Id = 1, GoodName = "FORD E150", GoodQty = 1, GoodSum = "500" } };

            return list;

        }
    }
}