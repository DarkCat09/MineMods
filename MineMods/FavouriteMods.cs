using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MineMods
{
    public partial class FavouriteMods : Form
    {
        public static List<Mods.Mod> favmods = new List<Mods.Mod>();

        public FavouriteMods()
        {
            InitializeComponent();

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
            label1.Font = new System.Drawing.Font("Verdana", 12);
            label1.Location = new System.Drawing.Point(10, 48*(n+1));
            label1.Size = new System.Drawing.Size(353, 18);
            label1.Text = mod.modName;
            label1.AccessibleName = n.ToString();
        }
    }
}
