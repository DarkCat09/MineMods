using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MineMods
{
    public partial class BugReport : Form
    {
        public BugReport()
        {
            InitializeComponent();
        }

        private void CheckSelectedIndex(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Другое")
            {
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:a.chechkenev@yandex.ru?subject=" +
                          textBox1.Text + " " + comboBox1.Text + " " + textBox2.Text +
                          "&body=Прошу исправить ошибку " + comboBox1.Text + " " + textBox2.Text + " в модификации " + textBox1.Text);
        }
    }
}
