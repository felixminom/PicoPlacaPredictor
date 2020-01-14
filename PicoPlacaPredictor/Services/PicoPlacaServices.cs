using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PicoPlacaPredictor.Models;

namespace PicoPlacaPredictor.Services
{
    public class PicoPlacaServices
    {
        public PicoPlacaResponseModel CanRoad(PicoPlacaModel picoPlacaAux)
        {
            PicoPlacaResponseModel response = new PicoPlacaResponseModel();

            if(DayOfWeek(picoPlacaAux.Date)==0 || DayOfWeek(picoPlacaAux.Date) == 6)
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
    }
}