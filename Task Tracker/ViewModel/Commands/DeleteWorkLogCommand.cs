using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Task_Tracker.Model;

namespace Task_Tracker.ViewModel.Commands
{
    class DeleteWorkLogCommand : ICommand
    {
        public WorkLogVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public DeleteWorkLogCommand(WorkLogVM vm)
        {
            VM = vm;
        }

        public bool CanExecute ( object parameter )
        {
            return parameter is WorkLog SelectedWorkLog;
        }

        public void Execute ( object parameter )
        {
            VM.DeleteWorkLog( parameter as WorkLog );
        }
    }
}
