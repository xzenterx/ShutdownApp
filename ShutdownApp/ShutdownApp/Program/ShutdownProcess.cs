using Microsoft.Win32.TaskScheduler;
using System;
using System.Diagnostics;

namespace ShutdownApp.Program
{
    public class ShutdownProcess
    {
        private TimeSpan _timeout;

        public void SetShutdownCmd(int minutes)
        {
            TimeSpan.FromMinutes(minutes);
            ProcessStartInfo processShutdown = new ProcessStartInfo("cmd", $"/c shutdown -s -t {_timeout.Seconds}" );
            Process.Start(processShutdown);
        }

        public void CancelShutdownCmd()
        {
            ProcessStartInfo processShutdown = new ProcessStartInfo("cmd", $"/c shutdown -a");
            Process.Start(processShutdown);
        }

        public void SetShutdownTaskSheduler(TimeSpan time)
        {
            _timeout = time;
            using (TaskService taskService = new TaskService())
            {
                TaskDefinition taskDefinition = taskService.NewTask();
                taskDefinition.RegistrationInfo.Description = "Shutdown";
                var triggerDateTime = DateTime.Now + _timeout;
                taskDefinition.Triggers.Add(new TimeTrigger(triggerDateTime));
                taskDefinition.Actions.Add(new ExecAction("cmd.exe", @"/c shutdown -s -t 60"));

                taskService.RootFolder.RegisterTaskDefinition(@"ShutdownTask", taskDefinition);
            }
        }

        public void CancelShutdownTaskSheduler()
        {
            using (TaskService taskService = new TaskService())
            {
                taskService.RootFolder.DeleteTask("ShutdownTask");
                CancelShutdownCmd();
            }
        }

    }
}
