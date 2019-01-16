using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;

namespace Task_Tracker.Model
{
    public class Task
    {
        private int taskID;
        private string taskName;
        private List<WorkLog> workLogs;
        private WorkStates currentState;

        [PrimaryKey, AutoIncrement]
        public int TaskID
        {
            get { return taskID; }
            set { taskID = value; }
        }

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }

        [Indexed]
        public List<WorkLog> WorkLogs
        {
            get { return workLogs; }
            set { workLogs = value; }
        }

        public WorkStates CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
    }
}
