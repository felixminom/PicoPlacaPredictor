using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PicoPlacaPredictor.Models;

namespace PicoPlacaPredictor.Services
{
    public class PicoPlacaServices
    {
        string trueMessage = "Don't worry, you can road today";
        string falseMessage = "Sorry :(. You're going to take a bus";

        public PicoPlacaResponseModel CanRoad(PicoPlacaModel picoPlacaAux)
        {
            PicoPlacaResponseModel response = new PicoPlacaResponseModel();

            //We verify if the day is saturday or sunday, there's no pico y placa on weekends
            //6 it's saturday and 0 it's sunday
            if(DayOfWeek(picoPlacaAux.Date)==6 || DayOfWeek(picoPlacaAux.Date) == 0)
            {
                response.CanRoad = true;
                response.Message = trueMessage;
        
                return response;
            }
            else
            {

            }

            return response;
        }

        public int DayOfWeek(string dateAux)
        {
            string[] dateAsString = dateAux.Split('/');
            int year = Convert.ToInt32(dateAsString[0]);
            int month = Convert.ToInt32(dateAsString[1]);
            int day = Convert.ToInt32(dateAsString[2]);

            DateTime date = new DateTime(year, month, day);

            int dayAsInt = (int)date.DayOfWeek;

            return dayAsInt;

        }

        public bool VerifyHour(string hour)
        {
            //we separate the hour recivied as string into hours and minutes and convert into integers
            int hourAux = Convert.ToInt32(hour.Split(':')[0]);
            int minutesAux = Convert.ToInt32(hour.Split(':')[1]);

            //We validate the hours 

            if ((hourAux >= 7 && hourAux <= 9) || (hourAux >= 16 && hourAux <= 19))
            {
                switch (hourAux)
                {
                    case 9:
                        if (minutesAux <= 30)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case 19:
                        if (minutesAux <= 30)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public int PlateNumberToDay(int plateNumberAux)
        {
            //this function converts the plate number into a day of the week (from: monday to:friday)
            int lastDigit = PlateNumberToDay(plateNumberAux);

            switch (lastDigit)
            {
                case 1:
                    return 1;
                case 2:
                    return 1;
                case 3:
                    return 2;
                case 4:
                    return 2;
                case 5:
                    return 3;
                case 6:
                    return 3;
                case 7:
                    return 4;
                case 8:
                    return 4;
                case 9:
                    return 5;
                case 0:
                    return 5;
            }

            return 0;
        }

        public int LastPlateDigit(int plateNumberAux)
        {
            //this function extracts the last digit of the plate
            int thousands = plateNumberAux / 1000;
            int plateNumber3Digits = plateNumberAux - (thousands * 1000);
            int hundreds = plateNumber3Digits / 100;
            int plateNumber2Digits = plateNumber3Digits - (hundreds * 100);
            int tens = plateNumber2Digits / 10;

            return plateNumber2Digits - (tens * 10);
        }
    }
}