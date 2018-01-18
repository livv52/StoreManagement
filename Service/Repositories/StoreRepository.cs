using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Entities;
using Service.Interfaces;
using System.Data.SqlClient;

namespace Service.Repositories
{
    public class StoreRepository : IStoreRepository
    {   private string _connectionString = "data source=.\\SQLEXPRESS;  Initial Catalog = Stores_db; integrated security=True";

        public void Delete(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "DELETE FROM Store WHERE StoreId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            
        }

        public Store Get(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT * from Store where StoreId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                var store = new Store();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            store.StoreId = reader.GetInt32(0);
                            store.Name = reader.GetString(1);
                            
                        }
                    }

                }
                return store;
            }
            

        }

        public Store Insert(Store store)
        {
            
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "INSERT INTO Store (Name) VALUES (@name)";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@name", store.Name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return new Store();

        }

        public List<Store> List()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT * from Store";
                var cmd = new SqlCommand(Command, con);
                con.Open();
                var storeList = new List<Store>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.HasRows)
                    {
                        var store = new Store();
                        while (reader.Read())
                        {
                            store.StoreId = reader.GetInt32(0);
                            store.Name = reader.GetString(1);

                        }
                        storeList.Add(store);
                        reader.NextResult();
                    }
                    

                }
                return storeList;
            }
        }

        public bool Update(Store store)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "UPDATE Store SET Name = @name WHERE StoreId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@name", store.Name);
                cmd.Parameters.AddWithValue("@id", store.StoreId);
                con.Open();     
                bool result = false;
                if (cmd.ExecuteNonQuery() > 0) result = true;
                return result;
            }
          
        }
    }
}
