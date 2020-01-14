using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicoPlacaPredictor.Services;
using PicoPlacaPredictor.Models;

namespace PicoPlacaPredictor.Tests
{
    [TestClass]
    public class PicoPlacaServicesTest
    {
        //Verify that a date its converte to a dayweek(int) properly
        [TestMethod]
        public void DayofWeek_PicoPlacaWithValidDate_IsCorrect()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we just give a value to Date.
            //cause 2020 is a leap-year we test with february 29. It should return a 6 cause its saturday
            picoPlaca.Date = "2020/02/29";

            int expected = 6;

            int result = service.DayOfWeek(picoPlaca.Date);

            Assert.AreEqual(expected, result);

        }

        //Verify that Pico y placa hour is active 
        [TestMethod]
        public void VerifyHour_PicoPlacaHourTrue_IsTrue()
        { 
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set an hour that its into the pico y placa hours
            //we test on the limit
            picoPlaca.Time = "9:30";

            bool expected = true;

            bool result = service.VerifyHour(picoPlaca.Time);

            Assert.AreEqual(expected, result);

        }

        //Verify that Pico y placa hour is active 
        [TestMethod]
        public void VerifyHour_PicoPlacaHourFalse_IsFalse()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set an hour that its not into the pico y placa hours
            //we test on the limit
            picoPlaca.Time = "19:31";

            bool expected = false;

            bool result = service.VerifyHour(picoPlaca.Time);

            Assert.AreEqual(expected, result);
        }


        //Verify that the plate number its converted to day properly
        [TestMethod]
        public void PlateNumberToDay_PicoPlacaPlateWednesday_IsWednesday()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set a plate that has pico y placa on Wednesday
            picoPlaca.PlateNumber = 3215;

            int expected = 3;

            int result = service.PlateNumberToDay(picoPlaca.PlateNumber);

            Assert.AreEqual(expected, result);
        }

        //Verify that the last digit it's calculated properly
        [TestMethod]
        public void LastPlateDigit_PicoPlacaPlateEndingFive_IsFive()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //Set the plate number, should a 5 as last digit
            picoPlaca.PlateNumber = 3215;

            int expected = 5;

            int result = service.LastPlateDigit(picoPlaca.PlateNumber);

            Assert.AreEqual(expected, result);

        }

    }
}
