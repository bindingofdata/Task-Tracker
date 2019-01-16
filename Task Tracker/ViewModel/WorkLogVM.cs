using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

using SQLite;
using Task_Tracker.Model;

namespace Task_Tracker.ViewModel
{
    class WorkLogVM
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public ObservableCollection<WorkLog> WorkLogs { get; set; }
        private Task selectedTask;

        public WorkLogVM()
        {
            Tasks = new ObservableCollection<Task>();
            WorkLogs = new ObservableCollection<WorkLog>();
        }


    }
}
