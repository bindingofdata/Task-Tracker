using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Task_Tracker.Model
{
    public class WorkLog
    {
        private int logID;
        private int parentTaskID;
        private DateTime startDate;
        private TimeSpan timeWorked;
        private string workLogBody;
        private WorkStates currentState;

        [PrimaryKey, AutoIncrement]
        public int LogID
        {
            get { return logID; }
            set { logID = value; }
        }

        [Indexed]
        public int ParentTaskID
        {
            get { return parentTaskID; }
            set { parentTaskID = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public TimeSpan TimeWorked
        {
            get { return timeWorked; }
            set { timeWorked = value; }
        }

        public string WorkLogBody
        {
            get { return workLogBody; }
            set { workLogBody = value; }
        }

        public WorkStates CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
    }
}
