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

        //Verify that Pico y placa hour is inactive 
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
        //When we test all days we verify that LastPlateDigit() function is working properly in all cases

        [TestMethod]
        public void PlateNumberToDay_PicoPlacaPlateMonday_IsMonday()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set a plate that has pico y placa on Wednesday
            picoPlaca.PlateNumber = 3211;

            int expected = 1;

            int result = service.PlateNumberToDay(picoPlaca.PlateNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlateNumberToDay_PicoPlacaPlateTuesday_IsTuesday()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set a plate that has pico y placa on Wednesday
            picoPlaca.PlateNumber = 3213;

            int expected = 2;

            int result = service.PlateNumberToDay(picoPlaca.PlateNumber);

            Assert.AreEqual(expected, result);
        }

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

        [TestMethod]
        public void PlateNumberToDay_PicoPlacaPlateThursday_IsThursday()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set a plate that has pico y placa on Wednesday
            picoPlaca.PlateNumber = 3218;

            int expected = 4;

            int result = service.PlateNumberToDay(picoPlaca.PlateNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlateNumberToDay_PicoPlacaPlateFriday_IsFriday()
        {
            var service = new PicoPlacaServices();
            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            //we set a plate that has pico y placa on Wednesday
            picoPlaca.PlateNumber = 3210;

            int expected = 5;

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

        //Verify that the response it's true when passed true
        [TestMethod]
        public void GetResponse_True_IsTrue()
        {
            var service = new PicoPlacaServices();
            PicoPlacaResponseModel expected = new PicoPlacaResponseModel();
            expected.CanRoad = true;

            PicoPlacaResponseModel result = service.GetResponse(true);
        
            Assert.AreEqual(expected.CanRoad,result.CanRoad);
        }

        //Verify that the response it's false when passed false
        [TestMethod]
        public void GetResponse_False_IsFalse()
        {
            var service = new PicoPlacaServices();
            PicoPlacaResponseModel expected = new PicoPlacaResponseModel();
            expected.CanRoad = false;

            PicoPlacaResponseModel result = service.GetResponse(false);

            Assert.AreEqual(expected.CanRoad, result.CanRoad);
        }

        //FINALLY we test CanRoad() function 
        [TestMethod]
        public void CanRoad_PicoPlacaFalse_IsFalse()
        {
            var service = new PicoPlacaServices();

            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            picoPlaca.PlateNumber = 1233;
            picoPlaca.Date = "2020/01/14";
            picoPlaca.Time = "8:20";

            PicoPlacaResponseModel expected = new PicoPlacaResponseModel();
            expected.CanRoad = false;

            PicoPlacaResponseModel response = service.CanRoad(picoPlaca);

            Assert.AreEqual(expected.CanRoad, response.CanRoad);
            
        }

        [TestMethod]
        public void CanRoad_PicoPlacaTrue_IsTrue()
        {
            var service = new PicoPlacaServices();

            PicoPlacaModel picoPlaca = new PicoPlacaModel();
            picoPlaca.PlateNumber = 1233;
            picoPlaca.Date = "2020/01/14";
            picoPlaca.Time = "10:20";

            PicoPlacaResponseModel expected = new PicoPlacaResponseModel();
            expected.CanRoad = true;

            PicoPlacaResponseModel response = service.CanRoad(picoPlaca);

            Assert.AreEqual(expected.CanRoad, response.CanRoad);

        }

    }
}
