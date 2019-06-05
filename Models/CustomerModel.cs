using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Northwind.Models
{
    public class CustomerModel : IDisposable
    {
        private SqlConnection connection;

        public CustomerModel()
        {
            string strConn = @"Data Source =DESKTOP-HE7ITUQ\SQLEXPRESS; Initial Catalog=Northwind;Integrated Security=true;Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";                       
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Customer customer)
        {

        }

        public IList<Customer> Read()
        {
            IList<Customer> customers = new List<Customer>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * from Customers";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
             Customer customer = new Customer();                
             customer.CustomerID    = (string)reader["CustomerID"];
             customer.CompanyName   = (string)reader["CompanyName"];
             customer.ContactName   = (string)reader["ContactName"];
             customer.ContactTitle  = (string)reader["ContactTitle"];
             customer.Address       = (string)reader["Address"];
             customer.City          = (string)reader["City"];
             customer.Region        = reader["Region"].GetType().ToString() == "System.DBNull" ? string.Empty : (string)reader["Region"]; 
             customer.PostalCode    = reader["PostalCode"].GetType().ToString() == "System.DBNull" ? string.Empty: (string)reader["PostalCode"];
             customer.Country       = (string)reader["Country"];
             customer.Phone         = (string)reader["Phone"];
             customer.Fax           = reader["Fax"].GetType().ToString() == "System.DBNull" ? string.Empty : (string)reader["Fax"];

            customers.Add(customer);
            }

            return customers;

        }


    }
}