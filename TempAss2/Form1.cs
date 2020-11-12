using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempAss2
{
    public partial class Form1 : Form
    {
        Punter[] Punters;
        PictureBox[] Cars;
        RadioButton[] radioButtons;

        public Form1()
        {
            InitializeComponent();

            Cars = new PictureBox[2];
            Cars[0] = pictureBox1;
            Cars[1] = pictureBox2;

            radioButtons = new RadioButton[2];
            radioButtons[0] = radioButton1;
            radioButtons[1] = radioButton2;

            Punters = new Punter[2];
            Punters[0] = PunterFactory.CreatePunter("Milad", Cars[0], 50);
            Punters[1] = PunterFactory.CreatePunter("Dipti", Cars[1], 50);

            textBox1.Text = Punters[0].Money + "";
            textBox2.Text = Punters[1].Money + "";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            while (!GameFinished())
            {
                for (int i = 0; i < Cars.Length; i++)
                {
                    Cars[i].Location = new Point(Cars[i].Location.X + rand.Next(0, 20), Cars[i].Location.Y);
                }

                await Task.Delay(100);
            }
        }

        public bool GameFinished()
        {
            int winner = 0;

            for (int i = 0; i < Cars.Length; i++)
            {
                if (Cars[i].Location.X > 550)
                {
                    winner = i;


                    for (int j = 0; j < Punters.Length; j++)
                    {
                        if (Punters[j].Car == Cars[winner])
                        {
                            Punters[j].Money += Punters[j].Bet;
                        }
                        else
                        {
                            Punters[j].Money -= Punters[j].Bet;
                        }

                    }

                    textBox1.Text = Punters[0].Money + "";
                    textBox2.Text = Punters[1].Money + "";

                    for(int j = 0; j < Punters.Length; j++)
                    {
                        if(Punters[j].Money == 0)
                        {
                            radioButtons[j].Enabled = false;
                        }
                    }

                    foreach (var rb in radioButtons)
                        if (rb.Enabled == false)
                            MessageBox.Show("thank you for playing, game is over");

                    return true;
                }
            }


            return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Punters[0].Car = Cars[Convert.ToInt32(numericUpDown1.Value)];
                Punters[0].Bet = Convert.ToInt32(numericUpDown2.Value);
            }
            else if (radioButton2.Checked)
            {
                Punters[1].Car = Cars[Convert.ToInt32(numericUpDown1.Value)];
                Punters[1].Bet = Convert.ToInt32(numericUpDown2.Value);
            }

            for (int i = 0; i < Punters.Length; i++)
                Console.WriteLine(Punters[i].Name + " has bet on " + Punters[i].Car.Name + " for " + Punters[i].Bet + " dollars");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = Punters[0].Money;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = Punters[1].Money;
        }
    }
}
