using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L02MathQuiz
{
    public partial class Form1 : Form
    {
        //Randomizer to create random integers
        Random randomizer = new Random();

        // Integers for addition problem
        int addend1;
        int addend2;

        // Intereger to track time remaining
        int timeLeft;

        // Method to start quiz
        public void StartQuiz()
        {
            // Create random integers for addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Display integers in form
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // Set initial sum value to 0.
            sum.Value = 0;

            // Set initial clock value
            timeLeft = 30;
            timeLabel.Text = timeLeft + " sec";
            timer1.Start();
        }

        // Method to check the answer to a problem
        private bool CheckAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
        }

        // Main method for the form
        public Form1()
        {
            InitializeComponent();
        }

        // Method for clicking the Start button
        private void startButton_Click(object sender, EventArgs e)
        {
            StartQuiz();
            startButton.Enabled = false;
        }

        // Method for handling the timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Check the answers to see if they're all correct before counting down
            if (CheckAnswer())
            {
                // User answered the questions correctly; reward them
                timer1.Stop();
                MessageBox.Show("You answered every question correctly. Congratulations!", 
                    "Nailed it!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Display the remaining time by updating the label
                timeLeft--;
                timeLabel.Text = timeLeft + " sec";
            }
            else
            {
                // Stop the timer, display a message, show the correct answer, and enable the Start button
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You did not finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }
    }
}
