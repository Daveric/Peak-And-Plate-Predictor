using System;
using System.Globalization;
using System.Linq;

namespace PicoYPlaca
{
  public class CoreFunctions
  {
    public bool CheckPlateInput(string plate, out int lastDigitPlate)
    {
      lastDigitPlate = -1;
      if (string.IsNullOrEmpty(plate)) return false;
      var lastPlateCharIsInt = int.TryParse(plate.Substring(plate.Length - 1), out lastDigitPlate);
      var plateLength = 8 > plate.Length && plate.Length > 5;
      var countLetters = plate.Count(char.IsLetter);
      return lastPlateCharIsInt && plateLength && countLetters == 3;
    }

    public string CheckPlateOnRoad(int lastDigit, DateTime date, DateTime time)
    {
      //checking when a car cannot be on the road
      foreach (var item in Constants.PlatesPerDay)
      {
        var day = item.Key;
        var currentLastDigit = item.Value;
        if (date.ToString("dddd", new CultureInfo("en-EN")).Equals(day) && currentLastDigit.Contains(lastDigit) &&
            (TimeBetween(time, Constants.MorningTimeRange.First(), Constants.MorningTimeRange.Last()) ||
             TimeBetween(time, Constants.AfternoonTimeRange.First(), Constants.AfternoonTimeRange.Last())))
        {
          return Constants.CannotBeOnRoad;
        }
      }
      //for all other cases the car can be on the road
      return Constants.CanBeOnRoad;
    }

    public bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
    {
      var now = datetime.TimeOfDay;

      if (start < end)
        return start <= now && now <= end;
      return !(end < now && now < start);
    }
  }
}