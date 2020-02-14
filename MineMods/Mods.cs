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
        }

        public Mods(string category)
        {
            InitializeComponent();

            #region checking category
            if (category == "Клиент")
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
            }
            /*StreamReader s = new StreamReader("mods.txt");
            string line = "";

            while ((line = s.ReadLine()) != null)
            {
                //code
            }*/
            #endregion
        }
        private void OpenModDescription(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            ModInfo infoWindow = new ModInfo(lbl.Text);
            infoWindow.Show();
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
