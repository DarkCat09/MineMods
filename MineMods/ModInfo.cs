using System;
using System.IO;
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

            #region description file
            try
            {
                modDescription = File.ReadAllLines(modName.Replace(" ", "_").Replace("&", "and") + "-dscr.txt");
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

                try
                {
                    pictureBox1.Load(modName.Replace(" ", "_").Replace("&", "and") + "-icon" + ".png");
                }
                catch (FileNotFoundException)
                {
                    try
                    {
                        pictureBox1.Load(modName.Replace(" ", "_").Replace("&", "and") + "-icon" + ".jpg");
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
            }
        }

        public ModInfo(string mod)
        {
            InitializeComponent();

            mod = mod.Replace("&&", "&");

            this.Text = "Мод " + mod;

            #region description file
            try
            {
                modDescription = File.ReadAllLines(mod.Replace(" ", "_").Replace("&", "and") + "-dscr.txt");
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

                try
                {
                    pictureBox1.Load(mod.Replace(" ", "_").Replace("&", "and") + "-icon" + ".png");
                }
                catch (FileNotFoundException)
                {
                    try
                    {
                        pictureBox1.Load(mod.Replace(" ", "_").Replace("&", "and") + "-icon" + ".jpg");
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
        }

        private void DownloadMod(object sender, EventArgs e)
        {
            //code
        }
    }
}
