using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineMods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CloseProgram(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenModsForm(String categ)
        {
            Mods m = new Mods(categ);
            m.Show();
        }

        private void ViewSelectedModsCategory(object sender, EventArgs e)
        {
            OpenModsForm(toolStripComboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenModsForm("Клиент");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenModsForm("Сервер,мир");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenModsForm("Еда");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenModsForm("Мебель");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenModsForm("Транспорт");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenModsForm("Электроника");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenModsForm("Графика");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenModsForm("Блоки и другое");
        }

        private void оНасToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show(Properties.Resources.HelpAboutUsNotR,
                                "Информация",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }
    }
}
