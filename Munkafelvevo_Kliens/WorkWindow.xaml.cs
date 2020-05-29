using Munkafelvevo_Kliens.DataProviders;
using Munkafelvevo_Kliens.Models;
using Munkafelvevo_Kliens.Validators;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Munkafelvevo_Kliens
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private readonly Work _work;

        public WorkWindow(Work work)
        {
            InitializeComponent();

            //Ha már létező work-t akarunk update-elni vagy delete-elni, akkor át kell adni az infókat, hogy a felnyíló ablakba már be legyenek írva.
            if (work != null)
            {
                _work = work;

                FirstNameTextBox.Text = _work.FirstName;
                LastNameTextBox.Text = _work.LastName;
                TypeofcarTextBox.Text = _work.TypeOfCar;
                LicencePlateTextBox.Text = _work.CarLicencePlate;
                IssuesTextBox.Text = _work.Issues;
                StateOfWorkCombobox.Text = _work.StateOfWork;
                DateDatePicker.SelectedDate = _work.Date;

                CreateButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                _work = new Work();

                UpdateButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        //Ha kitöltötte a megfelelő adatokat, akkor a dataprovider meghívásra kerül, hogy a webservice-en tárolja el az adatokat!
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                _work.FirstName = FirstNameTextBox.Text;
                _work.LastName = LastNameTextBox.Text;
                _work.CarLicencePlate = LicencePlateTextBox.Text;
                _work.Issues = IssuesTextBox.Text;
                _work.TypeOfCar = TypeofcarTextBox.Text;
                _work.StateOfWork = StateOfWorkCombobox.Text;

                WorkDataProvider.CreateWork(_work);

                DialogResult = true;
                Close();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                _work.FirstName = FirstNameTextBox.Text;
                _work.LastName = LastNameTextBox.Text;
                _work.CarLicencePlate = LicencePlateTextBox.Text;
                _work.Issues = IssuesTextBox.Text;
                _work.TypeOfCar = TypeofcarTextBox.Text;
                _work.StateOfWork = StateOfWorkCombobox.Text;

                WorkDataProvider.UpdateWork(_work);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                WorkDataProvider.DeleteWork(_work.Id);

                DialogResult = true;
                Close();
            }
        }

        public bool Validate()
        {

            string asd = WorkValidation.Validator(FirstNameTextBox.Text, LastNameTextBox.Text, TypeofcarTextBox.Text, LicencePlateTextBox.Text, IssuesTextBox.Text);

            if (asd == "EmptyFirstName")
            {
                MessageBox.Show("First name should not be empty.");
                return false;
            }
            if (asd == "EmptyLastName")
            {
                MessageBox.Show("Last name should not be empty.");
                return false;
            }
            if (asd == "EmptyTypeOfCar")
            {
                MessageBox.Show("Type of car should not be empty.");
                return false;
            }
            if (asd == "EmptyLicencePlateNumber")
            {
                MessageBox.Show("Licence plate number should not be empty.");
                return false;
            }
            if (asd == "InvalidLicencePlateNumber")
            {
                MessageBox.Show("Licence plate number is invalid.");
                return false;
            }
            if (asd == "EmptyIssues")
            {
                MessageBox.Show("Issues should not be empty.");
                return false;
            }
            return true;
        }
    }
}
