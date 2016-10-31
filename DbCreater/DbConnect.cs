﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace DBConnect
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect(string databaseName)
        {
            Initialize(databaseName);
        }

        //Initialize values
        private void Initialize(string databaseName)
        {
            server = "localhost";
            database = databaseName;

            uid = "root";
            password = "Trofeo360$";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

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
        public List<Tuple<float, float>> Select(string tableName, int fromYear, int toYear)
        {
            string query = "SELECT lat, lng FROM " + tableName + " WHERE year in (" + fromYear + "," + toYear + ")";

            //Create a list to store the result
            List<Tuple<float, float>> list = new List<Tuple<float, float>>();

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
                    list.Add(new Tuple<float, float>(Single.Parse(dataReader["lat"] + ""), Single.Parse(dataReader["lng"] + "")));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return list;
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
    }
}
