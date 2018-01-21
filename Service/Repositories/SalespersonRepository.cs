using Service.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Service.DTOs;

namespace Service.Repositories
{
    public class SalespersonRepository : ISalespersonRepository
    {
        private string _connectionString = "data source=.\\SQLEXPRESS;  Initial Catalog = Stores_db; integrated security=True";

        public void Delete(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "DELETE FROM Salesperson WHERE SPId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public Salesperson Get(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT * from Salesperson where SPId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                var salesperson = new Salesperson();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            salesperson.SPId = reader.GetInt32(0);
                            salesperson.Firstname = reader.GetString(1);
                            salesperson.Lastname = reader.GetString(2);
                            salesperson.Description = reader.GetString(3);

                        }
                    }

                }
                return salesperson;
            }
        }

        public List<SalesPersonDistrictDTO> GetDistricts(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT DS.Position, D.Name, DS.DistrictSalespersonId FROM DistrictSalesperson AS DS LEFT JOIN District as D on D.DistrictId = DS.DistrictId WHERE DS.SPId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                var salesPersonDistrictsList = new List<SalesPersonDistrictDTO>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var salesPersonDistricts = new SalesPersonDistrictDTO();
                            salesPersonDistricts.Position= reader.GetString(0);
                            salesPersonDistricts.DistrictName = reader.GetString(1);
                            salesPersonDistricts.DistrictSalespersonId = reader.GetInt32(2);
                            salesPersonDistrictsList.Add(salesPersonDistricts);

                        }
                        reader.NextResult();
                    }

                }
                return salesPersonDistrictsList;
            }
        }

        public Salesperson Insert(Salesperson salesperson)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "INSERT INTO Salesperson (Firstname,Lastname,Description) VALUES (@firstname,@lastname,@description)";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@firstname", salesperson.Firstname);
                cmd.Parameters.AddWithValue("@lastname", salesperson.Lastname);
                cmd.Parameters.AddWithValue("@description", salesperson.Description);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return new Salesperson();
        }

        public List<Salesperson> List()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "SELECT * FROM Salesperson";
                var cmd = new SqlCommand(Command, con);
                con.Open();
                var salespersonList = new List<Salesperson>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        
                        while (reader.Read())
                        {
                            var salesperson = new Salesperson();
                            salesperson.SPId = reader.GetInt32(0);
                            salesperson.Firstname = reader.GetString(1);
                            salesperson.Lastname = reader.GetString(2);
                            salesperson.Description = reader.GetString(3);
  
                            salespersonList.Add(salesperson);

                        }
                       
                        reader.NextResult();
                    }


                }
                return salespersonList;
            }
        }

        public bool Update(Salesperson salesperson)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string Command = "UPDATE Salesperson SET Firstname = @firstname, Lastname = @lastname, Description = @description WHERE SPId = @id";
                var cmd = new SqlCommand(Command, con);
                cmd.Parameters.AddWithValue("@firstname", salesperson.Firstname);
                cmd.Parameters.AddWithValue("@lastname", salesperson.Lastname);
                cmd.Parameters.AddWithValue("@description", salesperson.Description);
                cmd.Parameters.AddWithValue("@id", salesperson.SPId);
                con.Open();
                bool result = false;
                if (cmd.ExecuteNonQuery() > 0) result = true;
                return result;
            }

        }
    }
}
