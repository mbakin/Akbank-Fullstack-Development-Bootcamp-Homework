using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace DapperPOC_DBDesign.Models
{
    public class ProductRepository
    {
        private string connectionString;

        public ProductRepository()
        {
            connectionString = "Persist Security Info=False; User_ID=sa; password=123; Initial Catalog = DapperDb; Data Source= DESKTOP-HV5I445\LOCALDB#9896D183;Connection Timeout =100000;";
        }

        public IDbConnection Connection
        {
            get
            {
                return  new SqlConnection(connectionString);
            }
        }

        public void Add(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Products (Name,StockCount,Price) VALUES(@Name,@StockCount,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products Where ProductId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new {Id= id}).FirstOrDefault();
            }
        }
        public void  Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE * FROM Products Where ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new {Id = id});
            }
        }

        public void Update(Product product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE * FROM SET Name=@Name, StockCount=@StockCount,Price=@Price Where ProductId=@ProductId";
                dbConnection.Open();
                dbConnection.Query(sQuery, pro)
            }
        }
    } 
}
