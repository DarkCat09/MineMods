using System;
using System.Windows.Forms;

namespace MineMods
{
    public class Mod
    {
        public string modName;
        public string[] categories;
        public Uri dlLink;
        public Label label1;

        public static Mod Create(string name)
        {
            Mod m = new Mod()
            {
                modName = name,
                categories = new string[1] { "" },
                dlLink = null,
                label1 = null
            };

            return m;
        }
    }
}
