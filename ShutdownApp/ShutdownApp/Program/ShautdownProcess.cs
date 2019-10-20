using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ShutdownApp.Program
{
    public class ShautdownProcess
    {
        private int _seconds;

        private void SetTime(int minutes)
        {
            int seconds = minutes * 60;
            _seconds = seconds;
        }

        public void SetShutdownCmd(int minutes)
        {
            SetTime(minutes);
            ProcessStartInfo processShutdown = new ProcessStartInfo("cmd", $"/c shutdown -s -t {_seconds}" );
            Process.Start(processShutdown);
        }

        public void CancelShutdownCmd()
        {
            ProcessStartInfo processShutdown = new ProcessStartInfo("cmd", $"/c shutdown -a");
            Process.Start(processShutdown);
        }

        public void SetShutdownTaskSheduler(int minutes)
        {
            SetTime(minutes);
            using (TaskService taskService = new TaskService())
            {
                TaskDefinition taskDefinition = taskService.NewTask();
                taskDefinition.RegistrationInfo.Description = "Shutdown";
                taskDefinition.Triggers.Add(new TimeTrigger(DateTime.Now.AddSeconds(_seconds)));
                taskDefinition.Actions.Add(new ExecAction("cmd.exe", @"/c shutdown -s -t 000"));

                taskService.RootFolder.RegisterTaskDefinition(@"ShutdownTask", taskDefinition);
            }
        }

        public void CancelShutdownTaskSheduler()
        {
            using (TaskService taskService = new TaskService())
            {
                taskService.RootFolder.DeleteTask("ShutdownTask");
            }
        }

    }
}
