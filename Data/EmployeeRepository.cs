using Dapper;
using Microsoft.Data.SqlClient;
using TaskProj.Models;

namespace TaskProj.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository()
        {
            _connectionString = "Server=localhost\\SQLEXPRESS;Database=testdb;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public List<Employee> GetEmployees()
        {
            
            List<Employee> employees = new List<Employee>();
           
            using (SqlConnection myConnection = new SqlConnection(_connectionString))
            {
                string oString = "Select * from Employees";
                SqlCommand cmd = new SqlCommand(oString, myConnection);
          
                myConnection.Open();
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
         

                        employees.Add(new Employee {

                            EmployeeID= Convert.ToInt32(oReader["EmployeeId"].ToString()),
                            Name = oReader["Name"].ToString(),
                            Email = oReader["Email"].ToString(),
                            PhoneNumber = oReader["PhoneNumber"].ToString()

                        });
                    }
                    
                    myConnection.Close();
                }
            }
            return employees;
            
        }
    }
}
