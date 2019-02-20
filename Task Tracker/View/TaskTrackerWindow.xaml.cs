using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Task_Tracker.ViewModel;

namespace Task_Tracker.View
{
    /// <summary>
    /// Interaction logic for TaskTrackerWindow.xaml
    /// </summary>
    public partial class TaskTrackerWindow : Window
    {
        WorkLogVM workLogVM;
        public TaskTrackerWindow()
        {
            InitializeComponent();

            workLogVM = new WorkLogVM();

            workLogVM.PropertyChanged += ViewModel_SelectedWorkLogChanged;
        }

        private void ViewModel_SelectedWorkLogChanged( object sender, EventArgs e )
        {
            taskLogTextBox.Document.Blocks.Clear();

            if ( workLogVM.SelectedWorkLog == null )
                return;

            Paragraph workLogText = new Paragraph();
            workLogText.Inlines.Add( workLogVM.SelectedWorkLog.WorkLogBody);
            taskLogTextBox.Document.Blocks.Add( workLogText );
        }
    }
}
