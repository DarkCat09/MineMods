using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MineMods
{
    public partial class FavouriteMods : Form
    {
        string modsDirectory = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + 
                               "\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft\\mods";
        public static List<Mods.Mod> favmods = new List<Mods.Mod>();

        public FavouriteMods()
        {
            InitializeComponent();

            textBox1.Text = modsDirectory;

            int i = 0;
            foreach (Mods.Mod m in favmods)
            {
                AddFavMod(m, i);
                i++;
            }
        }

        private void AddFavMod(Mods.Mod mod, int n)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", Vars.MAINFONT.SizeInPoints + 3);
            label1.Location = new System.Drawing.Point(10, 48*(n+1));
            label1.Size = new System.Drawing.Size(353, 18);
            label1.Text = mod.modName;
            label1.AccessibleName = n.ToString();
            Controls.Add(label1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string res = folderBrowserDialog1.ShowDialog().ToString();

            if (res != "Cancel")
            {
                modsDirectory = folderBrowserDialog1.SelectedPath;
                textBox1.Text = modsDirectory;
            }
        }

        public void DownloadModFile(Mods.Mod m)
        {
            string modFileName = m.modName + ".jar";
            WebClient c = new WebClient();

            c.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            if (m.dlLink != null)
            {
                if (!File.Exists(modFileName))
                {
                    FileStream f = File.Create(modFileName);
                    f.Close();
                }

                try
                {
                    c.DownloadFile(m.dlLink, modFileName);
                }
                catch (WebException ex)
                {
                    _ = MessageBox.Show("Ошибка " + ex.Message);
                    Close();
                }
            }
            else
            {
                _ = MessageBox.Show("Для мода " + m.modName + " не указан URL.\n" +
                                    "Он не может быть загружен.",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Mods.Mod m in favmods)
            {
                DownloadModFile(m);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Mods.Mod m in favmods)
            {
                string modFileName = m.modName + ".jar";
                FileInfo finf = null;

                try
                {
                    finf = new FileInfo(modFileName);
                }
                catch (FileNotFoundException)
                {
                    //do nothing
                }

                if (!File.Exists(modFileName))
                {
                    DownloadModFile(m);
                }
                else if (finf != null)
                {
                    if (finf.Length <= 0)
                    {
                        DownloadModFile(m);
                    }
                }

                if (File.Exists(modsDirectory + "\\" + modFileName))
                    File.Delete(modsDirectory + "\\" + modFileName);

                File.Copy(modFileName, modsDirectory + "\\" + modFileName);

                progressBar1.Value += 100 / favmods.Count;
            }

            _ = MessageBox.Show("Завершено!", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            progressBar1.Value = 0;
        }
    }
}
