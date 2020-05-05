using System;
using System.Drawing;

namespace MineMods
{
    class Vars
    {
        public static Font MAINFONT = new Font("Verdana", 9);
        public static string modsFile = "mods.txt";

        public static string ParseModFileName(string modName)
        {
            return modName.Replace("&&", "&").Replace("&", "and").Replace(" ", "_").Replace("_(", "-").Replace(")", "");
        }
    }
}
