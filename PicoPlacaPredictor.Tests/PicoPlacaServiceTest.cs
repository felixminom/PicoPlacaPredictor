using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicoPlacaPredictor.Services;
using PicoPlacaPredictor.Models;

namespace PicoPlacaPredictor.Tests
{
    [TestClass]
    public class PicoPlacaServicesTest
    {
        [TestMethod]
        public void DayofWeek_PicoPlacaWithValidDate_IsCorrect()
        {
            //we declare and instance a PicoPlacaServices object 
            var service = new PicoPlacaServices();
            //we declare and instance a PicoPlacaModel object 
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we just give a value to Date, cause in this case we're only testing that our DayofWeek function is working properly.
            //cause 2020 is a leap-year we test with february 29. It should return a 6S cause its saturday
            picoPlaca.Date = "2020/02/29";

            int expected = 6;

            int result = service.DayOfWeek(picoPlaca.Date);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void VerifyHour_PicoPlacaHourTrue_IsTrue()
        { 
            //we declare and instance a PicoPlacaServices object 
            var service = new PicoPlacaServices();
            //we declare and instance a PicoPlacaModel object 
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set an hour that its into the pico y placa hours
            //we test on the limit
            picoPlaca.Time = "9:30";

            bool expected = true;

            bool result = service.VerifyHour(picoPlaca.Time);

            Assert.AreEqual(expected, result);

        }

        //Opposite test that the last one
        [TestMethod]
        public void VerifyHour_PicoPlacaHourFalse_IsFalse()
        {
            //we declare and instance a PicoPlacaServices object 
            var service = new PicoPlacaServices();
            //we declare and instance a PicoPlacaModel object 
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set an hour that its not into the pico y placa hours
            //we test on the limit
            picoPlaca.Time = "19:31";

            bool expected = false;

            bool result = service.VerifyHour(picoPlaca.Time);

            Assert.AreEqual(expected, result);

        }
    }
}
