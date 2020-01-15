# PicoPlacaPredictor
A tiny project that predicts if a car is whether or not able to be on the road, based on its plate number.

We don't control null fields, since it should be controlled in frontend. 

The json expected is the following one: 

{
	"PlateNumber" : 1233,
	"Date" : "2020/01/14",
	"Time" : "6:59"
}

The plate number could be a 3 or 4 digit plate.
Date should keep its format (yyyy/mm/dd) since is read as a string. 
Time is in 24 hours format so if you want to try evening hours, should be something like: 19:23.

The result expected is a json with the following format:
Positive answer

{
    "CanRoad": true,
    "Message": "Don't worry, you can be on the road today"
}

Negative answer

{
    "CanRoad": false,
    "Message": "Sorry :(. You're going to take a bus today"
}

Thank you for your time, I appreciate it. 
