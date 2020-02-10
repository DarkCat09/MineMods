using System;
using System.IO;
using System.Windows.Forms;

namespace MineMods
{
    public partial class ModInfo : Form
    {
        string[] modDescription;
        
        public ModInfo(string mod)
        {
            InitializeComponent();

            this.Text = "Мод " + mod;

            try
            {
                modDescription = File.ReadAllLines(mod + "dscr.txt");
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
            catch (Exception)
            {
                _ = MessageBox.Show("Не удалось прочитать файл описания!\n\n" +
                                    "Попробуйте перезапустить программу.\n" +
                                    "Если это не поможет, передайте разработчику код ошибки:\n" +
                                    "MINEMODS_UNKNOWNEXCEPTION",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }

            if (modDescription != null)
            {
                textBox1.Lines = modDescription;
            }
        }
    }
}
