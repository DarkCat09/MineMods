using System;
using System.Windows.Forms;

namespace MineMods
{
    public partial class FtpAuthForm : Form
    {
        public FtpAuthForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm.login = textBox1.Text;
            AdminForm.password = textBox2.Text;
            Close();
        }

        private void показатьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void скрытьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
