using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        ScreenField screenField;

        public Form1()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            Cursor.Hide();
            timer1.Enabled = true;
            timer1.Interval = 15;
            timer1.Start();
            BackColor = Color.Black;
            ForeColor = Color.White;
            Width = 1920;
            Height = 1080;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            screenField = new ScreenField(250, Width, Height);
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            screenField.DrawField(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            screenField.ShiftField();
            Refresh();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)27:
                    Application.Exit();
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}