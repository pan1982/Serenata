using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SQLite;
using System.Data;

namespace SerenataflowersTest.Models
{
    public class GoodsContext
    {
        SQLiteConnection dbConn;
        public SQLiteConnection DBConn { get; set; }

        public GoodsContext()
        {
            try
            {
                dbConn = new SQLiteConnection(@"Data Source = |DataDirectory|\SFDB.db; Version=3");
                DBConn = dbConn;
            }
            catch
            {
                dbConn = null;
                DBConn = dbConn;
            }
        }

        public IEnumerable<Good> GetData(int id)
        {
            DataTable dt = new DataTable();
            dbConn.Open();

            string query;
            query = $"Select * from Cars where Cars.Id in ({id})"; 

            SQLiteDataAdapter da = new SQLiteDataAdapter(query, dbConn);
            try
            {
                da.Fill(dt);
            }
            catch
            {
                this.GetData();
            }
            var t = dt.AsEnumerable().Select(
                                                row => new Good
                                                {
                                                    Id = Convert.ToInt32(row["Id"]),
                                                    Name = Convert.ToString(row["Name"]),
                                                    Manufacturer = Convert.ToString(row["Manufacturer"]),
                                                    Model = Convert.ToString(row["Model"]),
                                                    Price = String.Format("{0:C}", Convert.ToDouble(row["Price"]))
                                                }
                                                );
            
            return t;
        }

        public IEnumerable<Good> GetData(string Manufacturers = "")
        {
            DataTable dt = new DataTable();
            dbConn.Open();

            string query;
            if (Manufacturers == null || Manufacturers == "") { query = $"Select * from Cars"; }
            else {  query = $"Select * from Cars where Cars.Manufacturer in (\"{ Manufacturers.Replace(",","\",\"")}\")"; }

            SQLiteDataAdapter da = new SQLiteDataAdapter(query, dbConn);
            try
            {
                da.Fill(dt);
            }
            catch 
            {
                this.GetData();
            }
            var t = dt.AsEnumerable().Select(
                                                row => new Good
                                                {
                                                    Id = Convert.ToInt32(row["Id"]),
                                                    Name = Convert.ToString(row["Name"]),
                                                    Manufacturer = Convert.ToString(row["Manufacturer"]),
                                                    Model = Convert.ToString(row["Model"]),
                                                    Price = String.Format("{0:C}", Convert.ToDouble(row["Price"]))
                                                }
                                                );
            return t;
        }


        public IEnumerable<Cart> GetCart()
        {
            DataTable dt = new DataTable();
            dbConn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("Select Cars.Id, Cars.Name, Count(Cars.Name) Qty, sum(Cars.Price) Sum from Cars , Cart where Cars.Id = Cart.GoodId group by Cars.Name", dbConn);
            da.Fill(dt);
            var t = dt.AsEnumerable().Select(
                                                row => new Cart
                                                {
                                                    Id = Convert.ToInt32(row["Id"]),
                                                    GoodName = Convert.ToString(row["Name"]),
                                                    GoodQty = Convert.ToInt32(row["Qty"]),
                                                    GoodSum = String.Format("{0:C}", Convert.ToDouble(row["Sum"]))
                                                }
                                                );
            return t;
        }
        
        public bool AddToCart(int goodId)
        {
            try
            {
                dbConn.Open();
                using (SQLiteCommand command = new SQLiteCommand(dbConn))
                {
                    command.CommandText = $"INSERT INTO Cart (GoodId) VALUES ({goodId});";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                dbConn.Close();
                return true;
            }
            catch
            { dbConn.Close(); return false; }

        }

        public bool DeleteItem (int goodId)
        {
            try
            {
                dbConn.Open();
                using (SQLiteCommand command = new SQLiteCommand(dbConn))
                {
                    command.CommandText = $"Delete from Cart WHERE Cart.GoodId = {goodId};";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                dbConn.Close();
                return true;
            }
            catch 
            { dbConn.Close(); return false; }

        }

        public bool ClearCart()
        {
            try
            {
                dbConn.Open();
                using (SQLiteCommand command = new SQLiteCommand(dbConn))
                {
                    command.CommandText = @"DELETE FROM Cart;";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                dbConn.Close();
                return true;
            }
            catch
            { dbConn.Close(); return false; }

        }
    }
}