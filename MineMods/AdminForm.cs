﻿using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;

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
                               "\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft\\mods";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string promptPasswdFromFile = "";
            string correctPasswdFromFile = "";

            byte[] tmpSource;  //source passwd that writed in passwdbox
            byte[] tmpHash;    //hash of passwd that writed in passwdbox
            byte[] correctHash;//hash of correct passwd

            if (File.Exists(".admin_passwd.conf"))
            {
                StreamReader s = new StreamReader(".admin_passwd.conf");
                correctPasswdFromFile = s.ReadLine();
                promptPasswdFromFile = s.ReadLine();

                if (promptPasswdFromFile == "False")
                {
                    promptPasswd = false;
                }
                else
                {
                    promptPasswd = true;
                }

                s.Close();

                correctHash = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(correctPasswdFromFile));
            }
            else
            {
                DateTime today = DateTime.Today;
                string defpasswd = "$changeme" + today.ToString("ddMMyyyy");

                File.WriteAllText(".admin_passwd.conf", defpasswd + "\n" + promptPasswd.ToString());
                correctHash = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(defpasswd));
                promptPasswd = true;
            }

            if (textBox1.Text == "")
            {
                if (promptPasswd)
                {
                    _ = MessageBox.Show("Введите пароль!", "Ошибка авторизации",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tabControl1.Visible = false;
                }
                else
                {
                    _ = MessageBox.Show("Авторизация успешна!");
                    tabControl1.Visible = true;
                }
            }
            else
            {
                tmpSource = ASCIIEncoding.ASCII.GetBytes(textBox1.Text);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

                //for debug
                _ = MessageBox.Show(ByteArrayToString(correctHash));

                //comparing hash
                bool bEqual = false;
                if (tmpHash.Length == tmpHash.Length)
                {
                    int i = 0;
                    while ((i < tmpHash.Length) && (tmpHash[i] == correctHash[i]))
                    {
                        i += 1;
                    }
                    if (i == tmpHash.Length)
                    {
                        bEqual = true;
                    }
                }

                if (bEqual)
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

        //for debug
        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);

            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }

            return sOutput.ToString();
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
                File.WriteAllText(".admin_passwd.conf", textBox4.Text + "\n" + promptPasswd.ToString());
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

            StreamReader s = new StreamReader(".admin_passwd.conf");
            string passwdFromFile = s.ReadLine();
            s.Close();

            File.WriteAllText(".admin_passwd.conf", passwdFromFile + "\n" + promptPasswd.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            promptPasswd = false;

            StreamReader s = new StreamReader(".admin_passwd.conf");
            string passwdFromFile = s.ReadLine();
            s.Close();

            File.WriteAllText(".admin_passwd.conf", passwdFromFile + "\n" + promptPasswd.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                bool correctcmd = true;
                Random rand = new Random();
                pictureBox1.Image = loadgifs[rand.Next(3)];

                if (textBox5.Text == "start-console")
                {
                    correctcmd = true;

                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    textBox6.Text += "Starting console service...";
                    console_started = true;
                    textBox6.Text += Environment.NewLine + "Console service started sucessfully!";
                }
                else if (textBox5.Text == "stop-console")
                {
                    correctcmd = true;

                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    textBox6.Text += "Stopping console service...";
                    console_started = false;
                    textBox6.Text += Environment.NewLine + "Console service stopped!";
                }
                else
                {
                    if (console_started)
                    {
                        if (textBox5.Text.StartsWith("echo"))
                        {
                            correctcmd = true;

                            if (textBox6.Text != "")
                                textBox6.Text += Environment.NewLine;

                            string[] echotext = textBox5.Text.Split(new char[] { '\"' });

                            if (echotext.Length == 3 || echotext.Length == 1)
                            {
                                if (echotext.Length == 1)
                                {
                                    textBox6.Text += Environment.NewLine;
                                }
                                else
                                {
                                    textBox6.Text += echotext[1];
                                }
                            }
                            else
                            {
                                textBox6.Text += "echo: Invalid syntax!" + Environment.NewLine;
                                textBox6.Text += "Usage ECHO-command:\n echo [\"text\"]";
                            }
                        }
                        else if (textBox5.Text.StartsWith("cmd"))
                        {
                            _ = MessageBox.Show("Эта функция ещё не работает должным образом.");

                            /*
                            correctcmd = true;

                            if (textBox6.Text != "")
                                textBox6.Text += Environment.NewLine;

                            string[] cmdtext = textBox5.Text.Split(new char[] { '\"' });

                            if (cmdtext.Length == 3)
                            {
                                string command = "";
                                bool pauseAfterRunningCmd = false;
                                if (cmdtext[2].StartsWith(" pause"))
                                {
                                    pauseAfterRunningCmd = true;
                                }

                                if (pauseAfterRunningCmd)
                                {
                                    command = cmdtext[1] + @" & pause";
                                }
                                else
                                {
                                    command = cmdtext[1];
                                }

                                //for debug
                                textBox6.Text += cmdtext[1] + " _ " + pauseAfterRunningCmd.ToString();

                                ProcessStartInfo pinfo = new ProcessStartInfo(@"cmd.exe", command);

                                if (!pauseAfterRunningCmd)
                                {
                                    pinfo.WindowStyle = ProcessWindowStyle.Hidden;
                                    pinfo.RedirectStandardOutput = true;
                                    pinfo.UseShellExecute = false;
                                    pinfo.CreateNoWindow = true;
                                }

                                Process p = Process.Start(pinfo);

                                if (!pauseAfterRunningCmd)
                                {
                                    StreamReader cmdoutreader = p.StandardOutput;
                                    textBox6.Text += "CMD started!" + Environment.NewLine;
                                    textBox6.Text += cmdoutreader.ReadToEnd();

                                    cmdoutreader.Close();
                                    p.WaitForExit();

                                    textBox6.Text += "CMD stoped!";
                                }
                            }
                            else
                            {
                                textBox6.Text += "cmd: Invalid syntax!" + Environment.NewLine;
                                textBox6.Text += "Usage CMD-command:\n cmd <\"command\"> [pause]";
                            }
                            */
                        }
                        else
                        {
                            correctcmd = false;
                        }
                    }
                    else
                    {
                        correctcmd = false;
                        if (textBox6.Text != "")
                            textBox6.Text += Environment.NewLine;

                        textBox6.Text += "Command not found!";
                        textBox6.Text += Environment.NewLine + "First try command \"start-console\".";
                    }
                }

                if (!correctcmd)
                {
                    if (textBox6.Text != "")
                        textBox6.Text += Environment.NewLine;

                    textBox6.Text += "Command not found!";
                    textBox6.Text += Environment.NewLine + "First try command \"start-console\".";
                }

                pictureBox1.Image = null;
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
    }
}
