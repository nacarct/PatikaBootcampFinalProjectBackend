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
    public class PaymentRepository:IPaymentRepository
    {
        public string OracleConnectionString = OracleContext.ConnectionString;

        public List<Payment> GetAllPayments()
        {
            var list = new List<Payment>();

            using var oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM PAYMENTS";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return list;

            while (reader.Read())
            {
                list.Add(new Payment()
                {
                    PaymentId = reader["PAYMENTID"].ToInt(),
                    PolicyId = reader["POLICYID"].ToInt(),
                    IsAllPaid = Convert.ToChar(reader["ISALLPAID"]),
                    PaymentPart = reader["PAYMENTPART"].ToInt(),
                    PaymentAmount = reader["PAYMENTAMOUNT"].ToDouble(),
                });
            }

            oracleConnection.Close();

            return list;
        }

        public Payment GetPaymentByPolicyId(int policyId)
        {
            var payment = new Payment();

            using var oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM PAYMENTS WHERE POLICYID = {policyId} ";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return payment;

            while (reader.Read())
            {
                payment = new Payment()
                {
                    PaymentId = reader["PAYMENTID"].ToInt(),
                    PolicyId = reader["POLICYID"].ToInt(),
                    IsAllPaid = Convert.ToChar(reader["ISALLPAID"]),
                    PaymentPart = reader["PAYMENTPART"].ToInt(),
                    PaymentAmount = reader["PAYMENTAMOUNT"].ToDouble(),
                };
            }

            oracleConnection.Close();

            return payment;
        }

        public void AddPayment(Payment payment)
        {
            using var oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            var command = oracleConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_PAYMENT_INSERT";
            command.Parameters.Add("P_POLICYID", OracleDbType.Int32).Value = payment.PolicyId;
            command.Parameters.Add("P_ISALLPAID", OracleDbType.NChar).Value = payment.IsAllPaid;
            command.Parameters.Add("P_PAYMENTPART", OracleDbType.Int32).Value = payment.PaymentPart;
            command.Parameters.Add("P_PAYMENTAMOUNT", OracleDbType.Double).Value = payment.PaymentAmount;
            command.ExecuteNonQuery();
            oracleConnection.Close();
        }
    }
}