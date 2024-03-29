﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement
{


    public class Database
    {
        public static int SqlOperation(String command)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
            int RowsAffected;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand(command, connection))
                    {
                        connection.Open();
                        RowsAffected = cmd.ExecuteNonQuery();
                        return RowsAffected;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return RowsAffected = 0;
            }

        }
        public static DataTable ViewRecordsFromDB()
        {
            DataTable table = new DataTable();
            string ConnString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEES", connection))
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                   dataAdapter.Fill(table);
                    return table;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}