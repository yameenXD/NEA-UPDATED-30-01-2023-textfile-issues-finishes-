using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_game_design_and_coded_solution
{
    public partial class General_knowledge_question : Form
    {
        // quiz game variables
        int correctAnswer;
        int questionNumber = 1;
        int optionnumber = 0;
        int score = 0;
        int percentage;
        int totalQuestions;
        int[] goArray;
        static string FilePath = @"C:\Users\yamee\OneDrive\Documents\NEA-UPDATED-30-01-2023-textfile-issues-finishes--main\gk.txt";
        List<string> questions;

        public General_knowledge_question()
        {
            question_reading(); // calls the question reading method
            InitializeComponent();
            askQuestion(1, 10);
            totalQuestions = 10; // this is the total amount of questions
        }

        public void question_reading() // public method for question_reading
        {
            int count = 0; // this declares the count variable as an integer
            string data; // this declares the data as a string 
            FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            questions = new List<string>();// instantiates the list

            while (count < 60) // while count is less than 60
            {
                data = streamReader.ReadLine();
                questions.Add(data);
                count++;
            }

        }

        private void checkAnswereEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;


            int buttonTag = Convert.ToInt32(senderObject.Tag);
            if (buttonTag == correctAnswer)
            {
                score = score + 1;
                label2.Text = "Score: " + Convert.ToString(score);

            }
            optionnumber = 5;
            questionNumber += 6;
            askQuestion(questionNumber, optionnumber);

            /*if (questionNumber == totalQuestions)
            {
                // Working out the percentage 

                percentage = (int)Math.Round((double)(score * 100) / totalQuestions);

                // this will display when the quiz has ended. This will be done by outputing a message 
                MessageBox.Show("Quiz Ended!" + Environment.NewLine + "You have answered " + score + "questions correctly" + Environment.NewLine +
                    "Your total percentage is" + percentage + "%" + Environment.NewLine +
                    "Click OK to play again");
                score = 0; // this will reset the code to 0
                questionNumber = 0; // this will reset the questionnumber to 0
                askQuestion(questionNumber, 0);
            }*/
        }

        public void askQuestion(int qnum, int optionnumber)
        {

            pictureBox1.Image = Properties.Resources.images;
            






            try
            {
                label1.Text = questions[qnum - 1]; // the question asked to the user
                button1.Text = questions[qnum]; // option 1
                button2.Text = questions[qnum + 1]; // option 2
                button3.Text = questions[qnum + 2];// option 3
                button4.Text = questions[qnum + 3]; // option 4

                correctAnswer = Convert.ToInt32(questions[qnum + 4]); // the correct answer would be the second option in this case  
            }
            catch
            {
                percentage = (int)Math.Round((double)(score * 100) / totalQuestions);
                MessageBox.Show("Quiz Ended!" + Environment.NewLine + "You have answered " + score + "questions correctly" + Environment.NewLine +
                    "Your total percentage is" + percentage + "%" + Environment.NewLine +
                    "Click OK to play again");
                if (questionNumber == 10)
                {
                    score = 0;
                    questionNumber = 0; // this will reset the questionnumber to 0
                    askQuestion(questionNumber, 0);

                }
                else if (questionNumber <= 10)
                {
                    questionNumber++;
                    
                }
            }
           
            

        }

        public void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {
            string name = namebox.Text;
            namebox.Text = name;
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (buttonTag == correctAnswer) // selection. If the selected answer is equal to the correct answer the score will be incremented by one.
            {
                score = score + 1; // score will be incremented by one

                score = 0;
                int goscore = goArray[0];

                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();
            }
        }

        private void General_knowledge_question_Load(object sender, EventArgs e)
        {
            lblUserName.Text = System.Environment.UserName;
        }
    }
}

