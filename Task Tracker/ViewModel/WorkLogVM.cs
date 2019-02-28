using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

using SQLite;
using Task_Tracker.ViewModel.Commands;
using Task_Tracker.Model;
using System.ComponentModel;

namespace Task_Tracker.ViewModel
{
    internal class WorkLogVM : INotifyPropertyChanged
    {
        public ObservableCollection<WorkLog> WorkLogs { get; set; }
        public NewWorkLogCommand NewWorkLogCommand { get; set; }
        public DeleteWorkLogCommand DeleteWorkLogCommand { get; set; }
        public SubmitWorkLogCommand SubmitWorkLogCommand { get; set; }
        public HasEditedWorkLogCommand HasEditedWorkLogCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private WorkLog selectedWorkLog;

        public WorkLog SelectedWorkLog
        {
            get { return selectedWorkLog; }
            set
            {
                DatabaseHelperClass.UpdateRecord(SelectedWorkLog);
                selectedWorkLog = value;
                OnPropertyChanged("SelectedWorklog");
            }
        }

        public WorkLogVM()
        {
            WorkLogs = new ObservableCollection<WorkLog>();
            NewWorkLogCommand = new NewWorkLogCommand( this );
            DeleteWorkLogCommand = new DeleteWorkLogCommand( this );
            SubmitWorkLogCommand = new SubmitWorkLogCommand( this );
            HasEditedWorkLogCommand = new HasEditedWorkLogCommand( this );
            LoadWorkLogs();
            if ( WorkLogs.Count > 0 )
                SelectedWorkLog = WorkLogs[0];
        }

        public void NewWorkLog()
        {
            WorkLog newLog = new WorkLog();

            DatabaseHelperClass.InsertRecord( newLog );
            WorkLogs.Add( newLog );
            SelectedWorkLog = newLog;
        }

        public void UpdateWorkLog(WorkLog workLog)
        {
            DatabaseHelperClass.UpdateRecord(workLog);
        }

        public void DeleteWorkLog(WorkLog workLog)
        {
            WorkLogs.Remove( workLog );
            DatabaseHelperClass.DeleteRecord( workLog );

            if ( WorkLogs.Count > 0 )
                SelectedWorkLog = WorkLogs[WorkLogs.Count - 1];
            else
                SelectedWorkLog = null;
        }

        public void LoadWorkLogs()
        {
            using ( SQLiteConnection sQLiteConnection = new SQLiteConnection( DatabaseHelperClass.dbfile ) )
            {
                sQLiteConnection.CreateTable<WorkLog>();

                foreach ( WorkLog log in sQLiteConnection.Table<WorkLog>().ToList() )
                    WorkLogs.Add( log );
            }
        }

        public void SubmitWorkLog()
        {
            throw new NotImplementedException();
        }

        private void OnPropertyChanged ( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
