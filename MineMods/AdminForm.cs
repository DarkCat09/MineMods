using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MineMods
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            textBox1.Visible = false;
        }

        private void ввестиПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            byte[] correctHash;

            if (textBox1.Text == "")
            {
                _ = MessageBox.Show("Введите пароль!", "Ошибка авторизации",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tmpSource = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                correctHash = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes("#An5001@987"));

                _ = MessageBox.Show(ByteArrayToString(correctHash));

                bool bEqual = false;
                if (tmpHash.Length == tmpHash.Length)
                {
                    int i = 0;
                    while ((i < tmpHash.Length) && (tmpHash[i] == correctHash[i]))
                    {
                        i += 1;
                    }
                    if (i == tmpHash.Length)
                    {
                        bEqual = true;
                    }
                }

                if (bEqual)
                {
                    _ = MessageBox.Show("Всё правильно!");
                }
            }
        }

        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);

            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }

            return sOutput.ToString();
        }
    }
}
