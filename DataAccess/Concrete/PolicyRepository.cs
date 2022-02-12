using System;
using System.Collections.Generic;
using System.Data;
using CoreConvertingTools;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Oracle.ManagedDataAccess.Client;

namespace DataAccess.Concrete
{
    public class PolicyRepository:IPolicyRepository
    {
        public string OracleConnectionString = OracleContext.ConnectionString;

        public List<PolicyView> GetAllPolicyView()
        {
            List<PolicyView> list = new List<PolicyView>();

            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM VW_POLICIES";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return list;

            while (reader.Read())
            {
                list.Add(new PolicyView()
                {
                    PolicyId = reader["POLICYID"].ToInt(),
                    PolicyNo = reader["POLICYNO"].ToString(),
                    InsurerId = reader["INSURERID"].ToInt(),
                    InsrFirstName = reader["INSRFIRSTNAME"].ToString(),
                    InsrLastName = reader["INSRLASTNAME"].ToString(),
                    InsrBirthDate = reader["INSRBIRTHDATE"].ToDateTime(),
                    InsrGender = reader["INSRGENDER"].ToString(),
                    InsrPhone = reader["INSRPHONE"].ToString(),
                    InsrAddress = reader["INSRADDRESS"].ToString(),
                    InsuredId = reader["INSUREDID"].ToInt(),
                    FirstName = reader["FIRSTNAME"].ToString(),
                    LastName = reader["LASTNAME"].ToString(),
                    BirthDate = reader["BIRTHDATE"].ToDateTime(),
                    Gender = reader["GENDER"].ToString(),
                    Phone = reader["PHONE"].ToString(),
                    Address = reader["ADDRESS"].ToString(),
                    Height = reader["HEIGHT"].ToInt(),
                    Weight = reader["WEIGHT"].ToInt(),
                    Relation = reader["RELATION"].ToString(),
                    ProductId = reader["PRODUCTID"].ToInt(),
                    ProductName = reader["PRODUCTNAME"].ToString(),
                    Amount = reader["AMOUNT"].ToDouble(),
                    IsPaid = Convert.ToChar(reader["ISPAID"]),
                    IsAllPaid = Convert.ToChar(reader["ISALLPAID"]),
                    PaymentPart = reader["PAYMENTPART"].ToInt(),
                    PaymentAmount = reader["PAYMENTAMOUNT"].ToDouble(),
                    CreateDate = reader["CREATEDATE"].ToDateTime(),
                    PaidPart = reader["PAYMENTPART"].ToInt()
                });
            }

            oracleConnection.Close();

            return list;
        }

        public List<Policy> GetAllPolicy()
        {
            List<Policy> list = new List<Policy>();

            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM VW_POLICIES";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return list;

            while (reader.Read())
            {
                list.Add(new Policy()
                {
                    PolicyId = reader["POLICYID"].ToInt(),
                    PolicyNo = reader["POLICYNO"].ToString(),
                    InsurerId = reader["INSURERID"].ToInt(),
                    InsuredId = reader["INSUREDID"].ToInt(),
                    ProductId = reader["PRODUCTID"].ToInt(),
                    CreateDate = reader["CREATEDATE"].ToDateTime(),
                    Amount = reader["AMOUNT"].ToDouble(),
                    IsPaid = Convert.ToChar(reader["ISPAID"]),
                    Height = reader["HEIGHT"].ToInt(),
                    Weight = reader["WEIGHT"].ToInt(),
                    Relation = reader["RELATION"].ToString()
                });
            }

            oracleConnection.Close();

            return list;
        }

        public string AddPolicy(Policy policy)
        {
            var policyNo = Guid.NewGuid().ToString();

            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            policy.PolicyNo = policyNo;

            OracleCommand command = oracleConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_POLICY_INSERT";
            command.Parameters.Add("P_POLICYNO", OracleDbType.Varchar2).Value = policy.PolicyNo;
            command.Parameters.Add("P_INSURERID", OracleDbType.Int32).Value = policy.InsurerId;
            command.Parameters.Add("P_INSUREDID", OracleDbType.Int32).Value = policy.InsuredId;
            command.Parameters.Add("P_PRODUCTID", OracleDbType.Int32).Value = policy.ProductId;
            command.Parameters.Add("P_AMOUNT", OracleDbType.Double).Value = policy.Amount;
            command.Parameters.Add("P_HEIGHT", OracleDbType.Double).Value = policy.Height;
            command.Parameters.Add("P_WEIGHT", OracleDbType.Double).Value = policy.Weight;
            command.Parameters.Add("P_RELATION", OracleDbType.Varchar2).Value = policy.Relation;
            command.ExecuteNonQuery();
            oracleConnection.Close();

            return policyNo;
        }
    }
}