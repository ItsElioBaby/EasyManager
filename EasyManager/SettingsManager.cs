using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public enum SettingType : int
{
    Defrag_Disk = 0x1A,
    CleanUp_Disk = 0x2A,
    CheckUp_Disk = 0x3A,
    ScheduledTime_A = 0x1B,
    ScheduledTime_S = 0x2B,
    Defrag = 0x1C,
    CleanUp = 0x2C,
    CheckUp = 0x3C,
    ContingWindows = 0x4A,
    PackUsageReports = 0x4B,
    OptimizeProcesses = 0x4C,
    StartedPeriod = 0x5A,
    StartedPeriodS = 0x5B
}

public class SettingsFileWriter
{
    string file_d = "";
    BinaryWriter writer;
    MemoryStream memsr;

    public SettingsFileWriter(string destFile)
    {
        file_d = destFile;
        memsr = new MemoryStream();
        writer = new BinaryWriter(memsr);
    }

    public void WriteSetting(SettingType type, string val)
    {
        writer.Write((int)type);
        writer.Write(val);
        writer.Flush();
    }

    public void DropToFile()
    {
        File.WriteAllBytes(file_d, memsr.ToArray());
    }

    public void Clean()
    {
        memsr = new MemoryStream();
        writer = new BinaryWriter(memsr);
    }
}

public class SettingsFileReader
{
    public Dictionary<SettingType, string> Settings = new Dictionary<SettingType, string>();

    public SettingsFileReader(string destFile)
    {
        BinaryReader reader = new BinaryReader(File.OpenRead(destFile));
        Settings.Add(SettingType.CheckUp_Disk, "");
        Settings.Add(SettingType.CleanUp_Disk, "");
        Settings.Add(SettingType.Defrag_Disk, "");
        Settings.Add(SettingType.ScheduledTime_A, "");
        Settings.Add(SettingType.ScheduledTime_S, "");
        Settings.Add(SettingType.CheckUp, "");
        Settings.Add(SettingType.CleanUp, "");
        Settings.Add(SettingType.Defrag, "");
        Settings.Add(SettingType.ContingWindows, "");
        Settings.Add(SettingType.OptimizeProcesses, "");
        Settings.Add(SettingType.PackUsageReports, "");
        Settings.Add(SettingType.StartedPeriod, "");

        for (int i = 0; i < 12; i++)
        {
            SettingType st = (SettingType)reader.ReadInt32();
            string val = reader.ReadString();
            Settings[st] = val;
        }
        reader.Close();
    }

    public string GetSetting(SettingType setting)
    {
        return Settings[setting];
    }

    public void SetSetting(SettingType setting, string nVal)
    {
        Settings[setting] = nVal;
    }
}

public class SettingsFile
{
    SettingsFileReader reader;
    SettingsFileWriter writer;

    SettingsFile(string destFile)
    {
        reader = new SettingsFileReader(destFile);
        writer = new SettingsFileWriter(destFile);
    }

    public SettingsFileReader Reader { get { return reader; } }

    public void Update()
    {
        foreach (var v in reader.Settings)
        {
            writer.WriteSetting(v.Key, v.Value);
        }
        writer.DropToFile();
        writer.Clean();
    }

    private class Sample
    {
        public Dictionary<SettingType, string> Settings = new Dictionary<SettingType, string>();
        public Sample()
        {
            Settings.Add(SettingType.CheckUp_Disk, "0");
            Settings.Add(SettingType.CleanUp_Disk, "0");
            Settings.Add(SettingType.Defrag_Disk, "0");
            Settings.Add(SettingType.ScheduledTime_A, "1");
            Settings.Add(SettingType.ScheduledTime_S, "7");
            Settings.Add(SettingType.CheckUp, "True");
            Settings.Add(SettingType.CleanUp, "True");
            Settings.Add(SettingType.Defrag, "True");
            Settings.Add(SettingType.ContingWindows, "False");
            Settings.Add(SettingType.OptimizeProcesses, "True");
            Settings.Add(SettingType.PackUsageReports, "False");
            Settings.Add(SettingType.StartedPeriod, "");
        }
    }

    public static SettingsFile Create(string file)
    {
        SettingsFileWriter writer = new SettingsFileWriter(file);
        foreach (var v in (new Sample()).Settings)
        {
            writer.WriteSetting(v.Key, v.Value);
        }
        writer.DropToFile();
        return new SettingsFile(file);
    }

    public static SettingsFile Open(string file)
    {
        return new SettingsFile(file);
    }
}