using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRepair_Dispatch_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepair_CommonCL;

namespace CarRepair_Dispatch_Client.Tests
{
    [TestClass()]
    public class CarWindowTests
    {
        [TestMethod()]
        public void RecordValidTest()
        {
            var validifier = new Validifier();
            Assert.AreEqual("Success",validifier.RecordValid("Antropo Morphius", "Tesla S", "EGY-111", "Felrobbant"));
            Assert.AreEqual("Invalid car type", validifier.RecordValid("Antropo Morphius", "Tesla##### S", "EGY-111", "Felrobbant"));
            Assert.AreEqual("License Plate Number is invalid, format example: <ABC-123>", validifier.RecordValid("Antropo Morphius", "Tesla S", "111-111", "Felrobbant"));
            Assert.AreEqual("Problem description can not be empty", validifier.RecordValid("Antropo Morphius", "Tesla S", "EGY-111", ""));
            Assert.AreEqual("Owner's name is invalid.", validifier.RecordValid("Antropo morphius", "Tesla S", "EGY-111", "Felrobbant"));
            Assert.AreEqual("Owner's name is invalid.", validifier.RecordValid("Antropo ", "Tesla S", "EGY-111", "Felrobbant"));
            Assert.AreEqual("Owner's name is invalid.", validifier.RecordValid("Antropo Mo rphius", "Tesla S", "EGY-111", "Felrobbant"));
            Assert.AreEqual("Success", validifier.RecordValid("Antropo Mo Rphius", "Tesla S", "EGY-111", "Felrobbant"));

        }
    }
}