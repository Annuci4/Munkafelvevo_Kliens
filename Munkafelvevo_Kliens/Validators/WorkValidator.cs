using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Munkafelvevo_Kliens.Models;

namespace Munkafelvevo_Kliens.Validators
{
    public static class WorkValidation
    {
        public static string Validator(string FirstName, string LastName, string TypeOfCar, string LicencePlateNumber, string Issues)
        {
            Regex rx = new Regex("^[A-Z]{3}-[0-9]{3}$");

            if (string.IsNullOrEmpty(FirstName))
            {
                //MessageBox.Show("First name should not be empty.");
                return "EmptyFirstName";
            }
            if (string.IsNullOrEmpty(LastName))
            {
                //MessageBox.Show("Last name should not be empty.");
                return "EmptyLastName";
            }
            if (string.IsNullOrEmpty(TypeOfCar))
            {
                //MessageBox.Show("Type of car should not be empty.");
                return "EmptyTypeOfCar";
            }
            if (string.IsNullOrEmpty(LicencePlateNumber))
            {
                // MessageBox.Show("Licence plate number should not be empty.");
                return "EmptyLicencePlateNumber";
            }
            if (!rx.IsMatch(LicencePlateNumber))
            {
                //MessageBox.Show("Licence plate number is invalid.");
                return "InvalidLicencePlateNumber";
            }
            if (string.IsNullOrEmpty(Issues))
            {
                //MessageBox.Show("Issues should not be empty.");
                return "EmptyIssues";
            }

            return "true";
        }
    }
}
