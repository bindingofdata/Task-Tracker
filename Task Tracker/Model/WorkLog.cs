using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Task_Tracker.Model
{
    public class WorkLog : INotifyPropertyChanged
    {
        private int logID;
        private string parentTaskLink;
        private DateTime startDate;
        private TimeSpan loggedTime;
        private Stopwatch timer;
        private string workLogBody;

        [PrimaryKey, AutoIncrement]
        public int LogID
        {
            get { return logID; }
            set { logID = value; }
        }

        public string ParentTaskLink
        {
            get { return parentTaskLink; }
            set { parentTaskLink = value; }
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

        public bool IsTimerActive
        {
            get { return timer.IsRunning; }
        }

        [Ignore]
        public Stopwatch Timer
        {
            get { return timer; }
        }

        [Ignore]
        public TimeSpan TimeWorked
        {
            get { return loggedTime + timer.Elapsed; }
        }

        public WorkLog()
        {
            startDate = DateTime.Now;
            timer = new Stopwatch();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        public override string ToString()
        {
            return $"Task ID: {logID}";
        }
    }
}
