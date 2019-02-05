using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Task_Tracker.Model;

namespace Task_Tracker.ViewModel
{
    public static class DatabaseHelperClass
    {
        public static readonly string dbfile = Path.Combine( Environment.CurrentDirectory, "currentWorkLogs.sqlite" );

        public static bool InsertRecord<T>(T worklog)
        {
            bool result = false;

            using ( SQLiteConnection sQLiteConnection = new SQLiteConnection( dbfile ) )
            {
                sQLiteConnection.CreateTable<T>();
                int numberOfRows = sQLiteConnection.Insert( worklog );

                if ( numberOfRows > 0 )
                    result = true;
            }

            return result;
        }

        public static bool UpdateRecord<T>(T worklog)
        {
            bool result = false;

            using ( SQLiteConnection sQLiteConnection = new SQLiteConnection( dbfile ) )
            {
                sQLiteConnection.CreateTable<T>();
                int numberOfRows = sQLiteConnection.Update( worklog );

                if ( numberOfRows > 0 )
                    result = true;
            }

            return result;
        }

        public static bool DeleteRecord<T>(T worklog)
        {
            bool result = false;

            using ( SQLiteConnection sQLiteConnection = new SQLiteConnection( dbfile ) )
            {
                sQLiteConnection.CreateTable<T>();
                int numberOfRows = sQLiteConnection.Delete( worklog );

                if ( numberOfRows > 0 )
                    result = true;
            }

            return result;
        }
    }
}
