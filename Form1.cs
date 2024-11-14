using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        private char[] correctAnswers = new char[]
        {
            'A', 'D', 'A', 'A', 'C', 'A', 'B', 'A', 'C', 'D',
            'B', 'C', 'D', 'A', 'D', 'C', 'C', 'B', 'D', 'A'
        };

        private List<char> studentAnswers;
        private int questionIndex;

        public Form1()
        {
            InitializeComponent();
            studentAnswers = new List<char>();
            questionIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Loading correct answers. Starting test.", "Information");

            if (correctAnswers.Length == 0)
            {
                MessageBox.Show("Correct answers are not provided in the program.", "Error");
                this.Close();
            }
            else
            {
                MessageBox.Show("Correct answers loaded. Loading first question.", "Information");
                LoadNextQuestion();
            }
        }

        private void LoadNextQuestion()
        {
            if (questionIndex < correctAnswers.Length)
            {
                label1.Text = $"Question {questionIndex + 1}";
                label2.Text = $"Question text {questionIndex + 1}";
                label9.Text = "A";
                label10.Text = "B";
                label11.Text = "C";
                label12.Text = "D";
            }
            else
            {
                GradeExam();
            }
        }

        private void GradeExam()
        {
            int correctCount = 0;
            List<int> incorrectQuestions = new List<int>();

            for (int i = 0; i < correctAnswers.Length; i++)
            {
                if (i < studentAnswers.Count && studentAnswers[i] == correctAnswers[i])
                {
                    correctCount++;
                }
                else
                {
                    incorrectQuestions.Add(i + 1);
                }
            }

            int incorrectCount = correctAnswers.Length - correctCount;
            string resultMessage = correctCount >= 15 ? "Passed" : "Failed";

            MessageBox.Show($"Result: {resultMessage}\n" +
                            $"Correct Answers: {correctCount}\n" +
                            $"Incorrect Answers: {incorrectCount}\n" +
                            $"Incorrect Questions: {string.Join(", ", incorrectQuestions)}");
        }

        private void RecordAnswerAndProceed(char answer)
        {
            studentAnswers.Add(answer);
            questionIndex++;

            if (questionIndex < correctAnswers.Length)
            {
                LoadNextQuestion();
            }
            else
            {
                GradeExam();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordAnswerAndProceed('A');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordAnswerAndProceed('B');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordAnswerAndProceed('C');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecordAnswerAndProceed('D');
        }
    }
}
