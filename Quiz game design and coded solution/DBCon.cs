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
    public static class DBCon
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

        public static void dataConnect()
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
                /*userAdapter.Fill(users, "Users");*/
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
            con.Close();
        }
        public static void AmendAddInsertData(string SQL)
        {
            OleDbConnection conn = Connect();
            try
            {
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Failed!");
            }
            conn.Close();
        }
    }
}
