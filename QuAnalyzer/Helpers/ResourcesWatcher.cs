using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace QuAnalyzer.Helpers
{
    public class ResourcesWatcher : NotifierHelper
    {
        //private static Process currentProcess = Process.GetCurrentProcess();
        PerformanceCounter cpuCounter;
        PerformanceCounter memoryCounter;
        PerformanceCounter threadsCounter;

        public ResourcesWatcher()
        {
            string processName;
     
            using (var p = Process.GetCurrentProcess())
            {
                processName = p.ProcessName;
            }

            memoryCounter = new PerformanceCounter("Process", "Working Set - Private", processName, true);
            threadsCounter = new PerformanceCounter("Process", "Thread Count", processName, true);
            cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName, true);

            var timer = new DispatcherTimer(TimeSpan.FromSeconds(1.0), DispatcherPriority.Normal, ResourcesR_Tick, App.Current.Dispatcher);
            timer.Start();
        }

        void ResourcesR_Tick(object sender, EventArgs e)
        {
            //currentProcess.Refresh();
            NotifyPropertyChanged("MemoryUseFormatted");
            NotifyPropertyChanged("CPUUsage");
            NotifyPropertyChanged("ThreadsCount");
            //MemoryUse = currentProcess.WorkingSet64;
        }

        /*private long _memoryUse;
        public long MemoryUse
        {
            get { return _memoryUse; }
            set { _memoryUse = value; NotifyPropertyChanged("MemoryUse"); NotifyPropertyChanged("MemoryUseFormatted"); }
        }*/

        public string MemoryUseFormatted
        {
            get { return (int)(memoryCounter.NextValue() / 1024 / 1024) + "MB"; }
        }

        public int ThreadsCount
        {
            get { return (int)threadsCounter.NextValue(); }
        }

        public int CPUUsage
        {
            get { return (int)cpuCounter.NextValue(); }
        }

    }
}
