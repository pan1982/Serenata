using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SerenataflowersTest.Models;
using System.Data.Entity;
using System.Data;

namespace SerenataflowersTest.Controllers
{
    public class ValuesController : ApiController
    {
        GoodsContext db = new GoodsContext();

        public IEnumerable<Good> GetGoods(string Manufacturers)
        {
            return db.GetData(Manufacturers);
        }

        public IEnumerable<Good> GetGood(int id)
        {
            return db.GetData(id);
        }

        public List<string> GetModels()
        {
            IEnumerable<Good> table = db.GetData();

            var models = (from m in table group m.Model by m.Model into model select model.Key).ToList();
            return models;
        }

        public List<string> GetManufacturers()
        {
            IEnumerable<Good> table = db.GetData();

            var manufactures = (from m in table group m.Manufacturer by m.Manufacturer into manufacturer select manufacturer.Key).ToList();
            return manufactures;
        }


    }
}
