using System;
using System.IO;
using System.Windows.Forms;

namespace MineMods
{
    public partial class MineModsForm : Form
    {
        public MineModsForm()
        {
            InitializeComponent();
            russianРусскийToolStripMenuItem_Click(null, null);
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

        private void russianРусскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            модToolStripMenuItem.Text = Languages.Rus["Мод"];
            обновитьToolStripMenuItem.Text = Languages.Rus["Обновить"];
            скачатьToolStripMenuItem.Text = Languages.Rus["Скачать"];
            избранныеМодыToolStripMenuItem.Text = Languages.Rus["Избранные моды"];
            выходToolStripMenuItem.Text = Languages.Rus["Выход"];

            параметрыToolStripMenuItem.Text = Languages.Rus["Параметры"];
            шрифтToolStripMenuItem.Text = Languages.Rus["Шрифт"];

            мелкий5ptToolStripMenuItem.Text = Languages.Rus["Мелкий (5pt)"];
            обычный9ptToolStripMenuItem.Text = Languages.Rus["Обычный (9pt)"];
            крупный12ptToolStripMenuItem.Text = Languages.Rus["Крупный (12pt)"];
            огромный15ptToolStripMenuItem.Text = Languages.Rus["Огромный (15pt)"];

            языкToolStripMenuItem.Text = Languages.Rus["Язык"];
            файлСМодамиToolStripMenuItem.Text = Languages.Rus["Файл с модами"];
            сообщитьОбОшибкеToolStripMenuItem.Text = Languages.Rus["Сообщить об ошибке"];

            справкаToolStripMenuItem.Text = Languages.Rus["Справка"];
            оНасToolStripMenuItem.Text = Languages.Rus["О нас"];
            оПрограммеToolStripMenuItem.Text = Languages.Rus["О программе"];

            button1.Text = Languages.Rus["Клиент"];
            button2.Text = Languages.Rus["Сервер,мир"];
            button3.Text = Languages.Rus["Еда"];
            button4.Text = Languages.Rus["Мебель"];
            button5.Text = Languages.Rus["Транспорт"];
            button6.Text = Languages.Rus["Электроника и оружие"];
            button7.Text = Languages.Rus["Графика"];
            button8.Text = Languages.Rus["Блоки и другое"];
        }

        private void englishАнглийскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            модToolStripMenuItem.Text = Languages.Eng["Мод"];
            обновитьToolStripMenuItem.Text = Languages.Eng["Обновить"];
            скачатьToolStripMenuItem.Text = Languages.Eng["Скачать"];
            избранныеМодыToolStripMenuItem.Text = Languages.Eng["Избранные моды"];
            выходToolStripMenuItem.Text = Languages.Eng["Выход"];

            параметрыToolStripMenuItem.Text = Languages.Eng["Параметры"];
            шрифтToolStripMenuItem.Text = Languages.Eng["Шрифт"];

            мелкий5ptToolStripMenuItem.Text = Languages.Eng["Мелкий (5pt)"];
            обычный9ptToolStripMenuItem.Text = Languages.Eng["Обычный (9pt)"];
            крупный12ptToolStripMenuItem.Text = Languages.Eng["Крупный (12pt)"];
            огромный15ptToolStripMenuItem.Text = Languages.Eng["Огромный (15pt)"];

            языкToolStripMenuItem.Text = Languages.Eng["Язык"];
            файлСМодамиToolStripMenuItem.Text = Languages.Eng["Файл с модами"];
            сообщитьОбОшибкеToolStripMenuItem.Text = Languages.Eng["Сообщить об ошибке"];

            справкаToolStripMenuItem.Text = Languages.Eng["Справка"];
            оНасToolStripMenuItem.Text = Languages.Eng["О нас"];
            оПрограммеToolStripMenuItem.Text = Languages.Eng["О программе"];

            button1.Text = Languages.Eng["Клиент"];
            button2.Text = Languages.Eng["Сервер,мир"];
            button3.Text = Languages.Eng["Еда"];
            button4.Text = Languages.Eng["Мебель"];
            button5.Text = Languages.Eng["Транспорт"];
            button6.Text = Languages.Eng["Электроника и оружие"];
            button7.Text = Languages.Eng["Графика"];
            button8.Text = Languages.Eng["Блоки и другое"];
        }

        private void MineModsForm_Load(object sender, EventArgs e)
        {
            string boxres = MessageBox.Show("Обновить кэш?", "Вопрос",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString();
            Vars.updateCache = (boxres == "Yes");

            if (Vars.updateCache)
            {
                if (!File.Exists("mods.txt"))
                {
                    FileStream f = File.Create("mods.txt");
                    f.Close();
                }

                System.Net.WebClient c = new System.Net.WebClient();
                c.DownloadFile("https://theminemods.000webhostapp.com/mods/mods.txt", "mods.txt");
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MineModsForm_Load(null, null);
        }
    }
}
