using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccesslayer
{
    public class ProductRepository
    {
        string connctionstring = "Data Source=DESKTOP-D90893D\\SQLEXPRESS;Initial Catalog=Sethupathi; User Id=sa;Password=sethu903;";
        SqlConnection DAL;
        ProductModel product = new ProductModel();
        public ProductRepository()
        {
            DAL = new SqlConnection(connctionstring);
        }
        public void Insert(ProductModel product)
        {
            try
            {
                var gst = product.Price * 10 / 100;
                product.Gst = gst;

                var Insertsql = ($"exec InsertProduct'{product.Name}',{product.Price},{product.Gst},{product.Weight},'{product.Description}'");

                DAL.Open();
                DAL.Execute(Insertsql);
                DAL.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not insert {ex.Message}");
            }


        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }
}
