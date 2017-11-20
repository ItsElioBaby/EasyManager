using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;

namespace EasyManager
{
    public partial class Form1 : Form
    {
        private static byte[] TripleDesKey = { 0x1A, 0x2F, 0xAC, 0x25, 0x98, 0x21, 0x4A, 0x11, 0x5A, 0xF0, 0xC4, 0x10, 0x30, 0x1A, 0xAE, 0x24, 0x00, 0x99, 0x14, 0x1E, 0x3D, 0x3A, 0x4C, 0x6B, 0x14, 0x6A, 0x5D, 0x7D, 0x4E, 0x5A, 0x1A, 0x1A, 0x00, 0x99, 0x14, 0x1E, 0x3D, 0x3A, 0x4C, 0x6B, 0x1A };
        private static byte[] TripleDesIV = { 0x11, 0x24, 0x89, 0xAC, 0xAE, 0xDE, 0x14, 0x6A, 0x5D, 0x7D, 0x4E, 0x5A, 0x1A, 0x1A, 0xAE, 0x24, 0x00, 0x99, 0x14, 0x1E, 0x3D, 0x3A, 0x4C, 0x6B, 0x1A, 0x2F, 0xAC, 0x25, 0x98, 0x21, 0x4A, 0x11 };
        
        byte[] TripleDesCrypt(byte[] data)
        {
            TripleDES des = TripleDES.Create();
            MD5 md5 = MD5.Create();

            byte[] finalKey = md5.ComputeHash(TripleDesKey);
            byte[] finalIV = md5.ComputeHash(TripleDesIV);

            md5.Clear();

            MemoryStream retvals = new MemoryStream();
            using(CryptoStream cs = new CryptoStream(retvals, des.CreateEncryptor(finalKey, finalIV), CryptoStreamMode.Write))
            {
                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();
            }
            des.Clear();
            return retvals.ToArray();
        }

        byte[] TripleDesDecrypt(byte[] data)
        {
            TripleDES des = TripleDES.Create();
            MD5 md5 = MD5.Create();

            byte[] finalKey = md5.ComputeHash(TripleDesKey);
            byte[] finalIV = md5.ComputeHash(TripleDesIV);

            md5.Clear();

            MemoryStream getvals = new MemoryStream(data);
            byte[] retval = new byte[data.Length];
            using (CryptoStream cs = new CryptoStream(getvals, des.CreateDecryptor(finalKey, finalIV), CryptoStreamMode.Read))
            {
                cs.Read(retval, 0, retval.Length);
            }
            des.Clear();
            return retval;
        }

        #region "Thanks to some random dudes."
        private static string GetExecutablePath(Process Process)
        {
            //If running on Vista or later use the new function
            if (Environment.OSVersion.Version.Major >= 6)
            {
                return GetExecutablePathAboveVista(Process.Id);
            }

            return Process.MainModule.FileName;
        }

        [Flags]
        enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000,
            ReadControl = 0x00020000
        }

        private static string GetExecutablePathAboveVista(int ProcessId)
        {
            var buffer = new StringBuilder(1024);
            IntPtr hprocess = OpenProcess(ProcessAccessFlags.QueryInformation,
                                          false, ProcessId);
            if (hprocess != IntPtr.Zero)
            {
                try
                {
                    int size = buffer.Capacity;
                    if (QueryFullProcessImageName(hprocess, 0, buffer, out size))
                    {
                        return buffer.ToString();
                    }
                }
                finally
                {
                    CloseHandle(hprocess);
                }
            }
            return "";
            //throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        [DllImport("kernel32.dll")]
        private static extern bool QueryFullProcessImageName(IntPtr hprocess, int dwFlags,
                       StringBuilder lpExeName, out int size);
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess,
                       bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hHandle);

        #endregion

        public Dictionary<string, int> Processes = new Dictionary<string, int>();
        public List<string> DonePaths = new List<string>();

        public string CollectProcessInformation()
        {
            Process[] p = Process.GetProcesses();
            StringBuilder strb = new StringBuilder();
            foreach (Process px in p)
            {
                if (px.WorkingSet64 > 0 && px.VirtualMemorySize64 > 0)  // Process is being used somehow.
                {
                    string path = GetExecutablePath(px);
                    if (path.Length > 0)
                    {
                        int runned = 0;
                        if (Processes.ContainsKey(path))
                            runned = Processes[path];
                        strb.AppendLine(path + "|" + runned.ToString());
                    }
                }
            }
            return strb.ToString();
        }

        void Contig(string dir)
        {
            if (!DonePaths.Contains(dir) && !dir.ToLower().Contains("c:\\windows") && !dir.ToLower().Contains("\\appdata\\"))  // No windows folder with conting.
            {
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.WorkingDirectory = dir;
                    proc.FileName = "Contig.exe";
                    File.Copy("Contig.exe", dir + "Contig.exe", true);
                    proc.Arguments = "-s";
                    proc.WindowStyle = ProcessWindowStyle.Hidden;
                    Process p = Process.Start(proc);
                    //p.WaitForExit();
                    File.Delete(dir + "Contig.exe");
                    DonePaths.Add(dir);
                }
                catch (Exception) { }
            }
        }

        bool defrag = false;
        bool checkup = false;
        bool cleanup = false;

        bool IsTime()
        {
            string d1 = Settings.Reader.Settings[SettingType.StartedPeriod];
            int num = int.Parse(Settings.Reader.Settings[SettingType.ScheduledTime_A]);
            if (d1 != "")
            {
                DateTime dt = DateTime.Parse(d1);
                if (DateTime.Now.Subtract(dt).Days >= num)
                {
                    return true;
                }
            }
            return false;
        }

        void Checkup(string volume)
        {
            if(IsTime())
            {
                checkup = true;
                if(volume == "0")
                {
                    Process p = Process.Start("chkdsk", "");
                    p.PriorityClass = ProcessPriorityClass.Normal;
                    notifyIcon2.Text = "EasyManager v0.1: Checking All Volumes...";
                    notifyIcon2.ShowBalloonTip(100, "Disk-Checkup", "EasyManager has launched the DSKCHK operation on all local volumes.", ToolTipIcon.Info);
                    p.WaitForExit();
                    notifyIcon2.Text = "EasyManager v0.1";
                    checkup = false;
                    return;
                }
                Process p1 = Process.Start("chkdsk", volume + " /r");
                p1.PriorityClass = ProcessPriorityClass.Normal;
                notifyIcon2.Text = "EasyManager v0.1: Checking Disk: " + volume + "...";
                notifyIcon2.ShowBalloonTip(100, "Disk-Checkup", "EasyManager has launched the DSKCHK operation on volume " + volume + "." , ToolTipIcon.Info);
                p1.WaitForExit();
                notifyIcon2.Text = "EasyManager v0.1";
                checkup = false;
                Settings.Reader.SetSetting(SettingType.StartedPeriod, DateTime.Now.ToShortDateString());
                Settings.Update();
            }
        }

        void Cleanup(string volume)
        {
            if (IsTime())
            {
                cleanup = true;
                if (volume == "0")
                {
                    Process p = Process.Start("cleanmgr", "/d");
                    p.PriorityClass = ProcessPriorityClass.Normal;
                    notifyIcon2.Text = "EasyManager v0.1: Cleaning All Volumes...";
                    notifyIcon2.ShowBalloonTip(100, "Disk-Cleanup", "EasyManager has launched the disk cleanup operation on all local volumes.", ToolTipIcon.Info);
                    p.WaitForExit();
                    notifyIcon2.Text = "EasyManager v0.1";
                    cleanup = false;
                    return;
                }
                Process p1 = Process.Start("cleanmgr", "/d " + volume);
                p1.PriorityClass = ProcessPriorityClass.Normal;
                notifyIcon2.Text = "EasyManager v0.1: Checking Disk: " + volume + "...";
                notifyIcon2.ShowBalloonTip(100, "Disk-Checkup", "EasyManager has launched the disk cleanup operation on volume " + volume + ".", ToolTipIcon.Info);
                p1.WaitForExit();
                notifyIcon2.Text = "EasyManager v0.1";
                cleanup = false;
                Settings.Reader.SetSetting(SettingType.StartedPeriod, DateTime.Now.ToShortDateString());
                Settings.Update();
            }
        }

        void Defrag(string volume)
        {
            string d1 = Settings.Reader.Settings[SettingType.StartedPeriod];
            int num = int.Parse(Settings.Reader.Settings[SettingType.ScheduledTime_A]);
            if(d1 != "")
            {
                DateTime dt = DateTime.Parse(d1);
                if(DateTime.Now.Subtract(dt).Days >= num)
                {
                    defrag = true;
                    if (volume == "0")
                    {
                        Process p = Process.Start("Defrag", "/C /H /U");
                        p.PriorityClass = ProcessPriorityClass.Normal;
                        notifyIcon2.Text = "EasyManager v0.1: Defragmeting All Volumes...";
                        notifyIcon2.ShowBalloonTip(100, "Defragmenting", "EasyManager has launched the defragmenting operation on all local volumes.", ToolTipIcon.Info);
                        p.WaitForExit();
                        notifyIcon2.Text = "EasyManager v0.1";
                        defrag = false;
                        return;
                    }
                    Process p1 = Process.Start("Defrag", volume + " /H /U");
                    p1.PriorityClass = ProcessPriorityClass.Normal;
                    notifyIcon2.Text = "EasyManager v0.1: Defragmeting " + volume + "...";
                    notifyIcon2.ShowBalloonTip(100, "Defragmenting", "EasyManager has launched the defragmenting operation on all local volumes.", ToolTipIcon.Info);
                    p1.WaitForExit();
                    notifyIcon2.Text = "EasyManager v0.1";
                    defrag = false;
                    Settings.Reader.SetSetting(SettingType.StartedPeriod, DateTime.Now.ToShortDateString());
                    Settings.Update();
                }
            }
        }

        public void OptimizeFiles()
        {
            if (File.Exists("psc.cache") && Settings.Reader.GetSetting(SettingType.OptimizeProcesses) == "True")
            {
                // Read the psc.cache file
                byte[] dsData = TripleDesDecrypt(File.ReadAllBytes("psc.cache"));
                string[] data = Encoding.ASCII.GetString(dsData).Split('\n');
                bool deleted = false;
                // Check each process..
                List<string> toBeOpt = new List<string>();
                foreach (string s in data)
                {
                    if (s.Split('|')[0].Length > 0)
                    {
                        try
                        {
                            string path = Path.GetDirectoryName(s.Split('|')[0]) + "\\";
                            int runned = int.Parse(s.Split('|')[1]);
                            if (runned > 0)
                            {
                                if(!toBeOpt.Contains(path))
                                    toBeOpt.Add(path);
                            }
                        }
                        catch (Exception) { }
                    }
                }
                if(toBeOpt.Count > 0)
                {
                    if (MessageBox.Show("EasyManager has detected that some of your processes have been running for a long time. You might need to optimize those processes.\nWould you like to perform a optimization now? (Might take its time)", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    { 
                        foreach(string path in toBeOpt)
                        {
                            Contig(path);
                            deleted = true;
                        }
                        File.Delete("psc.cache");
                        Processes.Clear();
                        notifyIcon2.ShowBalloonTip(500, "EasyManager - Contig", "EasyManager has finished optimizing your processes files.", ToolTipIcon.Info);
                    }
                }
            }
        }

        public void LoadProcesses()
        {
            if (File.Exists("psc.cache"))
            {
                byte[] dsData = TripleDesDecrypt(File.ReadAllBytes("psc.cache"));
                string[] data = Encoding.ASCII.GetString(dsData).Split('\n');

                // Check each process..
                foreach (string s in data)
                {
                    if (s.Split('|')[0].Length > 0)
                    {
                        if (Processes.ContainsKey(s.Split('|')[0]))
                            Processes[s.Split('|')[0]] += 1;
                    }
                }
            }
        }

        public SettingsFile Settings;

        public Form1()
        {
            if (!File.Exists(Environment.CurrentDirectory + "\\settings.ini"))
            {
                Settings = SettingsFile.Create("settings.ini");
            }
            else
            {
                Settings = SettingsFile.Open("settings.ini");
            }
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = radioButton4.Checked;
            if (radioButton4.Checked)
            {
                Settings.Reader.SetSetting(SettingType.ScheduledTime_A, numericUpDown1.Value.ToString());
                Settings.Reader.SetSetting(SettingType.StartedPeriod, DateTime.Now.ToShortDateString());
                Settings.Update();
            }
        }

        private Dictionary<int, ETask> candies = new Dictionary<int, ETask>();

        public void CollectTasks()
        {
            if (!Directory.Exists("tasks\\"))
            {
                //MessageBox.Show("Couldn't find \"tasks\" folder. Please create it or reinstall the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Directory.CreateDirectory("tasks");
                return;
            }
            candies.Clear();
            listView1.Items.Clear();
            foreach(string file in Directory.GetFiles("tasks\\"))
            {
                if(file.Contains(".task"))
                {
                    ETask et = ETask.Read(File.ReadAllBytes(file));
                    candies.Add(et.TaskID, et);
                    ListViewItem item = new ListViewItem(et.TaskName);
                    item.SubItems.Add(et.TaskDescription);
                    listView1.Items.Add(item);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            switch (Settings.Reader.Settings[SettingType.ScheduledTime_A])
            {
                case "1":
                    radioButton1.Checked = true;
                    break;
                case "7":
                    radioButton2.Checked = true;
                    break;
                case "30":
                    radioButton3.Checked = true;
                    break;
                default:
                    radioButton4.Checked = true;
                    break;
            }
            checkBox1.Checked = bool.Parse(Settings.Reader.Settings[SettingType.Defrag]);
            checkBox2.Checked = bool.Parse(Settings.Reader.Settings[SettingType.CleanUp]);
            checkBox3.Checked = bool.Parse(Settings.Reader.Settings[SettingType.CheckUp]);
            checkBox4.Checked = bool.Parse(Settings.Reader.Settings[SettingType.ContingWindows]);
            checkBox5.Checked = bool.Parse(Settings.Reader.Settings[SettingType.PackUsageReports]);
            checkBox6.Checked = bool.Parse(Settings.Reader.Settings[SettingType.OptimizeProcesses]);
            timer1.Start();
            new Thread(OptimizeFiles).Start();
            Cleanup("C:");
            Cleanup("D:");
            Checkup("C:");
            Defrag("0");
            LoadProcesses();
            CollectTasks();
            timer2.Start();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.SetSetting(SettingType.ScheduledTime_A, "1");
            Settings.Reader.SetSetting(SettingType.StartedPeriod, DateTime.Now.ToShortDateString());
            Settings.Update();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.SetSetting(SettingType.ScheduledTime_A, "7");
            Settings.Reader.SetSetting(SettingType.StartedPeriod, DateTime.Now.ToShortDateString());
            Settings.Update();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.SetSetting(SettingType.ScheduledTime_A, "30");
            Settings.Update();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Settings.Reader.SetSetting(SettingType.ScheduledTime_A, numericUpDown1.Value.ToString());
            Settings.Reader.SetSetting(SettingType.StartedPeriod, DateTime.Now.ToShortDateString());
            Settings.Update();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.Settings[SettingType.Defrag] = checkBox1.Checked.ToString();
            Settings.Update();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.Settings[SettingType.CleanUp] = checkBox2.Checked.ToString();
            Settings.Update();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.Settings[SettingType.CheckUp] = checkBox3.Checked.ToString();
            Settings.Update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string psc = CollectProcessInformation();
            foreach (string l in psc.Split('\n'))
            {
                string[] pp = l.Split('|');
                if (Processes.ContainsKey(pp[0]))
                {
                    Processes[pp[0]] += 1;
                }
                else
                    Processes.Add(pp[0], 0);
            }
            StringBuilder strbld = new StringBuilder();
            foreach (var v in Processes)
            {
                strbld.AppendLine(v.Key + "|" + v.Value.ToString());
            }
            byte[] gbData = Encoding.ASCII.GetBytes(strbld.ToString());
            File.WriteAllBytes("psc.cache", TripleDesCrypt(gbData));
        }

        private void checkBox4_MouseHover(object sender, EventArgs e)
        {
            label5.Text = "Allow contig to be used upon windows folders such as \"Windows\" or \"Windows\\System32\". This may take quite a lot of time.";
        }

        private void checkBox5_MouseHover(object sender, EventArgs e)
        {
            label5.Text = "Takes notes of internal software activity such as expections or user-defined commands, in order to contribute to a better software. Upload your data to our website.";
        }

        private void checkBox6_MouseHover(object sender, EventArgs e)
        {
            label5.Text = "The more you run a program, the more likely it is to access data on your HDD. This operation performs a file optimization inside the most used processes to ensure a better overall performace.";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.SetSetting(SettingType.ContingWindows, checkBox4.Checked.ToString());
            Settings.Update();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.SetSetting(SettingType.PackUsageReports, checkBox5.Checked.ToString());
            Settings.Update();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Reader.SetSetting(SettingType.OptimizeProcesses, checkBox6.Checked.ToString());
            Settings.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskWizard wizard = new TaskWizard();
            wizard.ShowDialog(this);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lock(candies)
            {
                List<int> keys_to_remove = new List<int>();
                foreach(var v in candies)
                {
                    if (DateTime.Now.DayOfWeek == v.Value.ExecuteTime.DayOfWeek && DateTime.Now.Hour >= v.Value.ExecuteTime.Hour && DateTime.Now.Minute >= v.Value.ExecuteTime.Minute)
                    {
                        v.Value.Run();
                        keys_to_remove.Add(v.Key);
                    }
                }
                foreach (var v in keys_to_remove)
                    candies.Remove(v);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lock(candies)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    foreach (var v in candies)
                    {
                        if(v.Value.TaskName == item.Text && v.Value.TaskDescription == item.SubItems[1].Text)
                        {
                            TaskWizard t = new TaskWizard(v.Value);
                            timer2.Stop();
                            t.ShowDialog(this);
                            timer2.Start();
                            return;
                        }
                    }
                }
            }
        }

        bool showed = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                if(!showed)
                {
                    notifyIcon2.Text = "EasyManager v0.1a";
                    notifyIcon2.ShowBalloonTip(500, "EasyManager", "EasyManager is now running in the background. To close the application right click on this icon.", ToolTipIcon.Info);
                    showed = true;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
    }
}
