using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private TimeSpan loggedTime;
        private Stopwatch timeWorked;
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

        public TimeSpan LoggedTime
        {
            get { return loggedTime; }
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

        [Ignore]
        public TimeSpan TimeWorked
        {
            get { return loggedTime + timeWorked.Elapsed; }
        }

        public WorkLog()
        {
            startDate = DateTime.Now;
            timeWorked = new Stopwatch();
        }
    }
}
