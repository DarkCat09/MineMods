using System;
using System.IO;
using System.Windows.Forms;

namespace MineMods
{
    public partial class Mods : Form
    {
        /// <summary>
        /// Last Mod
        /// </summary>
        int modnumber = 1;

        public struct Mod
        {
            public string modName;
            public string[] categories;
            public Uri dlLink;
            public Label label1;
        }

        Mod[] mods = new Mod[500];

        public Mods(string category)
        {
            InitializeComponent();

            this.Text = "Моды - " + category;

            #region checking category ifs
            /*if (category == "Клиент")
            {
                AddMod("MapWriter2");
                AddMod("JourneyMap");
                AddMod("Just Enough Items");
                AddMod("Just Enough Resources");
                AddMod("Faster Ladder Climbing");
                AddMod("Back Tools");
                AddMod("Neat");
            }
            else if (category == "Сервер,мир")
            {
                AddMod("WorldEdit");
            }
            else if (category == "Еда")
            {
                AddMod("Pam's HarvestCraft");
                AddMod("Simply Tea!");
                AddMod("Peanuts!");
                AddMod("Simple Farming");
                AddMod("Maple syrup");
                AddMod("Culinary Construct");
                AddMod("Useful Food");
            }
            else if (category == "Мебель")
            {
                AddMod("MrCrayfish's Furniture Mod");
                AddMod("Macaw's Furniture");
                AddMod("Macaw's Roofs");
                AddMod("Simply Light");
                AddMod("Lightest Lamps");
                AddMod("Carpet Stairs");
                AddMod("Chinese Workshop");
            }
            else if (category == "Транспорт")
            {
                AddMod("Ultimate Car");
                AddMod("Generic American Motoring");
                AddMod("MrCrayfish's Vechicle Mod");
                AddMod("Saracalia's City");
                AddMod("Real Train Mod");
                AddMod("Paragliders");
            }
            else if (category == "Электроника" || category == "Оружие" || category == "Электроника и оружие")
            {
                AddMod("OpenComputers");
                AddMod("ComputerCraft");
                AddMod("The Spotlight Mod");
                AddMod("Simply Light");
                AddMod("Lightest Lamps");
                AddMod("Vic's Modern Warfare");
                AddMod("MrCrayfish's Gun Mod");
                AddMod("Techguns");
                AddMod("Torch Bow Mod");
                AddMod("Super Hot");
            }
            else if (category == "Графика")
            {
                AddMod("OptiFine");
                AddMod("Localized Weather && Stormfronts");
                AddMod("Simple Colored Blocks");
            }
            else if (category == "Блоки" || category == "Другое" || category == "Блоки и другое")
            {
                AddMod("PrinterBlock Mod");
                AddMod("MC Paint");
                AddMod("Chisel");
                AddMod("Aurum's More Blocks");
                AddMod("Absent by Design");
                AddMod("Asphalt Mod");
                AddMod("Custom NPCs");
                AddMod("JJ Coin");
                AddMod("Money");
                AddMod("Smoke Signal");
                AddMod("ExtraButtons");
            }
            else
            {
                Close();
            }*/
            #endregion

            #region checking category fromfile
            StreamReader s = new StreamReader("mods.txt");
            string line = "";

            line = s.ReadLine();
            int n = 0;
            int y = 0;
            while (line != null)
            {
                if (line.Split(new char[] { ';' }).Length >= 1)
                {
                    mods[n].modName = line.Split(new char[] { ';' })[0];
                    mods[n].categories = (line.Split(new char[] { ';' })[1]).Split(new char[] { ',' });
                }

                if (line.Split(new char[] { ';' }).Length >= 3)
                {
                    mods[n].dlLink = new Uri(line.Split(new char[] { ';' })[3]);
                }
                else
                {
                    mods[n].dlLink = null;
                }

                if (category != "Все моды")
                {
                    if (category == "Сервер,мир")
                    {
                        for (int i = 0; i < ((line.Split(new char[] { ';' })[1]).Split(new char[] { ',' })).Length; i++)
                        {
                            if (mods[n].categories[i] == "Сервер" || mods[n].categories[i] == "Мир")
                            {
                                AddMod(mods[n], n, y);
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
                                AddMod(mods[n], n, y);
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
                                    AddMod(mods[n], n, y);
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
                                    AddMod(mods[n], n, y);
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
                                AddMod(mods[n], n, y);
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
                                AddMod(mods[n], n, y);
                                y++;
                            }
                        }
                    }
                }
                else
                {
                    AddMod(mods[n], n, y);
                    y++;
                }

                if (n <= mods.Length)
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

        private void AddMod(Mod mod)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 30 * modnumber - 15);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            label1.Text = mod.modName;
            label1.Cursor = Cursors.Hand;
            label1.Click += new EventHandler(OpenModDescription);
            Controls.Add(label1);
            modnumber++;
        }

        private void AddMod(Mod mod, int k, int n)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, (30 * (n+1)) - 15);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            label1.Text = mod.modName;
            label1.Cursor = Cursors.Hand;
            label1.AccessibleName = k.ToString();
            label1.Click += new EventHandler(OpenModDescription1);
            mod.label1 = label1;
            Controls.Add(label1);
        }

        private void AddMod(string modName)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 30 * modnumber - 15);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            label1.Text = modName;
            label1.Cursor = Cursors.Hand;
            label1.Click += new EventHandler(OpenModDescription);
            Controls.Add(label1);
            modnumber++;
        }
    }
}
