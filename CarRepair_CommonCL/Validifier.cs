using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRepair_CommonCL
{
    public class Validifier
    {
        public Validifier()
        {

        }
        public string RecordValid(string nameText, string carTypeText, string lpText, string problemText)
        {
            var licensePlateFormat = new Regex("^[A-Z]{3}-[0-9]{3}$");
            var nameFormat = new Regex("^[A-Z][a-z]* [A-Z][a-z]*( [A-Z][a-z]*)*$");
            var carTypeFormat = new Regex("^[A-Z][A-Za-z0-9 ]*$");

            if (string.IsNullOrEmpty(nameText) || !nameFormat.IsMatch(nameText))
            {
                return "Owner's name is invalid.";
            }
            if (string.IsNullOrEmpty(carTypeText) || !carTypeFormat.IsMatch(carTypeText))
            {
                return "Invalid car type";
            }
            if (string.IsNullOrEmpty(lpText) || !licensePlateFormat.IsMatch(lpText))
            {
                return "License Plate Number is invalid, format example: <ABC-123>";
            }
            if (string.IsNullOrEmpty(problemText))
            {
                return "Problem description can not be empty";
            }
            return "Success";
        }
    }
}
