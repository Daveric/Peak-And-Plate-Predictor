using System;
using System.Collections.Generic;

namespace PicoYPlaca
{
  public class Constants
  {
    #region Strings
    public const string PlateInput = "Please type the full plate number:";
    public const string InvalidInput = "Invalid input!";
    public const string Input = "Please type the ";
    public const string CanBeOnRoad = "ALLOW. The car can be on the road";
    public const string CannotBeOnRoad = "DENY. The car cannot be on the road";
    public const string CheckNextPlate = "Press enter to check the next plate or any other Key to exit the program";
    #endregion

    //dict of last digits plate that can be on the road per day
    public static readonly Dictionary<string, List<int>> PlatesPerDay = new Dictionary<string, List<int>>
    {
      {"Monday", new List<int>() {1, 2}},
      {"Tuesday", new List<int>() {3, 4}},
      {"Wednesday", new List<int>() {5, 6}},
      {"Thursday", new List<int>() {7, 8}},
      {"Friday", new List<int>() {9, 0}}
    };

    public static readonly List<TimeSpan> MorningTimeRange = new List<TimeSpan>()
    {
      TimeSpan.Parse("07:00"),
      TimeSpan.Parse("09:30")
    };
    public static readonly List<TimeSpan> AfternoonTimeRange = new List<TimeSpan>()
    {
      TimeSpan.Parse("16:00"),
      TimeSpan.Parse("19:30")
    };
  }
}
