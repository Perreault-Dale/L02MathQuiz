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

        // Integers for problems
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;

        // Intereger to track time remaining
        int timeLeft;

        // Display today's date
        DateTime today = DateTime.Today;

        // Method to start quiz
        public void StartQuiz()
        {
            // Create random integers for addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Create random integers for subtraction problem
            minuend = randomizer.Next(1,101);
            subtrahend = randomizer.Next(1,minuend);

            // Create random integers for multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            // Create random integers for division problem
            divisor = randomizer.Next(2, 11);
            int tempAnswer = randomizer.Next(2, 11);
            dividend = tempAnswer * divisor;
            
            // Display integers in form
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();

            // Set initial values of answers to 0.
            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;

            // Set initial clock value
            timeLeft = 30;
            timeLabel.Text = timeLeft + " sec";
            timer1.Start();
        }

        // Method to check the answer to a problem
        private bool CheckAnswer()
        {
            if ((addend1 + addend2 == sum.Value) &&
                (minuend - subtrahend == difference.Value) && 
                (multiplicand * multiplier == product.Value) &&
                (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        // Main method for the form
        public Form1()
        {
            InitializeComponent();
            dateLabel.Text = today.ToString("dd MMMM yyyy");
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
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
            if (timeLeft < 6)
                timeLabel.BackColor = Color.Red;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the NumericUpDown box
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int answerLength = answerBox.Value.ToString().Length;
                answerBox.Select(0, answerLength);
            }
        }

        private void test_Sum(object sender, EventArgs e)
        {
            // Select the NumericUpDown box
            NumericUpDown answerBox = sender as NumericUpDown;

            if(addend1 + addend2 == answerBox.Value)
                answerBox.BackColor = Color.Green;
        }

        private void test_Difference(object sender, EventArgs e)
        {
            // Select the NumericUpDown box
            NumericUpDown answerBox = sender as NumericUpDown;

            if (minuend - subtrahend == answerBox.Value)
                answerBox.BackColor = Color.Green;
        }

        private void test_Product(object sender, EventArgs e)
        {
            // Select the NumericUpDown box
            NumericUpDown answerBox = sender as NumericUpDown;

            if (multiplicand * multiplier == answerBox.Value)
                answerBox.BackColor = Color.Green;
        }

        private void test_Quotient(object sender, EventArgs e)
        {
            // Select the NumericUpDown box
            NumericUpDown answerBox = sender as NumericUpDown;

            if (dividend / divisor == answerBox.Value)
                answerBox.BackColor = Color.Green;
        }
    }
}
