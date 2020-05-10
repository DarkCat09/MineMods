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
                toolTip1.SetToolTip(textBox2, "");
                toolTip1.Active = false;
            }
            else if (comboBox1.Text == "Удалите этот мод")
            {
                textBox2.Visible = true;
                toolTip1.Active = true;
                toolTip1.SetToolTip(textBox2, "Укажите причину");
            }
            else
            {
                textBox2.Visible = false;
                toolTip1.SetToolTip(textBox2, "");
                toolTip1.Active = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "Admin/DarkCat09/CodePicker13")
            {
                string msgBody = (
                    comboBox1.Text == "Добавьте этот мод" ||
                    comboBox1.Text == "Удалите этот мод") ?
                    "&body=Здравствуйте!\nПрошу: " + comboBox1.Text + " - " +
                    textBox2.Text + " " + textBox1.Text :
                    (comboBox1.Text == "Другое") ?
                    "&body=Здравствуйте!\nПрошу " + comboBox1.Text + ": " +
                    textBox2.Text + "\nМодификация: " + textBox1.Text :
                    "&body=Здравствуйте!\nПрошу исправить ошибку " + comboBox1.Text + " " +
                    textBox2.Text + " в модификации " + textBox1.Text;

                Process.Start("mailto:a.chechkenev@yandex.ru?subject=" +
                              comboBox1.Text + " " + textBox1.Text + " " + textBox2.Text +
                              msgBody);
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
