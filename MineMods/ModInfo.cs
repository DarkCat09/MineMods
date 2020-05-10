using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MineMods
{
    public partial class ModInfo : Form
    {
        string[] modDescription;
        Mod receivedMod;

        public ModInfo(Mod mod)
        {
            InitializeComponent();

            WebClient c = new WebClient();
            receivedMod = mod;
            string modName = mod.modName.Replace("&&", "&");

            this.Text = "Мод " + modName;
            textBox1.Font = Vars.MAINFONT;

            #region description file
            try
            {
                string filename = Vars.ParseModFileName(modName) + "-dscr.txt";
                string str = "mods\\" + filename;
                bool isModsfileExists = true;

                if (!File.Exists(str))
                {
                    isModsfileExists = false;
                    FileStream f = File.Create(str);
                    f.Close();
                }

                if (isModsfileExists || Vars.updateCache)
                {
                    c.DownloadFile("https://theminemods.000webhostapp.com/mods/" + filename, str);
                }

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
            catch (DirectoryNotFoundException)
            {
                _ = Directory.CreateDirectory("mods");
                _ = MessageBox.Show("Не найден каталог с файлами описания!\n\n" +
                                    "Проблема должна быть уже решена автоматически.\n" +
                                    "Перезапустите программу.\n" +
                                    "Если это не поможет, передайте разработчику код ошибки:\n" +
                                    "MINEMODS_DIRNOTFOUNDEXCEPTION",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                Close();
            }
            catch (WebException)
            {
                _ = MessageBox.Show("Ошибка получения файла описания с удалённого сервера!\n\n" +
                                    "Проверьте своё интернет-соединение и перезапустите программу.\n" +
                                    "Также возможно, что файла описания для этого мода ещё нет.\n\n" +
                                    "Если Вам нужно описание, напишите разработчику письмо\n" +
                                    "с темой кода проблемы:\n" +
                                    "MINEMODS_FILEONSERVERNOTFOUND <название мода>",
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
                string filename = Vars.ParseModFileName(modName) + "-icon";
                string str = "mods\\" + filename;

                int i = 0;
                List<string> pictexts = new List<string>() {
                    ".png", ".jpg", ".gif", ".bmp"
                };
                foreach (String ext in pictexts)
                {
                    if (File.Exists(str + ext) && !(Vars.updateCache))
                    {
                        pictureBox1.Load(str + ext);
                        break;
                    }
                    else
                    {
                        try
                        {
                            FileStream f = File.Create(str + ext);
                            f.Close();

                            c.DownloadFile("https://theminemods.000webhostapp.com/mods/" + filename + ext, str + ext);
                            pictureBox1.Load(str + ext);

                            break;
                        }
                        catch (WebException)
                        {
                            if (i == (pictexts.Count - 1))
                            {
                                _ = MessageBox.Show("Ошибка получения картинки с удалённого сервера!\n\n" +
                                                    "Проверьте своё интернет-соединение.\n" +
                                                    "Также возможно, картинки для этого мода пока что нет.\n\n" +
                                                    "Если Вам нужна картинка, напишите разработчику письмо\n" +
                                                    "с темой кода проблемы:\n" +
                                                    "MINEMODS_PICTURENOTFOUND <название мода>",
                                                    "Ошибка", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                            }
                        }
                    }

                    i++;
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

            ModInfo mf = new ModInfo(Mod.Create(mod));
            mf.Show();
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

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
