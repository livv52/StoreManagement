using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Entities;
using Service.Interfaces;
using System.Data.SqlClient;
using Service.DTOs;

namespace Service.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private string _connectionString = "data source=.\\SQLEXPRESS;  Initial Catalog = Stores_db; integrated security=True";

        public void Delete(int id)
        {
            var sPs = GetSalesperson(id);
            foreach(var sp in sPs)
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    string Command = "DELETE FROM  DistrictSalesperson  WHERE DistrictSalespersonId = @id";
                    var cmd = new SqlCommand(Command, con);
                    cmd.Parameters.AddWithValue("@id", sp.DistrictSalespersonId);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "DELETE FROM District WHERE DistrictId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public District Get(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT * from District where DistrictId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                var district = new District();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            district.DistrictId = reader.GetInt32(0);
                            district.Name = reader.GetString(1);

                        }
                    }

                }
                return district;
            }
        }

        public District Insert(DistrictDTO districtDto)
        {
            var district = new District {
                DistrictId = districtDto.DistrictId,
                Name = districtDto.Name
            };
            int newDistrictId;
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "INSERT INTO District (Name) VALUES (@name);SELECT CAST(scope_identity() AS int)";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@name", district.Name);
                con.Open();
                newDistrictId = (int)cmd.ExecuteScalar();
                Command = "INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (@SPId,@DistrictId,@Position)";

                foreach (var item in districtDto.SalesPersons)
                {
                    
                    cmd = new SqlCommand(Command, con);
                    cmd.Parameters.AddWithValue("@SPId", item.SPId);
                    cmd.Parameters.AddWithValue("@DistrictId", newDistrictId);
                    cmd.Parameters.AddWithValue("@Position", item.Position);
                    cmd.ExecuteNonQuery();
                }
            }
            return Get(newDistrictId);
        }

        public List<District> List()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT * from District";
                var cmd = new SqlCommand(Command, con);
                con.Open();
                var districtList = new List<District>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        

                        while (reader.Read())
                        {
                            var district = new District();
                            district.DistrictId = reader.GetInt32(0);
                            district.Name = reader.GetString(1);
                            districtList.Add(district);

                        }
                        
                        reader.NextResult();
                    }


                }
                return districtList;
            }
        }

        public bool Update(DistrictDTO districtDto)
        {
            var existingSPs = GetSalesperson(districtDto.DistrictId);
            updateSP(districtDto.SalesPersons, existingSPs, districtDto.DistrictId);

            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "UPDATE District SET Name = @name WHERE DistrictId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@name", districtDto.Name);
                cmd.Parameters.AddWithValue("@id", districtDto.DistrictId);
                con.Open();
                bool result = false;
                if (cmd.ExecuteNonQuery() > 0) result = true;
                return result;
            }
        }
        private void updateSP (List<SalesPersonDTO> updatedSPs, List<SalesPersonDTO> existingSPs, int districtId)
        {
            foreach (var eSP in existingSPs)
            {
                if (updatedSPs.All(p => p.DistrictSalespersonId != eSP.DistrictSalespersonId))
                {
                    //REMOVE EXISTING SP
                    using (var con = new SqlConnection(_connectionString))
                    {
                        string Command = "DELETE FROM  DistrictSalesperson  WHERE DistrictSalespersonId = @id";
                        var cmd = new SqlCommand(Command, con);
                        cmd.Parameters.AddWithValue("@id", eSP.DistrictSalespersonId);
                        con.Open();
                         cmd.ExecuteNonQuery();
                        
                    }
                }

            }
            foreach(var uSP in updatedSPs)
            {
                if(uSP.DistrictSalespersonId == 0)
                {
                    //add 
                    using (var con = new SqlConnection(_connectionString))
                    {
                        string Command = "INSERT INTO DistrictSalesPerson (SPId,DistrictId,Position) VALUES (@spId,@districtId,@position)";
                        var cmd = new SqlCommand(Command, con);
                        cmd.Parameters.AddWithValue("@spId", uSP.SPId);
                        cmd.Parameters.AddWithValue("@districtId", districtId);
                        cmd.Parameters.AddWithValue("@position", uSP.Position);
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
                else
                {
                    var existingChild = existingSPs.SingleOrDefault(e => e.DistrictSalespersonId == uSP.DistrictSalespersonId);
                    if(existingChild != null)
                    {
                        //update child 
                        using (var con = new SqlConnection(_connectionString))
                        {
                            string Command = "UPDATE DistrictSalesPerson SET SPId = @spid, DistrictId = @did, Position = @position WHERE DistrictSalespersonId = @id";
                            var cmd = new SqlCommand(Command, con);
                            cmd.Parameters.AddWithValue("@spid", uSP.SPId);
                            cmd.Parameters.AddWithValue("@did", districtId);
                            cmd.Parameters.AddWithValue("@position", uSP.Position);
                            cmd.Parameters.AddWithValue("@id", uSP.DistrictSalespersonId);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
            }

        }

        public List<Store> GetStores(int districtId)
        {
            using (var con = new SqlConnection(_connectionString))
            {

                string Command = "SELECT Store.StoreId, Store.Name,Store.DistrictId FROM Store LEFT JOIN District ON  Store.DistrictId = District.DistrictId WHERE District.DistrictId = @districtId";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@districtId", districtId);
                con.Open();
                var storesList = new List<Store>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            var store = new Store();
                            store.StoreId = reader.GetInt32(0);
                            store.Name = reader.GetString(1);
                            store.DistrictId = reader.GetInt32(2);
                            storesList.Add(store);

                        }

                        reader.NextResult();
                    }


                }
                return storesList;
            }

        }

        public List<SalesPersonDTO> GetSalesperson(int districtId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT S.SPId, S.Firstname,S.Lastname,S.Description, DS.Position, DS.DistrictSalespersonId FROM Salesperson AS S, DistrictSalesperson AS DS, District AS D WHERE DS.DistrictId = @districtId AND D.DistrictId = DS.DistrictId AND S.SPId = DS.SPId";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@districtId", districtId);
                con.Open();
                var salesPersonList = new List<SalesPersonDTO>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            var salesPerson = new SalesPersonDTO();
                            salesPerson.SPId = reader.GetInt32(0);
                            salesPerson.Firstname = reader.GetString(1);
                            salesPerson.Lastname = reader.GetString(2);
                            salesPerson.Description = reader.GetString(3);
                            salesPerson.Position = reader.GetString(4);
                            salesPerson.DistrictSalespersonId = reader.GetInt32(5);

                            salesPersonList.Add(salesPerson);

                        }

                        reader.NextResult();
                    }


                }
                return salesPersonList;
            }

        }

        public bool AddSalesPerson(DistrictSalesPerson districtSalesPerson)
        {

            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "INSERT INTO DistrictSalesPerson (SPId,DistrictId) VALUES (@spId,@districtId)";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@spId", districtSalesPerson.SPId);
                cmd.Parameters.AddWithValue("@districtId", districtSalesPerson.DistrictId);
                con.Open();
                bool result = false;
                if (cmd.ExecuteNonQuery() > 0) result = true;
                return result;
            }
            

        }

        public bool DeleteSalesPerson(int id)
        {

            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "DELETE FROM DistrictSalesPerson WHERE DistrictSalesPersonId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id", id);
               
                con.Open();
                bool result = false;
                if (cmd.ExecuteNonQuery() > 0) result = true;
                return result;
            }


        }


    }
}
