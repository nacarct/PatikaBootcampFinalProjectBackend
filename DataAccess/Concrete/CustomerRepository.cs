using System.Collections.Generic;
using System.Data;
using CoreConvertingTools;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Oracle.ManagedDataAccess.Client;

namespace DataAccess.Concrete
{
    public class CustomerRepository:ICustomerRepository
    {
        public string OracleConnectionString = OracleContext.ConnectionString;

        public List<Customer> GetAllCustomers()
        {
            List<Customer> list = new List<Customer>();

            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM CUSTOMERS";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return list;

            while (reader.Read())
            {
                list.Add(new Customer()
                {
                    CustomerId = reader["CUSTOMERID"].ToInt(),
                    CustomerTcKn = reader["CUSTOMERTCKN"].ToString(),
                    FirstName = reader["FIRSTNAME"].ToString(),
                    LastName = reader["LASTNAME"].ToString(),
                    BirthDate = reader["BIRTHDATE"].ToDateTime(),
                    Gender = reader["GENDER"].ToString(),
                    Phone = reader["PHONE"].ToString(),
                    Address = reader["ADDRESS"].ToString()
                });
            }

            oracleConnection.Close();

            return list;
        }

        public Customer GetByTcKn(string tcKn)
        {
            var customer = new Customer();

            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM CUSTOMERS WHERE CUSTOMERTCKN = '{tcKn}' ";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return customer;

            while (reader.Read())
            {
                customer = new Customer()
                {
                    CustomerId = reader["CUSTOMERID"].ToInt(),
                    CustomerTcKn = reader["CUSTOMERTCKN"].ToString(),
                    FirstName = reader["FIRSTNAME"].ToString(),
                    LastName = reader["LASTNAME"].ToString(),
                    BirthDate = reader["BIRTHDATE"].ToDateTime(),
                    Gender = reader["GENDER"].ToString(),
                    Phone = reader["PHONE"].ToString(),
                    Address = reader["ADDRESS"].ToString()
                };
            }

            oracleConnection.Close();

            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            OracleCommand command = oracleConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CUSTOMER_INSERT";
            command.Parameters.Add("P_CUSTOMERTCKN", OracleDbType.NVarchar2).Value = customer.CustomerTcKn;
            command.Parameters.Add("P_FIRSTNAME", OracleDbType.NVarchar2).Value = customer.FirstName;
            command.Parameters.Add("P_LASTNAME", OracleDbType.NVarchar2).Value = customer.LastName;
            command.Parameters.Add("P_BIRTHDATE", OracleDbType.Date).Value = customer.BirthDate;
            command.Parameters.Add("P_GENDER", OracleDbType.NVarchar2).Value = customer.Gender;
            command.Parameters.Add("P_PHONE", OracleDbType.NVarchar2).Value = customer.Phone;
            command.Parameters.Add("P_ADDRESS", OracleDbType.NVarchar2).Value = customer.Address;
            command.ExecuteNonQuery();
            oracleConnection.Close();
        }

        public void UpdateCustomer(Customer customer)
        {
            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            OracleCommand command = oracleConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CUSTOMER_UPDATE";
            command.Parameters.Add("P_CUSTOMERID", OracleDbType.NVarchar2).Value = customer.CustomerId;
            command.Parameters.Add("P_CUSTOMERTCKN", OracleDbType.NVarchar2).Value = customer.CustomerTcKn;
            command.Parameters.Add("P_FIRSTNAME", OracleDbType.NVarchar2).Value = customer.FirstName;
            command.Parameters.Add("P_LASTNAME", OracleDbType.NVarchar2).Value = customer.LastName;
            command.Parameters.Add("P_BIRTHDATE", OracleDbType.Date).Value = customer.BirthDate;
            command.Parameters.Add("P_GENDER", OracleDbType.NVarchar2).Value = customer.Gender;
            command.Parameters.Add("P_PHONE", OracleDbType.NVarchar2).Value = customer.Phone;
            command.Parameters.Add("P_ADDRESS", OracleDbType.NVarchar2).Value = customer.Address;
            command.ExecuteNonQuery();
            oracleConnection.Close();
        }
    }
}