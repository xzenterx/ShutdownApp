using Microsoft.Win32.TaskScheduler;
using System;
using System.Linq;

namespace ShutdownApp.Program
{
    public class InitialCheck
    {
        public TimeSpan Time { get; set; }


        public bool CheckRunShutdown()
        {
            return (GetRunShutdown() != null);
        }

        public void GetNextRunTime()
        {
            var task = GetRunShutdown();

            if (task != null)
            {
                Time = new TimeSpan(task.NextRunTime.Ticks);
            }
        }

        private Task GetRunShutdown()
        {
            using (TaskService taskService = new TaskService())
            {
                var tasks = taskService.RootFolder.GetTasks();
                return tasks.FirstOrDefault(t => t.Name.Equals("ShutdownTask"));
            }
        }
     
    }
}
