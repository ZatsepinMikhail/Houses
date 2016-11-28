﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Houses_NET_Framework_NotEmpty.Models
{
    public class DBconnector
    {
        private MySqlConnection connection;
        private ConfigStorer configs;

        public DBconnector()
        {
            configs = new ConfigStorer();
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + configs.server + ";" + "DATABASE=" +
                configs.database + ";" + "UID=" + configs.uid + ";" + "PASSWORD=" + configs.password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Select statement
        public Tuple<List<int>, List<double>, List<double>> Select(string tableName, int fromYear, int toYear)
        {
            string query = "SELECT year, lat, lng FROM " + tableName + " WHERE year >= " + fromYear + " AND year <= " + toYear + ";";

            //Create a list to store the result
            List<int> years = new List<int>();
            List<double> lats = new List<double>();
            List<double> lngs = new List<double>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    years.Add(Int32.Parse(dataReader["year"] + ""));
                    lats.Add(Double.Parse(dataReader["lat"] + ""));
                    lngs.Add(Double.Parse(dataReader["lng"] + ""));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return new Tuple<List<int>, List<double>, List<double>>(years, lats, lngs);
        }

        //Count statement
        public int Count(string tableName)
        {
            string query = "SELECT Count(*) FROM " + tableName;
            int count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();
            }
            return count;
        }

        public Tuple<double, double, int> GetCityInfo(string cityName)
        {
            string query = "SELECT lat, lng, first_year FROM cities_info WHERE city = \"" + cityName + "\";";
            Tuple<double, double, int> result = new Tuple<double, double, int>(0.0, 0.0, 0);

            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    result = new Tuple<double, double, int>(Single.Parse(dataReader["lat"] + ""), Single.Parse(dataReader["lng"] + ""), Int32.Parse(dataReader["first_year"] + ""));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return result;
        }
    }
}
