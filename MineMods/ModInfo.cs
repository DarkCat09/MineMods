using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace MineMods
{
    public partial class ModInfo : Form
    {
        string[] modDescription;
        Mods.Mod receivedMod;

        public ModInfo(Mods.Mod mod)
        {
            InitializeComponent();

            receivedMod = mod;
            string modName = mod.modName.Replace("&&", "&");

            this.Text = "Мод " + modName;
            textBox1.Font = Vars.MAINFONT;

            #region description file
            try
            {
                string str = "mods\\" + modName.Replace(" ", "_").Replace("&", "and").Replace("_(", "-").Replace(")", "") +
                            "-dscr.txt";
                modDescription = File.ReadAllLines(str);
            }
            catch (PathTooLongException)
            {
                _ = MessageBox.Show("Слишком длинный путь до файла описания!\n" +
                                    "Запустите программу в каталоге выше.",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                Close();
            }
            catch (FileNotFoundException)
            {
                _ = MessageBox.Show("Не найден файл описания!\n\n" +
                                    "Попробуйте перезапустить программу.\n" +
                                    "Если это не поможет, передайте разработчику код ошибки:\n" +
                                    "MINEMODS_FILENOTFOUNDEXCEPTION",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException)
            {
                _ = MessageBox.Show("Ошибка безопасности!\n\n" +
                                    "Попробуйте перезапустить программу.\n" +
                                    "Если это не поможет, передайте разработчику код ошибки:\n" +
                                    "MINEMODS_SECURITYEXCEPTION",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                _ = MessageBox.Show("Не удалось прочитать файл описания!\n\n" +
                                    "Попробуйте перезапустить программу.\n" +
                                    "Если это не поможет, передайте разработчику код ошибки:\n" +
                                    "MINEMODS_UNKNOWNIOEXCEPTION",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Критическая ошибка!\n\n" +
                                    "Попробуйте перезапустить программу.\n" +
                                    "Если это не поможет, передайте разработчику код ошибки:\n" +
                                    "MINEMODS_CRITUNKNOWNEXCEPTION",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
            #endregion

            #region picture
            if (modDescription != null)
            {
                textBox1.Lines = modDescription;
                string str = "mods\\" + modName.Replace(" ", "_").Replace("&", "and").Replace("_(", "-").Replace(")", "") + "-icon";

                try
                {
                    pictureBox1.Load(str + ".png");
                }
                catch (FileNotFoundException)
                {
                    try
                    {
                        pictureBox1.Load(str + ".jpg");
                    }
                    catch (FileNotFoundException)
                    {
                        _ = MessageBox.Show("Файл с картинкой не найден!\n\n" +
                                            "Возможно, картинки для этого мода пока что нет.\n\n" +
                                            "Если Вам нужна картинка, напишите разработчику письмо\n" +
                                            "с темой кода проблемы:\n" +
                                            "MINEMODS_PICTURENOTFOUND <название мода>",
                                            "Ошибка", MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
            #endregion

            if (mod.dlLink != null)
            {
                скачатьToolStripMenuItem.Click += new EventHandler(DownloadMod);
                скачатьВОбычномФорматеjarToolStripMenuItem.Click += new EventHandler(DownloadMod);
                скачатьВZipархивеzipToolStripMenuItem.Click += new EventHandler(DownloadModInZip);
            }
        }

        public ModInfo(string mod)
        {
            InitializeComponent();

            ModInfo mf = new ModInfo(new Mods.Mod()
            {
                modName = mod,
                categories = new string[1] { "" },
                dlLink = null
            });
        }

        private void DownloadMod(object sender, EventArgs e)
        {
            WebClient c = new WebClient();
            string file = receivedMod.modName + ".jar";

            c.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            if (!File.Exists(file))
            {
                FileStream f = File.Create(file);
                f.Close();
            }

            try
            {
                c.DownloadFile(receivedMod.dlLink, file);
            }
            catch (WebException ex)
            {
                _ = MessageBox.Show("Ошибка " + ex.Message);
                Close();
            }
        }

        private void DownloadModInZip(object sender, EventArgs e)
        {
            WebClient c = new WebClient();
            string file = receivedMod.modName + ".zip";

            c.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            if (!File.Exists(file))
            {
                FileStream f = File.Create(file);
                f.Close();
            }

            try
            {
                c.DownloadFile(receivedMod.dlLink, file);
            }
            catch (WebException ex)
            {
                _ = MessageBox.Show("Ошибка " + ex);
                Close();
            }
        }

        private void открытьВБраузереcurseforgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(receivedMod.dlLink.ToString());
        }

        private void описаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            string res = saveFileDialog1.ShowDialog().ToString();

            if (res != "Cancel")
            {
                File.WriteAllLines(saveFileDialog1.FileName, textBox1.Lines);
            }
        }

        private void картинкуИОписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string modname = receivedMod.modName.Replace("&&", "&").Replace(" ", "_").Replace("&", "and").Replace("_(", "-").Replace(")", "");
            string pictExt = ".png";

            Directory.CreateDirectory(modname);
            string res = folderBrowserDialog1.ShowDialog().ToString();

            if (!File.Exists("mods\\" + modname + "-icon" + pictExt))
            {
                pictExt = ".jpg";
                if (!File.Exists("mods\\" + modname + "-icon" + pictExt))
                {
                    pictExt = "err";
                    _ = MessageBox.Show("Файл с картинкой не найден!\n\n" +
                                        "Возможно, иконки/скриншота для этого мода пока что нет.\n\n" +
                                        "Если Вам нужна картинка, напишите разработчику код ошибки:\n" +
                                        "MINEMODS_PICTURENOTFOUND <название мода>",
                                        "Ошибка", MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
            }

            if (res != "Cancel")
            {
                File.WriteAllLines(folderBrowserDialog1.SelectedPath + "\\" + modname + "-dscr.txt", textBox1.Lines);
                if (pictExt != "err")
                {
                    File.Copy("mods\\" + modname + "-icon" + pictExt, folderBrowserDialog1.SelectedPath + "\\" + modname + "-icon" + pictExt);
                }
            }
        }

        private void добавитьВИзбранноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavouriteMods.favmods.Add(receivedMod);
        }
    }
}
