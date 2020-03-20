using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MineMods
{
    public partial class Mods : Form
    {
        /// <summary>
        /// Last Mod
        /// </summary>
        int modnumber = 1;

        List<Mod> mods = new List<Mod>();

        public Mods(string category)
        {
            InitializeComponent();

            this.Text = "Моды - " + category;

            #region checking category fromfile
            StreamReader s = new StreamReader(Vars.modsFile);
            string line = "";

            line = s.ReadLine();
            int n = 0;
            int y = 0;
            while (line != null)
            {
                Mod readMod = new Mod();
                if (line.Split(new char[] { ';' }).Length >= 1)
                {
                    readMod.modName = line.Split(new char[] { ';' })[0];
                    readMod.categories = (line.Split(new char[] { ';' })[1]).Split(new char[] { ',' });
                }

                if (line.Split(new char[] { ';' }).Length >= 3)
                {
                    readMod.dlLink = new Uri(line.Split(new char[] { ';' })[2]);
                }
                else
                {
                    readMod.dlLink = null;
                }

                mods.Add(readMod);

                if (category != "Все моды")
                {
                    if (category == "Сервер,мир")
                    {
                        for (int i = 0; i < ((line.Split(new char[] { ';' })[1]).Split(new char[] { ',' })).Length; i++)
                        {
                            if (mods[n].categories[i] == "Сервер" || mods[n].categories[i] == "Мир")
                            {
                                mods[n] = AddMod(mods[n], n, y);
                                y++;
                            }
                        }
                    }
                    else if (category == "Электроника" || category == "Оружие" || category == "Электроника и оружие")
                    {
                        for (int i = 0; i < ((line.Split(new char[] { ';' })[1]).Split(new char[] { ',' })).Length; i++)
                        {
                            if (mods[n].categories[i] == "Электроника" || mods[n].categories[i] == "Оружие")
                            {
                                mods[n] = AddMod(mods[n], n, y);
                                y++;
                            }
                        }
                    }
                    else if (category == "Блоки" || category == "Другое" || category == "Блоки и другое")
                    {
                        if (category == "Блоки и другое")
                        {
                            for (int i = 0; i < ((line.Split(new char[] { ';' })[1]).Split(new char[] { ',' })).Length; i++)
                            {
                                if (mods[n].categories[i] == "Блоки" ||
                                    mods[n].categories[i] == "Другое" ||
                                    mods[n].categories[i] == "Инструменты")
                                {
                                    mods[n] = AddMod(mods[n], n, y);
                                    y++;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < ((line.Split(new char[] { ';' })[1]).Split(new char[] { ',' })).Length; i++)
                            {
                                if (mods[n].categories[i] == "Блоки" || mods[n].categories[i] == "Другое")
                                {
                                    mods[n] = AddMod(mods[n], n, y);
                                    y++;
                                }
                            }
                        }
                    }
                    else if (category == "Инструменты")
                    {
                        for (int i = 0; i < ((line.Split(new char[] { ';' })[1]).Split(new char[] { ',' })).Length; i++)
                        {
                            if (mods[n].categories[i] == "Инструменты")
                            {
                                mods[n] = AddMod(mods[n], n, y);
                                y++;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ((line.Split(new char[] { ';' })[1]).Split(new char[] { ',' })).Length; i++)
                        {
                            if (mods[n].categories[i] == category)
                            {
                                mods[n] = AddMod(mods[n], n, y);
                                y++;
                            }
                        }
                    }
                }
                else
                {
                    mods[n] = AddMod(mods[n], n, y);
                    y++;
                }

                if (n <= mods.Count)
                {
                    n++;
                }
                else
                {
                    _ = MessageBox.Show("Массив модов переполнен!\n\n" + 
                                        "Передайте разработчику код ошибки:\n" + 
                                        "MINEMODS_TOOMANYMODS",
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    line = "";
                    break;
                }
                line = s.ReadLine();
            }
            #endregion
        }

        private void OpenModDescription(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            ModInfo infoWindow = new ModInfo(lbl.Text);
            infoWindow.Show();
        }

        private void OpenModDescription1(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            ModInfo infoWindow = new ModInfo(mods[Convert.ToInt32(lbl.AccessibleName)]);
            infoWindow.Show();
        }

        private Mod AddMod(Mod mod)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 35 * modnumber + 15);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            label1.Text = mod.modName;
            label1.Cursor = Cursors.Hand;
            label1.Click += new EventHandler(OpenModDescription);
            mod.label1 = label1;
            Controls.Add(label1);
            modnumber++;
            return mod;
        }

        private Mod AddMod(Mod mod, int k, int n)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, (35 * (n+1)) + 15);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            label1.Text = mod.modName;
            label1.Cursor = Cursors.Hand;
            label1.AccessibleName = k.ToString();
            label1.Click += new EventHandler(OpenModDescription1);
            mod.label1 = label1;
            Controls.Add(label1);
            return mod;
        }

        private void AddMod(string modName)
        {
            //1st variant
            /*Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 35 * modnumber + 15);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            label1.Text = modName;
            label1.Cursor = Cursors.Hand;
            label1.Click += new EventHandler(OpenModDescription);
            Controls.Add(label1);
            modnumber++;*/

            //2nd variant
            /*AddMod(new Mod()
            {
                modName = modName,
                categories = new string[1] { "" },
                dlLink = null,
                label1 = null
            });*/

            //3rd variant
            AddMod(MineMods.Mod.Create(modName));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Поиск")
            {
                int n = 0;
                for (int i = 0; i < mods.Count; i++)
                {
                    if (mods[i].label1 == null)
                    {
                        continue;
                    }

                    mods[i].label1.Visible = true;
                    mods[i].label1.Enabled = true;

                    if (!(mods[i].modName.ToLower().Contains(textBox1.Text.ToLower())))
                    {
                        mods[i].label1.Visible = false;
                        mods[i].label1.Enabled = false;
                    }

                    if (mods[i].label1.Visible)
                    {
                        mods[i].label1.Location = new System.Drawing.Point(13, (35 * (n+1)) + 15);
                        n++;
                    }
                }
            }
        }

        private void CheckEnterKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(null, null);
                e.Handled = true;
            }
        }
    }
}
