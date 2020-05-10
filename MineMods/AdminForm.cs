using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net;

namespace MineMods
{
    public partial class AdminForm : Form
    {
        System.Drawing.Bitmap[] loadgifs =
        {
            Properties.Resources.minecraft_load0,
            Properties.Resources.minecraft_load1,
            Properties.Resources.minecraft_load2
        };

        bool promptPasswd = true;
        bool console_started = false;
        string modFilename = "";
        string modsDirectory = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) +
                               "Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft\\mods";

        System.Drawing.Bitmap loadgif;
        int timeLoadgifShown;

        string modImagePath = "";

        public AdminForm()
        {
            InitializeComponent();

            label3.Text = "Укажите путь до папки с модами\n(обычно " + modsDirectory + ")";
            textBox2.Text = modsDirectory;

            tabControl1.Visible = false;
            textBox1.Visible = false;
        }

        private void ввестиПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        public string HashByteArrayToString(byte[] input)
        {
            byte[] data = input;
            StringBuilder sBuild = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuild.Append(data[i].ToString("x2"));
            }

            return sBuild.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string promptPasswdFromFile = "";
            string correctHashFromFile = "";

            byte[] tmpSource;  //source passwd that writed in passwdbox
            byte[] tmpHash;    //hash of passwd that writed in passwdbox

            if (File.Exists(".admin_passwd.conf"))
            {
                StreamReader s = new StreamReader(".admin_passwd.conf", Encoding.UTF8);
                correctHashFromFile = s.ReadLine();
                promptPasswdFromFile = s.ReadLine();

                promptPasswd = (promptPasswdFromFile != "False");

                s.Close();
            }
            else
            {
                DateTime today = DateTime.Today;
                string defpasswd = "$changeme" + today.ToString("ddMMyyyy");
                byte[] defpasswdhash = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(defpasswd));

                File.WriteAllText(".admin_passwd.conf", HashByteArrayToString(defpasswdhash) + "\r\n" +
                                  promptPasswd.ToString() + "\r\n", Encoding.UTF8);
                correctHashFromFile = HashByteArrayToString(defpasswdhash);
                promptPasswd = true;
            }

            if (textBox1.Text == "")
            {
                tabControl1.Visible = !promptPasswd;
                if (promptPasswd)
                {
                    _ = MessageBox.Show("Введите пароль!", "Ошибка авторизации",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _ = MessageBox.Show("Авторизация успешна!");
                }
            }
            else
            {
                tmpSource = Encoding.UTF8.GetBytes(textBox1.Text);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

                //for debug
                /*_ = MessageBox.Show("Введено: " + HashByteArrayToString(tmpHash) + "\n" +
                                    "Правильный: " + correctHashFromFile);*/

                if (HashByteArrayToString(tmpHash) == correctHashFromFile)
                {
                    _ = MessageBox.Show("Авторизация успешна!");
                    tabControl1.Visible = true;
                }
                else
                {
                    _ = MessageBox.Show("Неверный пароль!");
                    tabControl1.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            modsDirectory = folderBrowserDialog1.SelectedPath;
            textBox2.Text = modsDirectory;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            modFilename = openFileDialog1.FileName;
            textBox3.Text = modFilename;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (modFilename == "")
            {
                _ = MessageBox.Show("Выберите jar-файл с модификацией!",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
            else
            {
                string[] filenamearr = modFilename.Split(new char[] { '\\' });
                File.Copy(modFilename, modsDirectory + "\\" + filenamearr[filenamearr.Length - 1]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                string newCorrectHash = HashByteArrayToString(
                    new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(textBox4.Text)));

                File.WriteAllText(".admin_passwd.conf",
                                  newCorrectHash + "\n" + promptPasswd.ToString());
            }
            else
            {
                _ = MessageBox.Show("Введите новый пароль!\n\n" + 
                                    "Чтобы отключить вход по паролю,\n" +
                                    "установите параметр \"Требовать пароль?\" в значение \"Нет\".",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            promptPasswd = true;

            StreamReader s = new StreamReader(".admin_passwd.conf", Encoding.UTF8);
            string hashFromFile = s.ReadLine();
            s.Close();

            File.WriteAllText(".admin_passwd.conf", hashFromFile + "\n" + promptPasswd.ToString(), Encoding.UTF8);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            promptPasswd = false;

            StreamReader s = new StreamReader(".admin_passwd.conf", Encoding.UTF8);
            string hashFromFile = s.ReadLine();
            s.Close();

            File.WriteAllText(".admin_passwd.conf", hashFromFile + "\n" + promptPasswd.ToString(), Encoding.UTF8);
        }

        private void EnableTimer(Timer t)
        {
            try
            {
                pictureBox1.Image = loadgif;
                t.Enabled = true;
                timeLoadgifShown = Environment.TickCount;
            }
            catch (Exception e)
            {
                _ = MessageBox.Show(e.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            loadgif = loadgifs[rand.Next(3)];

            if (textBox5.Text != "")
            {

                if (textBox5.Text == "start-console")
                {
                    EnableTimer(timer1);

                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    textBox6.Text += "Starting console service...";
                    console_started = true;
                    textBox6.Text += Environment.NewLine + "Console service started sucessfully!";
                }
                else if (textBox5.Text == "stop-console")
                {
                    EnableTimer(timer1);

                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    textBox6.Text += "Stopping console service...";
                    console_started = false;
                    textBox6.Text += Environment.NewLine + "Console service stopped!";
                }
                else if (console_started && textBox5.Text.StartsWith("echo"))
                {
                    EnableTimer(timer1);

                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    string[] echotext = textBox5.Text.Split(new char[] { '\"' });

                    if (echotext.Length == 1)
                    {
                        textBox6.Text += Environment.NewLine;
                    }
                    else if (echotext.Length == 3)
                    {
                        textBox6.Text += echotext[1];
                    }
                    else
                    {
                        textBox6.Text += "echo: Invalid syntax!" + Environment.NewLine;
                        textBox6.Text += "Usage ECHO-command:\n echo [\"text\"]";
                    }
                }
                else if (console_started && textBox5.Text.StartsWith("cmd"))
                {
                    //_ = MessageBox.Show("Эта функция ещё не работает должным образом.");

                    EnableTimer(timer1);
                    
                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    string[] cmdtext = textBox5.Text.Split(new char[] { '\"' });

                    if (cmdtext.Length == 3)
                    {
                        bool pauseAfterRunningCmd = (cmdtext[2].StartsWith(" pause"));
                                
                        string command = cmdtext[1];
                        if (pauseAfterRunningCmd)
                        {
                            command += " & pause";
                        }

                        //for debug
                        textBox6.Text += cmdtext[1] + " _ " + pauseAfterRunningCmd.ToString();
                        textBox6.Text += Environment.NewLine;

                        ProcessStartInfo pinfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                        pinfo.UseShellExecute = false;
                        pinfo.RedirectStandardInput = true;

                        if (!pauseAfterRunningCmd)
                        {
                            pinfo.WindowStyle = ProcessWindowStyle.Hidden;
                            pinfo.StandardOutputEncoding = Encoding.GetEncoding(866);
                            pinfo.RedirectStandardOutput = true;
                            pinfo.CreateNoWindow = true;
                        }

                        Process p = new Process();
                        p.StartInfo = pinfo;
                        p.Start();

                        if (!pauseAfterRunningCmd)
                        {
                            textBox6.Text += "CMD started!" + Environment.NewLine;

                            textBox6.Text += p.StandardOutput.ReadToEnd();
                            p.WaitForExit(10000);

                            textBox6.Text += "CMD stopped!";
                        }
                    }
                    else
                    {
                        textBox6.Text += "cmd: Invalid syntax!" + Environment.NewLine;
                        textBox6.Text += "Usage CMD-command:\n cmd <\"command\"> [pause]";
                    }
                }    
                else
                {
                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    textBox6.Text += "Command not found!";
                    textBox6.Text += Environment.NewLine + "First try command \"start-console\".";
                }
            }
        }

        private void показатьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = false;
        }

        private void скрытьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }

        public static string login = "";
        public static string password = "";
        private void button10_Click(object sender, EventArgs e)
        {
            string dscrFilepath = "";
            string pictFilepath = "";
            string dscrFilename = "";
            string pictFilename = "";

            string strToWrite = "";

            FtpAuthForm ftpauth = new FtpAuthForm();
            ftpauth.ShowDialog();

            #region checking options - is empty?
            if (textBox7.Text == "")
            {
                _ = MessageBox.Show("Введите название мода!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox1.Text == "" && comboBox2.Text == "")
            {
                _ = MessageBox.Show("Выберите категорию мода!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                strToWrite = textBox7.Text + ";" + comboBox1.Text + "," + comboBox2.Text;
            }

            if (textBox8.Text == "")
            {
                string warnboxres = MessageBox.Show("Вы не указали ссылку для скачивания этой модификации.\nПродолжить?",
                                                    "Предупреждение",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning).ToString();
                if (warnboxres == "No")
                {
                    return;
                }
            }
            else
            {
                strToWrite += ";" + textBox8.Text;
            }
            #endregion

            #region saving description and picture
            dscrFilename = Vars.ParseModFileName(textBox7.Text) + "-dscr.txt";
            dscrFilepath = "mods\\" + dscrFilename;
            File.WriteAllLines(dscrFilepath, textBox9.Lines);
            if (modImagePath != "") {
                string[] imgpathSubstrs = modImagePath.Split('.');
                pictFilename = Vars.ParseModFileName(textBox7.Text) + "-icon." +
                    imgpathSubstrs[imgpathSubstrs.Length - 1];
                pictFilepath = "mods\\" + pictFilename;
                File.Copy(modImagePath, pictFilepath);
            }
            #endregion

            if (comboBox1.Text != "" || comboBox2.Text != "")
            {
                File.AppendAllText("mods.txt", strToWrite + "\r\n");
            }

            #region uploading files to ftp-server
            try
            {
                //modsfile
                FtpWebRequest reqModsfile = (FtpWebRequest)WebRequest.Create(
                    "ftp://files.000webhost.com:21/public_html/mods/mods.txt");
                reqModsfile.Method = WebRequestMethods.Ftp.UploadFile;
                reqModsfile.Credentials = new NetworkCredential(login, password);

                FileStream fsMods = new FileStream("mods.txt", FileMode.Open);
                byte[] fileContents = new byte[fsMods.Length];
                fsMods.Read(fileContents, 0, fileContents.Length);
                fsMods.Close();
                reqModsfile.ContentLength = fileContents.Length;

                Stream reqModsfileStream = reqModsfile.GetRequestStream();
                reqModsfileStream.Write(fileContents, 0, fileContents.Length);
                reqModsfileStream.Close();

                //description
                FtpWebRequest reqDscr = (FtpWebRequest)WebRequest.Create(
                    "ftp://files.000webhost.com:21/public_html/mods/" + dscrFilename);
                reqDscr.Method = WebRequestMethods.Ftp.UploadFile;
                reqDscr.Credentials = new NetworkCredential(login, password);

                FileStream fsDscr = new FileStream(dscrFilepath, FileMode.Open);
                fileContents = new byte[fsDscr.Length];
                fsDscr.Read(fileContents, 0, fileContents.Length);
                fsDscr.Close();
                reqDscr.ContentLength = fileContents.Length;

                Stream reqDscrFileStream = reqDscr.GetRequestStream();
                reqDscrFileStream.Write(fileContents, 0, fileContents.Length);
                reqDscrFileStream.Close();

                //picture
                FtpWebRequest reqPict = (FtpWebRequest)WebRequest.Create(
                    "ftp://files.000webhost.com:21/public_html/mods/" + pictFilename);
                reqPict.Method = WebRequestMethods.Ftp.UploadFile;
                reqPict.Credentials = new NetworkCredential(login, password);

                FileStream fsPict = new FileStream(pictFilepath, FileMode.Open);
                fileContents = new byte[fsPict.Length];
                fsPict.Read(fileContents, 0, fileContents.Length);
                fsPict.Close();
                reqPict.ContentLength = fileContents.Length;

                Stream reqPictFileStream = reqPict.GetRequestStream();
                reqPictFileStream.Write(fileContents, 0, fileContents.Length);
                reqPictFileStream.Close();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            _ = MessageBox.Show("Готово!");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _ = Process.Start(textBox8.Text);
        }

        private void показатьПарольToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
        }

        private void скрытьПарольToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (Environment.TickCount - timeLoadgifShown < 1500)
            {
                //wait
            }

            pictureBox1.Image = null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            modImagePath = openFileDialog2.FileName;
            pictureBox2.Load(modImagePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> launcherDownloadUrls = new Dictionary<string, string>()
            {
                {"Minecraft Launcher", "https://launcher.mojang.com/download/MinecraftInstaller.msi"},
                {"TLauncher", "https://tlauncher.org/installer"},
                {"MLauncher", "https://mlauncher.ru/downloading"},
                {"ATLauncher", "https://atlauncher.com/download/exe"},
                {"FreeLauncher", "https://github.com/dedepete/FreeLauncher/releases/download/v0.2.4/FreeLauncher.exe"},
                {"MRLauncher", "https://misterlauncher.org/download/windows"},
                {"CyberMC", "https://cybermc.ru/resources/minecraft.1/download?version=44"},
                {"MultiMC", "https://files.multimc.org/downloads/mmc-stable-win32.zip"},
                {"GID-Launcher", "https://gid-minecraft.ru/download.php?c=launchers&s=9a24ee4e6a7cb2cb32ec4dcf687d8e75&f=GID-Launcher-win-setup.exe&pid=9854&eid=0&t=1589048036"}
            };

            string downloadUrl =
                (radioButton1.Checked)  ? launcherDownloadUrls["Minecraft Launcher"] :
                (radioButton2.Checked)  ? launcherDownloadUrls["TLauncher"] :
                (radioButton3.Checked)  ? launcherDownloadUrls["MLauncher"] :
                (radioButton4.Checked)  ? launcherDownloadUrls["ATLauncher"] :
                (radioButton6.Checked)  ? launcherDownloadUrls["FreeLauncher"] :
                (radioButton7.Checked)  ? launcherDownloadUrls["MRLauncher"] :
                (radioButton8.Checked)  ? launcherDownloadUrls["CyberMC"] :
                (radioButton9.Checked)  ? launcherDownloadUrls["MultiMC"] :
                (radioButton10.Checked) ? launcherDownloadUrls["GID-Launcher"] :
                "error";
        }
    }
}
