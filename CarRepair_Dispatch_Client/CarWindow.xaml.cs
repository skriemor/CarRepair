using CarRepair_CommonCL.Models;
using CarRepair_CommonCL;
using CarRepair_Dispatch_Client.Provider;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CarRepair_Dispatch_Client
{

    public partial class CarWindow : Window
    {
        private Validifier validifier = new Validifier();
        private readonly CarRecord _carRecord;
        public CarWindow(CarRecord record)
        {
            InitializeComponent();

            if (record != null)
            {
                _carRecord = record;

                ProblemTextBox.Text = _carRecord.Problem_desc;
                LPTextBox.Text = _carRecord.Car_lpn;
                NameTextBox.Text = _carRecord.Name;
                CarTypeTextBox.Text = _carRecord.Car_type;

                AddCarButton.Visibility = Visibility.Hidden;
                UpdateCarButton.Visibility = Visibility.Visible;
                DeleteCarButton.Visibility = Visibility.Visible;
            }
            else 
            {
                _carRecord = new CarRecord();

                AddCarButton.Visibility = Visibility.Visible;
                UpdateCarButton.Visibility = Visibility.Hidden;
                DeleteCarButton.Visibility = Visibility.Hidden;
            }
        }

        public void AddRepairEvent(object sender, RoutedEventArgs e)
        {
            var message = validifier.RecordValid(NameTextBox.Text, CarTypeTextBox.Text, LPTextBox.Text, ProblemTextBox.Text);
            if (message.Equals("Success"))
            {
                _carRecord.Name = NameTextBox.Text;
                _carRecord.Car_lpn = LPTextBox.Text;
                _carRecord.Problem_desc = ProblemTextBox.Text;
                _carRecord.Car_type = CarTypeTextBox.Text;
                _carRecord.Repair_status = "Accepted";
                _carRecord.AcceptDate = DateTime.Now;


                CarRecordProvider.CreateRecord(_carRecord);

                DialogResult = true;
                Close();
            }
            MessageBox.Show(message);
        }

        public void ModifyRepairEvent(object sender, RoutedEventArgs e)
        {
            var message = validifier.RecordValid(NameTextBox.Text, CarTypeTextBox.Text, LPTextBox.Text, ProblemTextBox.Text);

            if (message.Equals("Success"))
            {
                _carRecord.Name = NameTextBox.Text;
                _carRecord.Car_lpn = LPTextBox.Text;
                _carRecord.Problem_desc = ProblemTextBox.Text;
                _carRecord.Car_type = CarTypeTextBox.Text;
                //_carRecord.AcceptDate = DateTime.Now;

                CarRecordProvider.UpdateRecord(_carRecord);

                DialogResult = true;
                Close();
            }
            MessageBox.Show(message);
        }
        public void DeleteRepairEvent(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirm delete", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CarRecordProvider.DeleteRecord(_carRecord.id);

                DialogResult = true;
                Close();
            }
        }

        /*public bool RecordValid()
        {
            var licensePlateFormat = new Regex("^[A-Z]{3}-[0-9]{3}$");
            var nameFormat = new Regex("^[A-Z][a-z]* [A-Z][a-z]*( [A-Z][a-z]*)*$");
            var carTypeFormat = new Regex("^[A-Z][A-Za-z0-9]*$");

            if (string.IsNullOrEmpty(NameTextBox.Text) || !nameFormat.IsMatch(NameTextBox.Text))
            {
                MessageBox.Show("Owner's name is invalid.");
                return false;
            }
            if (string.IsNullOrEmpty(CarTypeTextBox.Text) || !carTypeFormat.IsMatch(CarTypeTextBox.Text))
            {
                MessageBox.Show("Invalid car type");
                return false;
            }
            if (string.IsNullOrEmpty(LPTextBox.Text) || !licensePlateFormat.IsMatch(LPTextBox.Text))
            {
                MessageBox.Show("License Plate Number is invalid, format example: <ABC-123>");
                return false;
            }
            if (string.IsNullOrEmpty(ProblemTextBox.Text))
            {
                MessageBox.Show("Problem description can not be empty");
                return false;
            }
            return true;
        }
        */

    }
}
