﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Scarpe_ECommerce.Models
{
    public class Shared
    {
        public static SqlConnection GetConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["Scarpe_Ecommerce"].ToString();
            SqlConnection sql = new SqlConnection(con);
            return sql;
        }

        public static SqlCommand GetCommand(string query, SqlConnection sql) 
        {
            SqlCommand com = new SqlCommand();
            com.Connection = sql;
            com.CommandText = query;
            return com;
        }

        public static SqlCommand GetStoreProcedure (string query, SqlConnection sql)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = sql;
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.CommandText = query;
            return com;
        }
    }
}