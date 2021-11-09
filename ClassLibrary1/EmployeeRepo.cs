using EmployeeModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ClassLibrary1
{
    public class EmployeeRepo : IEmployeeRepo
    {
        IConfiguration Configuration;
        public EmployeeRepo(IConfiguration iConfiguration)
        {
            Configuration = iConfiguration;

        }

        public IEnumerable<EmployeeInfo> getAllEmployeeDetails()
        {
            List<EmployeeInfo> employeeInfolist = new List<EmployeeInfo>();
          
            using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("database")))
            {
                SqlCommand cmd = new SqlCommand("select* from Employee", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {

                    employeeInfolist.Add(new EmployeeInfo
                    {
                        EmployeeID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("EmployeeId")),
                        EmployeeDesignation = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EmployeeDesignation")),
                        EmployeeName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EmployeeName")),
                        EmployeeSalary = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("EmployeeSalary")),
                        EmployeeYearsOfExperience = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("EmployeeYearsOfExperience")),

                    });
                }
                sqlConnection.Close();

            }
            string x = JsonConvert.SerializeObject(employeeInfolist);
            return employeeInfolist;

        }


        public IEnumerable<EmployeeInfo> getEmployeeDetail(EmployeeInfo employeeInfo)
        {

            List<EmployeeInfo> employeeInfolist = new List<EmployeeInfo>();
            using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("database")))
            {
                SqlCommand cmd = new SqlCommand("select* from Employee where EmployeeId=@EmployeeId", sqlConnection);
                cmd.Parameters.Add("@EmployeeId", System.Data.SqlDbType.Int).Value=employeeInfo.EmployeeID;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {

                    employeeInfolist.Add(new EmployeeInfo
                    {
                        EmployeeID = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("EmployeeId")),
                        EmployeeDesignation = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EmployeeDesignation")),
                        EmployeeName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EmployeeName")),
                        EmployeeSalary = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("EmployeeSalary")),
                        EmployeeYearsOfExperience = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("EmployeeYearsOfExperience")),

                    });
                }
                sqlConnection.Close();

            }
            return employeeInfolist;

        }
        public Boolean InsertEmployeeDetail(EmployeeInfo employeeInfo)
        {

        
            using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("database")))
            {
                SqlCommand cmd = new SqlCommand("insert into Employee values(@EmployeeName,@EmployeeSalary,@EmployeeDesignation,@EmployeeYearsOfExperience)", sqlConnection);
                cmd.Parameters.Add("@EmployeeName", System.Data.SqlDbType.VarChar,100).Value = employeeInfo.EmployeeName;
                cmd.Parameters.Add("@EmployeeSalary", System.Data.SqlDbType.Money).Value = employeeInfo.EmployeeSalary;
                cmd.Parameters.Add("@EmployeeDesignation", System.Data.SqlDbType.VarChar,100).Value = employeeInfo.EmployeeDesignation;
                cmd.Parameters.Add("@EmployeeYearsOfExperience", System.Data.SqlDbType.Int).Value = employeeInfo.EmployeeYearsOfExperience;

                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

              
                sqlConnection.Close();
                return true;
            }
            
           

        }

        public Boolean DeleteEmployeeDetail(EmployeeInfo employeeInfo)
        {

            using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("database")))
            {
                SqlCommand cmd = new SqlCommand("Delete from  Employee where EmployeeId=@EmployeeId", sqlConnection);
                cmd.Parameters.Add("@EmployeeId", System.Data.SqlDbType.Int).Value = employeeInfo.EmployeeID;

                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();


                sqlConnection.Close();
                return true;
            }

        }
    }
}
