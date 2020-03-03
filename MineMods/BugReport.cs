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

            button3.Enabled = false;
            button3.Visible = false;
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
            if (textBox3.Text != "Admin/DarkCat09/CodePicker13")
            {
                Process.Start("mailto:a.chechkenev@yandex.ru?subject=" +
                              textBox1.Text + " " + comboBox1.Text + " " + textBox2.Text +
                              "&body=Здравствуйте!\nПрошу исправить ошибку " + comboBox1.Text + " " + textBox2.Text + " в модификации " + textBox1.Text);
            }
            else
            {
                _ = MessageBox.Show("От имени администратора нельзя отправлять сообщения об ошибках (багрепорты).",
                                    "Информация", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                button3.Enabled = true;
                button3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminForm af = new AdminForm();
            af.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
