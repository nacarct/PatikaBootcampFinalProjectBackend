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
    public class PaymentLineRepository: IPaymentLineRepository
    {
        public string OracleConnectionString = OracleContext.ConnectionString;

        public List<PaymentLine> GetAllPaymentLines()
        {
            var list = new List<PaymentLine>();

            using var oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM PAYMENTLINES";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return list;

            while (reader.Read())
            {
                list.Add(new PaymentLine()
                {
                    PaymentLineId = reader["PAYMENTLINEID"].ToInt(),
                    PaymentId = reader["PAYMENTID"].ToInt(),
                    PartNo = reader["PARTNO"].ToInt(),
                    Amount = reader["AMOUNT"].ToDouble(),
                    IsPaid = Convert.ToChar(reader["ISPAID"]),
                });
            }

            oracleConnection.Close();

            return list;
        }

        public List<PaymentLine> GetPaymentLinesByPaymentId(int paymentId)
        {
            var list = new List<PaymentLine>();

            using var oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM PAYMENTLINES WHERE PAYMENTID = {paymentId}";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return list;

            while (reader.Read())
            {
                list.Add(new PaymentLine()
                {
                    PaymentLineId = reader["PAYMENTLINEID"].ToInt(),
                    PaymentId = reader["PAYMENTID"].ToInt(),
                    PartNo = reader["PARTNO"].ToInt(),
                    Amount = reader["AMOUNT"].ToDouble(),
                    IsPaid = Convert.ToChar(reader["ISPAID"]),
                });
            }

            oracleConnection.Close();

            return list;
        }

        public PaymentLine GetPaymentLineById(int paymentLineId)
        {
            var paymentLine = new PaymentLine();

            using var oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM PAYMENTLINES WHERE PAYMENTLINEID = {paymentLineId}";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return paymentLine;

            while (reader.Read())
            {
                paymentLine = new PaymentLine()
                {
                    PaymentLineId = reader["PAYMENTLINEID"].ToInt(),
                    PaymentId = reader["PAYMENTID"].ToInt(),
                    PartNo = reader["PARTNO"].ToInt(),
                    Amount = reader["AMOUNT"].ToDouble(),
                    IsPaid = Convert.ToChar(reader["ISPAID"]),
                };
            }

            oracleConnection.Close();

            return paymentLine;
        }

        public void AddPaymentLine(PaymentLine paymentLine)
        {
            using var oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            var command = oracleConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_PAYMENTLINE_INSERT";
            command.Parameters.Add("P_PAYMENTID", OracleDbType.Int32).Value = paymentLine.PaymentId;
            command.Parameters.Add("P_PARTNO", OracleDbType.Int32).Value = paymentLine.PartNo;
            command.Parameters.Add("P_AMOUNT", OracleDbType.Double).Value = paymentLine.Amount;
            command.Parameters.Add("P_ISPAID", OracleDbType.NChar).Value = paymentLine.IsPaid;
            command.ExecuteNonQuery();
            oracleConnection.Close();
        }
    }
}