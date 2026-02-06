#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using WindowsInput.Native;
using WindowsInput;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.EventLogger;
using FTOptix.WebUI;
#endregion

public class FooLogic : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void AltTab()
    {
        InputSimulator simulator = new InputSimulator();
        simulator.Keyboard.KeyDown(VirtualKeyCode.MENU);
        simulator.Keyboard.KeyPress(VirtualKeyCode.TAB);
        simulator.Keyboard.KeyUp(VirtualKeyCode.MENU);
        Log.Info("ALT+TAB Simulated");
    }

    [ExportMethod]
    public void AccessFile()
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        string path = Path.Combine(folder, "Temp", "someTextFile.txt");
        if (File.Exists(path))
        {
            Log.Info($"found file at: {path}");
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Log.Info(line);
                }
            }
        }
        else
        {
            Log.Info($"file does not exist: {path}");
        }
    }

    [ExportMethod]
    public void ProcessStart(string path)
    {
        Process.Start(path);
        Log.Info($"process started for path: {path}");
    }
}
