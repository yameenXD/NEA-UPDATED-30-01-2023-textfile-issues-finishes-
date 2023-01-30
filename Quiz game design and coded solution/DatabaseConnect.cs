/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Quiz_game_design_and_coded_solution
{
    public static class DatabaseConnect
    {
        *//*public static DataSet dataConnect(string sql)
        {
            OleDbConnection con = Connect();

            OleDbDataAdapter customerAdapter = new OleDbDataAdapter(sql, con);

            DataSet dataSet = new DataSet();

            customerAdapter.Fill(dataSet, "DATA");

            return dataSet;

        }*//*
        public static OleDbConnection Connect()
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;" + "Data Source=dbQuizGame.accdb");
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static void dataConnect()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;" + "Data Source=dbQuizGame.accdb");
            try
            {
                con.Open();
                Console.WriteLine("Connected");
            }
            catch
            {
                Console.WriteLine("Connection failed");
            }
            try
            {
                string queryString = "SELECT UserID, Forname, Surname, Form, DOB FROM tblUser";
                OleDbCommand cmd = new OleDbCommand(queryString, con);

                DataSet users = new DataSet();
                usersAdapter.Fill(users, "Users");
                Console.WriteLine("Database Connected");

                foreach (DataRow row in users.Tables["Users"].Rows)
                {
                    Console.WriteLine(row["UserID"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Dataset Failed");
            }
            try
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO tblUser(UserID, Forname, Surname, Form, DOB) VALUES('12398713789', 'Yameen', 'Munir', 'U6LYM', '28/07/2005')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted");

            }
            catch 
            {
                Console.WriteLine("Insert Failed!");
            }
            con.Close();
        }
        static void ManipulateData(string database, string SQL)
        {
            OleDbConnection con = Connect();
            try
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = SQL;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Failed!");
            }
            con.Close();
        }
    }
}
*/