using CarRepair_CommonCL.Models;
using CarRepair_query_Client.Provider;
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


namespace CarRepair_query_Client
{

    public partial class CarWindow : Window
    {
        private readonly CarRecord _carRecord;
        public CarWindow(CarRecord record)
        {
            InitializeComponent();

            if (record != null)
            {
                _carRecord = record;

                ProblemTextBox.Content = _carRecord.Problem_desc;
                LPTextBox.Content = _carRecord.Car_lpn;
                StatusTextBox.Content = _carRecord.Repair_status;
                DateTextBox.Content = _carRecord.AcceptDate.ToString();
            }
            else 
            {
                _carRecord = new CarRecord();
            }
        }

        private string StatusSelector(string prevStatus)
        {
            if (prevStatus.Equals("Accepted"))
            {
                return "Ongoing";
            }
            else if (prevStatus.Equals("Ongoing"))
            {
                return "Completed";
            }
            else
            {
                return "Accepted";
            }
        }
        public void CycleStatusEvent(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Status switched");

            _carRecord.Repair_status = StatusSelector(_carRecord.Repair_status);
            CarRecordProvider.UpdateRecord(_carRecord);

            DialogResult = true;
            Close();
            
        }
        


    }
}
