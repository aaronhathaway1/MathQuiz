using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Create a randomizer object to create random numbers
        Random randomizer = new Random();

        //Store the numbers for math problems
        int addend1, addend2;
        int minuend, subtrahend;
        int multiplicand, multiplier;
        int dividend, divisor;

        //Init the timer varaible
        int timeLeft;

        public void startTheQuiz()
        {
            // Declaring the numbers to be added together
            addend1 = randomizer.Next(0, 51);
            addend2 = randomizer.Next(0, 51);

            // Declaring the numbers to be subtracted
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            difference.Value = 0;

            // Declaring the numbers to be multiplied 
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            //Declaring the numbers to be divided
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;


            // Reassign the text values of the labels to the string version of the numbers
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            // Reassign the labels for subtraction
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Reassign the labels for mulitplication
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Reassign the labels for division
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeLabel.BackColor = Color.White;
            sum.BackColor = Color.White;
            difference.BackColor = Color.White;
            product.BackColor = Color.White;
            quotient.BackColor = Color.White;
            startTheQuiz();
            startButton.Enabled = false;
        }

        private bool checkTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) &&
                (minuend - subtrahend == difference.Value) &&
                (multiplicand * multiplier == product.Value) &&
                (dividend / divisor == quotient.Value))
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (checkTheAnswer())
            {
                timer1.Stop();
                sum.BackColor = Color.Green;
                difference.BackColor = Color.Green;
                product.BackColor = Color.Green;
                quotient.BackColor = Color.Green;
                MessageBox.Show("You got all the answers right. Congratulations!");
                startButton.Enabled = true;
            } else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            } else
            {
                timer1.Stop();
                timeLabel.Text = "Times Up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

            // Turn timer red
            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
