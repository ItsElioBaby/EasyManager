using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace EasyManager
{
    public partial class TaskWizard : Form
    {
        ETask task;

        public TaskWizard()
        {
            InitializeComponent();
            task = new ETask(tNameBox.Text, tNameBox.Text, dateTimePicker1.Value.ToBinary(), -1, new Random().Next());
        }

        public TaskWizard(ETask t)
        {
            InitializeComponent();
            task = t;
            checkBox1.Checked = t.MessageAlert;
            checkBox2.Checked = t.SoundAlert;
            checkBox3.Checked = t.RunProcess;
            checkBox4.Checked = t.ExecuteBatch;
            dateTimePicker1.Value = t.ExecuteTime;
            checkBox5.Checked = t.ExecuteEveryDay != -1;
            if (checkBox5.Checked)
                execEvery.SelectedIndex = t.ExecuteEveryDay - 1;
            tNameBox.Text = t.TaskName;
            tDescBox.Text = t.TaskDescription;

            msgTextBox.Text = t.MessageText;
            msgTitleBox.Text = t.MessageTitle;
            soundFileBox.Text = t.SoundFile;
            batchFileBox.Text = t.BatchFile;
            processFileBox.Text = t.ProcessFile;
            procParamsBox.Text = t.ProcessParameters;
            Application.DoEvents();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            execEvery.Enabled = checkBox5.Checked;
            lock(task)
            {
                if (!checkBox5.Checked)
                    task.ExecuteEveryDay = -1;
                /*else
                {
                    int day = 0;
                    switch (execEvery.SelectedValue.ToString())
                    {
                        case "Monday":
                            day = 1; break;
                        case "Tuesday":
                            day = 2; break;
                        case "Wednsday":
                            day = 3; break;
                        case "Thursday":
                            day = 4; break;
                        case "Friday":
                            day = 5; break;
                        case "Saturday":
                            day = 6; break;
                        case "Sunday":
                            day = 7; break;
                    }
                    task.ExecuteEveryDay = day;
                }*/
            }
        }

        private void tNameBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
            {
                task.TaskName = tNameBox.Text;
            }
        }

        private void tDescBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
            {
                task.TaskDescription = tDescBox.Text;
            }
        }

        private void execEvery_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock(task)
            {
                int day = 0;
                switch (execEvery.Text)
                {
                    case "Monday":
                        day = 1; break;
                    case "Tuesday":
                        day = 2; break;
                    case "Wednsday":
                        day = 3; break;
                    case "Thursday":
                        day = 4; break;
                    case "Friday":
                        day = 5; break;
                    case "Saturday":
                        day = 6; break;
                    case "Sunday":
                        day = 7; break;
                }
                task.ExecuteEveryDay = day;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lock(task)
            {
                task.ExecuteTime = dateTimePicker1.Value;
            }
        }

        private void msgTitleBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
                task.MessageTitle = msgTitleBox.Text;
        }

        private void msgTextBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
                task.MessageText = msgTextBox.Text;
        }

        private void soundFileBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
                task.SoundFile = soundFileBox.Text;
        }

        private void processFileBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
                task.ProcessFile = processFileBox.Text;
        }

        private void batchFileBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
                task.BatchFile = batchFileBox.Text;
        }

        private void procParamsBox_TextChanged(object sender, EventArgs e)
        {
            lock(task)
                task.ProcessParameters = procParamsBox.Text;
                
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lock(task)
                task.MessageAlert = checkBox1.Checked;
            msgGroup.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            lock(task)
                task.SoundAlert = checkBox2.Checked;
            soundGroup.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            lock(task)
                task.RunProcess = checkBox3.Checked;
            processGroup.Enabled = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            lock(task)
                task.ExecuteBatch = checkBox4.Checked;
            batchGroup.Enabled = checkBox4.Checked;
        }
        private void Msg(string tit, string text)
        {
            MessageBox.Show(tit, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists("tasks\\"))
            {
                MessageBox.Show("Couldn't find \"tasks\" folder. Please create it or restart the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(task.SoundAlert && (string.IsNullOrEmpty(soundFileBox.Text)))
            {
                Msg("Please select a valid sound file to be played.", "Error");
                return;
            }
            if(task.RunProcess && string.IsNullOrEmpty(processFileBox.Text))
            {
                Msg("Please select a valid process to be started.", "Error");
                return;
            }
            if(task.ExecuteBatch && string.IsNullOrEmpty(batchFileBox.Text))
            {
                Msg("Please select a valid batch file to be executed.", "Error");
                return;
            }

            if(string.IsNullOrEmpty(task.TaskName) || string.IsNullOrEmpty(task.TaskDescription))
            {
                Msg("Please fill in the right info.", "Error");
                return;
            }

            byte[] data = task.ToArray();
            File.WriteAllBytes("tasks\\" + task.TaskID.ToString("x") + ".task", data);
            ((Form1)Owner).CollectTasks();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opg = new OpenFileDialog() { Title = "Select your desired sound file to be played...", Multiselect = false };
            opg.ShowDialog();
            soundFileBox.Text = opg.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opg = new OpenFileDialog() { Title = "Select your desired batch file to be executed...", Multiselect = false, Filter = "Batch Files *.bat | *.bat" };
            opg.ShowDialog();
            batchFileBox.Text = opg.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opg = new OpenFileDialog() { Title = "Select your desired process file to be started...", Multiselect = false, Filter = "Executable Files *.exe | *.exe" };
            opg.ShowDialog();
            processFileBox.Text = opg.FileName;
        }
    }

    public class ETask
    {
        private bool msgAlert, soundAlert, runProcess, execBatch;
        private string msgTitle="", msgText="",
            soundFile="", procFile="", procParams="", batchFile="";
        private string task_name, task_desc;
        private int taskID;
        private long execDate=0;
        private int execErrDay=-1;

        public bool MessageAlert { get { return msgAlert; } set { msgAlert = value; } }
        public bool SoundAlert { get { return soundAlert; } set { soundAlert = value; } }
        public bool RunProcess { get { return runProcess; } set { runProcess = value; } }
        public bool ExecuteBatch { get { return execBatch; } set { execBatch = value; } }

        public string MessageTitle { get { return msgTitle; } set { msgTitle = value; } }
        public string MessageText { get { return msgText; } set { msgText = value; } }
        public string SoundFile { get { return soundFile; } set { soundFile = value; } }
        public string ProcessFile { get { return procFile; } set { procFile = value; } }
        public string ProcessParameters { get { return procParams; } set { procParams = value; } }
        public string BatchFile { get { return batchFile; } set { batchFile = value; } }
        public string TaskName { get { return task_name; } set { task_name = value; } }
        public string TaskDescription { get { return task_desc; } set { task_desc = value; } }

        public DateTime ExecuteTime
        {
            get { return DateTime.FromBinary(execDate); }
            set { execDate = value.ToBinary(); }
        }

        public int ExecuteEveryDay { get { return execErrDay; } set { execErrDay = value; } }

        public int TaskID { get { return taskID; } }

        public bool Run()
        {
            if (MessageAlert)
                new Thread((x) =>
                {
                    KeyValuePair<string, string> ayy = (KeyValuePair<string, string>)x;
                    MessageBox.Show(ayy.Value, ayy.Key, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }).Start(new KeyValuePair<string, string>(msgTitle, msgText));
            if(SoundAlert)
            {
                WMPLib.WindowsMediaPlayerClass player = new WMPLib.WindowsMediaPlayerClass();
                player.URL = SoundFile;
                player.play();
            }
            if (RunProcess)
                Process.Start(ProcessFile, ProcessParameters, null, null);
            if (ExecuteBatch)
                Process.Start(batchFile);
            if (execErrDay == -1)
            {
                File.Delete("tasks\\" + TaskID.ToString("X") + ".task");
                return true;
            }
            return false;
        }

        public ETask(string tName, string tDesc, long date, int errDay, int id)
        {
            task_name = tName;
            task_desc = tDesc;
            execDate = date;
            execErrDay = errDay;
            taskID = id;
        }

        public byte[] ToArray()
        {
            MemoryStream memsr = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memsr);
            writer.Write(taskID);
            writer.Write(task_name);
            writer.Write(task_desc);
            writer.Write(execDate);
            writer.Write(execErrDay);
            writer.Write(msgAlert);
            writer.Write(soundAlert);
            writer.Write(runProcess);
            writer.Write(execBatch);
            writer.Write(msgTitle);
            writer.Write(msgText);
            writer.Write(soundFile);
            writer.Write(ProcessFile);
            writer.Write(procParams);
            writer.Write(batchFile);
            writer.Flush();
            return memsr.ToArray();
        }

        public static ETask Read(byte[] data)
        {
            MemoryStream memsr = new MemoryStream(data);
            BinaryReader reader = new BinaryReader(memsr);
            ETask task = new ETask(id: reader.ReadInt32(), tName: reader.ReadString(), tDesc: reader.ReadString(), date: reader.ReadInt64(), errDay: reader.ReadInt32())
            {
                MessageAlert = reader.ReadBoolean(),
                SoundAlert = reader.ReadBoolean(),
                RunProcess = reader.ReadBoolean(),
                ExecuteBatch = reader.ReadBoolean(),
                MessageTitle = reader.ReadString(),
                MessageText = reader.ReadString(),
                SoundFile = reader.ReadString(),
                ProcessFile = reader.ReadString(),
                ProcessParameters = reader.ReadString(),
                BatchFile = reader.ReadString()
            };
            return task;
        }
    }
}
