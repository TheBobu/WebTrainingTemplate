using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebTrainingTemplate.DataProviders.src.Services
{
    public class DatabaseProvider
    {
        /// <summary>
        /// A class with basic functions for executing queries in a SQL database
        /// Replace the connection string with your database connection string
        /// </summary>
        private static readonly string connectionString = "";

        public static DataSet Select(string query, List<SqlParameter> parameters)
        {
            //Basic template SELECT function...

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, sqlConnection);
            DataSet dataSet = new DataSet();

            sqlConnection.Open();

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }

        public static int ExecuteQuery(string query, List<SqlParameter> parameters)
        {
            // Basic template function for executing INSERT, UPDATE or DELETE queries...

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            int result = command.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
    }
}
