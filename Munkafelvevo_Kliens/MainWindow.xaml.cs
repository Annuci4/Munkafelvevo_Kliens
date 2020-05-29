using Munkafelvevo_Kliens.DataProviders;
using Munkafelvevo_Kliens.Models;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Munkafelvevo_Kliens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IList<Work> _works;

        public MainWindow()
        {
            InitializeComponent();

            UpdateWorks();
        }

        private void AddWorkButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new WorkWindow(null);
            if (window.ShowDialog() ?? false)
            {
                UpdateWorks();
            }
        }

        private void WorksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWork = WorksListBox.SelectedItem as Work;

            if (selectedWork != null)
            {
                var window = new WorkWindow(selectedWork);
                if (window.ShowDialog() ?? false)
                {
                    UpdateWorks();
                }

                WorksListBox.UnselectAll();
            }
        }

        private void UpdateWorks()
        {
            _works = WorkDataProvider.GetWorks();
            WorksListBox.ItemsSource = _works; //Elérjük, hogy a listbox forrása ez a _works kollekció legyen
        }
    }
}
