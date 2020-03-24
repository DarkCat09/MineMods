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
        public static List<Mod> favmods = new List<Mod>();

        public FavouriteMods()
        {
            InitializeComponent();

            textBox1.Text = modsDirectory;

            int i = 0;
            foreach (Mod m in favmods)
            {
                AddFavMod(m, i);
                i++;
            }
        }

        private void OpenFavModDescription(object sender, EventArgs e)
        {
            int n = 0;
            _ = Int32.TryParse(((Label)sender).AccessibleName, out n);

            if (n <= favmods.Count)
            {
                ModInfo mf = new ModInfo(favmods[n]);
                mf.Show();
            }
        }

        private void AddFavMod(Mod mod, int n)
        {
            Label modlabel = new Label();
            modlabel.AutoSize = true;
            modlabel.Font = new System.Drawing.Font("Verdana", Vars.MAINFONT.SizeInPoints + 3);
            modlabel.Location = new System.Drawing.Point(10, 48*(n+1));
            modlabel.Size = new System.Drawing.Size(353, 18);
            modlabel.Text = mod.modName;
            modlabel.AccessibleName = n.ToString();
            modlabel.Click += new EventHandler(OpenFavModDescription);
            modlabel.Cursor = Cursors.Hand;
            Controls.Add(modlabel);
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

        public void DownloadModFile(Mod m)
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
            foreach (Mod m in favmods)
            {
                DownloadModFile(m);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Mod m in favmods)
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

        private void button4_Click(object sender, EventArgs e)
        {
            favmods.Clear();

            _ = MessageBox.Show("Список избранных модов очищен.", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
