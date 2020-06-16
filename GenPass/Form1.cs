using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GenPass
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            metroLabel2.Text = "15";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroTrackBar1.Minimum = 1;
            metroTrackBar1.Maximum = 30;
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                metroTextBox1.Text = "";
                string abc = "";
                if (metroCheckBox1.Checked)//использовать спецсимволы
                    abc += "!@#$%^&*()";
                if (metroCheckBox2.Checked)//использовать цифры
                    abc += "123456789";
                if (metroCheckBox3.Checked)//использовать заглавные
                    abc += "QWERTYUIOPASDFGHJKLZXCVBNM";
                if (metroCheckBox4.Checked)//использовать строчные
                    abc += "qwertyuiopasdfghjklzxcvbnm";
                Random rnd = new Random();
                for (int i = 0; i < metroTrackBar1.Value; i++)
                    metroTextBox1.Text += abc[rnd.Next(abc.Length)];
            }
            catch
            {
                MessageBox.Show("Похоже, вы не выбрали никакой чек-бокс", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            metroLabel2.Text = metroTrackBar1.Value.ToString();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(metroTextBox1.Text);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            Close();
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
