using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quiz_game_design_and_coded_solution
{
    public partial class Form1 : Form
    {
        public static string User;
        public Form1()
        {
            InitializeComponent();
            User = System.Environment.UserName;
        }

        private void Form1_Load(object sender, EventArgs e) // this is the private method for the form1 load i.e the menu 
        {
            timer1.Start(); // this starts the timer for when the program runs
            lblUserName.Text = User;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e) // this private method is for the first button selection.
        {
            var myform = new General_knowledge_question();
            myform.Show();
        }

        private void button2_Click(object sender, EventArgs e) // this private method is for the second button selection.
        {
            var myform = new Entertainment();
            myform.Show();
        }

        private void button3_Click(object sender, EventArgs e) // this private method is for the third button selection.
        {
            var myform = new History();
            myform.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e) // this is a private method for the exit button for the main menu
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)// this private method for the button click for FoodandDrink for fourth button selection 
        {
            var myform = new Food_and_Drink();
            myform.Show();
        }

        
        
    }
}
