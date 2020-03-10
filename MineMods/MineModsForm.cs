using System;
using System.Windows.Forms;

namespace MineMods
{
    public partial class MineModsForm : Form
    {
        public MineModsForm()
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

        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Чтобы скачать мод для последней версии Minecraft,\n" + 
                                "откройте его детальную страницу, в меню выберите \"Скачать мод\"\n" + 
                                "и нажмите \"Скачать\" или \"Открыть в браузере\".",
                                "Информация", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram about = new AboutProgram();
            about.Show();
        }

        private void сообщитьОбОшибкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugReport reportform = new BugReport();
            reportform.Show();
        }

        private void мелкий5ptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vars.MAINFONT = new System.Drawing.Font("Verdana", 5);
        }

        private void обычный9ptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vars.MAINFONT = new System.Drawing.Font("Verdana", 9);
        }

        private void крупный12ptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vars.MAINFONT = new System.Drawing.Font("Verdana", 12);
        }

        private void огромный15ptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vars.MAINFONT = new System.Drawing.Font("Verdana", 15);
        }

        private void файлСМодамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string res = openFileDialog1.ShowDialog().ToString();

            if (res != "Cancel")
            {
                Vars.modsFile = openFileDialog1.FileName;
            }
        }

        private void избранныеМодыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavouriteMods favform = new FavouriteMods();
            favform.Show();
        }
    }
}
