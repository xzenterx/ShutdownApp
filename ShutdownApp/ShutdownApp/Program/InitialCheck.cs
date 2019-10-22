using Microsoft.Win32.TaskScheduler;

namespace ShutdownApp.Program
{
    public class InitialCheck
    {
        public int Hour { get; private set; }
        public int Minutes { get; private set; }

        public int Seconds { get; private set; }


        public bool CheckRunShutdown()
        {
            if (GetRunShutdown() != null)
            {
                GetNextRunTime();
                return true;
            }
            else
            {
                return false;
            }
        }

        private Task GetRunShutdown()
        {
            using (TaskService taskService = new TaskService())
            {
                var tasks = taskService.RootFolder.GetTasks();

                foreach (var task in tasks)
                {
                    if (task.Name == "ShutdownTask")
                    {
                        return task;
                    }
                }

                return null;
            }
        }

        private void GetNextRunTime()
        {
            var task = GetRunShutdown();

            if (task != null)
            {
                Hour = task.NextRunTime.Hour;
                Minutes = task.NextRunTime.Minute;
                Seconds = task.NextRunTime.Second;
            }
        }
    }
}
