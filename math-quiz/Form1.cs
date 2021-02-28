using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math_quiz
{
    public partial class Form1 : Form
    {
        // Randomizer for generating numbers
        Random randomizer = new Random();

        // For addition
        int addend1;
        int addend2;

        // For substraction
        int minuend;
        int substrahend;

        // For multiplication
        int multiplicand;
        int multiplier;

        // For division
        int dividend;
        int divisor;

        // Remaining time
        int timeLeft;

        public void StartQuiz()
        {
            // Addition
            addend1 = randomizer.Next(51); // Generating numbers for addition
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString(); // Converting numbers to strings for display
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0; // Reseting sum value

            // Substraction
            minuend = randomizer.Next(1, 101);
            substrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = substrahend.ToString();
            difference.Value = 0;

            // Multiplication
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Division
            divisor = randomizer.Next(2, 11);
            int tempQuotient = randomizer.Next(2, 11);
            dividend = divisor * tempQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            
            // Starting the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.BackColor = Color.Empty;

            if (CheckAnswer())
            {
                // If CheckAnswer return true, stop the timer
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Display time
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";

                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.LightPink;
                }
            }
            else
            {
                // If user run out of time
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - substrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private bool CheckAnswer()
        {
            if (addend1 + addend2 == sum.Value && 
                minuend - substrahend == difference.Value &&
                multiplicand * multiplier == product.Value &&
                dividend / divisor == quotient.Value)
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartQuiz();
            startButton.Enabled = false;
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
