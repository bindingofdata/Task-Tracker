﻿using System;
using System.Collections.Generic;
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

namespace Task_Tracker.View
{
    /// <summary>
    /// Interaction logic for TaskTrackerWindow.xaml
    /// </summary>
    public partial class TaskTrackerWindow : Window
    {
        public TaskTrackerWindow()
        {
            InitializeComponent();
        }

        private void ProjectSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
