using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Task_Tracker.Model;

namespace Task_Tracker.ViewModel.Commands
{
    class HasEditedWorkLogCommand : ICommand
    {
        public WorkLogVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public HasEditedWorkLogCommand(WorkLogVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.UpdateWorkLog(parameter as WorkLog);
        }
    }
}
