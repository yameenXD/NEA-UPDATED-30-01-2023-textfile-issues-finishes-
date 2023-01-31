using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Quiz_game_design_and_coded_solution
{
    public static class DatabaseConnect
    {
        public static DataSet dataConnect(string sql)
        {
            OleDbConnection con = Connect();

            OleDbDataAdapter userAdapter = new OleDbDataAdapter(sql, con);

            DataSet dataSet = new DataSet();

            userAdapter.Fill(dataSet, "DATA");

            return dataSet;

        }
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
                MessageBox.Show("Connected");
            }
            catch
            {
                MessageBox.Show("Connection failed");
            }
            try
            {
                string queryString = "SELECT UserID, Forname, Surname, Form, DOB FROM tblUser";
                OleDbCommand cmd = new OleDbCommand(queryString, con);

                DataSet users = new DataSet();
                userAdapter.Fill(users, "Users");
                MessageBox.Show("Database Connected");

                /*foreach (DataRow row in users.Tables["Users"].Rows)
                {
                    MessageBox.Show(row["UserID"]);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dataset Failed");
            }
            try
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO tblUser(UserID, Forname, Surname, Form, DOB) VALUES('123987', 'Yameen', 'Munir', 'U6LYM', '28/07/2005')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");

            }
            catch
            {
                MessageBox.Show("Insert Failed!");
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
                MessageBox.Show("Data Inserted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Failed!");
            }
            con.Close();
        }
    }
}
