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

        //public IEnumerable<ProductModel> Showall()
        //{
        //    try
        //    {
        //        var Showallquery = $"exec List";
        //        DAL.Open();
        //        var result = DAL.Query<ProductModel>(Showallquery);
        //        DAL.Close();
        //           if(result != null || result.Count()!=0)
        //           {
        //                return result;
        //           }              
        //    }
        //    catch (SqlException ex)
        //    { 
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch(Exception ex) 
        //    {
        //    Console.WriteLine(ex.Message);
        //    }
        //}
        public void Put(Decimal Price, string Name)
        {
            try
            {
               
                if (Price !=0 && Name.Length !=0 )
                {
                    var Gst = Price * 10 / 100;

                    var Update = ($"exec Put '{Name}',{Price},{Gst}");
                    DAL.Open();
                    DAL.Execute(Update);
                    DAL.Close();
                }
                else
                {

                }
               

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void Delete(string Name)
        {
            try
            {
                if(Name !=null && Name.Length !=0)
                {
                    var Delete = ($"exec Spremove '{Name}'");
                    DAL.Open();
                    DAL.Execute(Delete);
                    DAL.Close();
                }

            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
