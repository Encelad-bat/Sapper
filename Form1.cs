using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    public partial class Form1 : Form
    {
        private List<Button> buttons = new List<Button>();
        private Random random;

        public Form1()
        {
            InitializeComponent();
        }

        private void Restart()
        {
            for (int i = 5; i > 0; i--)
            {
                this.Text = $"{i} before game restarts.";
                Thread.Sleep(1000);
            }
            Application.Restart();
            Environment.Exit(0);
        }
        private void ShowAll()
        {
            foreach (var item in buttons)
            {
                if (item.Name == "Clear")
                {
                    item.BackColor = Color.LightGreen;
                }
                else if (item.Name == "Bomb!")
                {
                    item.BackColor = Color.Red;
                }
                item.Text = item.Name;
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.Size = new Size(800, 600);
            this.Text = "Sapper";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.TransparencyKey = Color.Black;
            int x = 0;
            int y = 0;
            for (int i = 0; i < 20; i++)
            {
                Button button = new Button();
                Thread.Sleep(11);
                random = new Random();
                if(random.Next(0,5) == 0)
                {
                    button.Name = "Bomb!";
                }
                else
                {
                    button.Name = "Clear";
                }
                button.Click += new EventHandler(Button_Click);
                button.BackColor = Color.White;
                button.Size = new Size(this.Size.Width / 5, this.Size.Height / 4);
                button.Location = new Point(x, y);
                buttons.Add(button);
                this.Controls.Add(button);
                if (x + this.Size.Width / 5 >= this.Size.Width)
                {
                    x = 0;
                    y += this.Size.Height / 4;
                }
                else
                {
                    x += this.Size.Width / 5;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int white_button_quanity = 0;
            if ((sender as Button).BackColor == Color.White)
            {
                if ((sender as Button).Name == "Clear")
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else if ((sender as Button).Name == "Bomb!")
                {
                    (sender as Button).BackColor = Color.Red;
                    MessageBox.Show("BOOOOOOM!", "You Lose!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ShowAll();
                    this.Update();
                    this.Restart();
                }
                (sender as Button).Text = (sender as Button).Name;
            }
            foreach (var item in buttons)
            {
                if(item.Name != "Bomb!")
                {
                    if (item.BackColor == Color.White)
                    {
                        white_button_quanity++;
                    }
                }
            }
            if(white_button_quanity == 0)
            {
                MessageBox.Show("You Won!!!", "You Won!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Restart();
            }
        }
    }
}
