using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicoYPlaca;
using System;

namespace TestPicoYPlaca.UnitTests
{
  [TestClass]
  public class ProgramTests
  {
    [TestMethod]
    public void CheckPlateOnRoad_LastDigitIs2_DateIsMonday_TimeIsInRange_ReturnsCannotBeOnRoad()
    {
      var date = DateTime.Parse("06/29/2020");
      var time = DateTime.Parse("7:00");
      var program = new CoreFunctions();
      var result = program.CheckPlateOnRoad(2, date, time);
      Assert.AreEqual(Constants.CannotBeOnRoad, result);
    }

    [TestMethod]
    public void CheckPlateOnRoad_LastDigitIs5_DateIsFriday_TimeIsNoon_ReturnsCanBeOnRoad()
    {
      var date = DateTime.Parse("06/19/2020");
      var time = DateTime.Parse("12:00");
      var program = new CoreFunctions();
      var result = program.CheckPlateOnRoad(5, date, time);
      Assert.AreEqual(Constants.CanBeOnRoad, result);
    }

    [TestMethod]
    public void CheckPlateOnRoad_LastDigitIs9_DateIsFriday_TimeIsInRange_ReturnsCannotBeOnRoad()
    {
      var date = DateTime.Parse("06/19/2020");
      var time = DateTime.Parse("18:00");
      var program = new CoreFunctions();
      var result = program.CheckPlateOnRoad(9, date, time);
      Assert.AreEqual(Constants.CannotBeOnRoad, result);
    }

    [TestMethod]
    public void CheckPlateOnRoad_LastDigitIs3_DateIsTuesday_TimeIsInRange_ReturnsCannotBeOnRoad()
    {
      var date = DateTime.Parse("06/30/2020");
      var time = DateTime.Parse("19:30");
      var program = new CoreFunctions();
      var result = program.CheckPlateOnRoad(3, date, time);
      Assert.AreEqual(Constants.CannotBeOnRoad, result);
    }

    [TestMethod]
    public void CheckPlateOnRoad_LastDigitIs9_DateIsSunday_TimeIsInRange_ReturnsCanBeOnRoad()
    {
      var date = DateTime.Parse("06/21/2020");
      var time = DateTime.Parse("19:30");
      var program = new CoreFunctions();
      var result = program.CheckPlateOnRoad(9, date, time);
      Assert.AreEqual(Constants.CanBeOnRoad, result);
    }

    [TestMethod]
    public void TimeBetween_DateTimeIsInRange_StartIsEnd_EndIsStart_ReturnsFalse()
    {
      var time = DateTime.Parse("18:00");
      var program = new CoreFunctions();
      var result = program.TimeBetween(time, Constants.AfternoonTimeRange[1], Constants.AfternoonTimeRange[0]);
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void TimeBetween_DateTimeIsInRange_Start_End_ReturnsTrue()
    {
      var time = DateTime.Parse("8:00");
      var program = new CoreFunctions();
      var result = program.TimeBetween(time, Constants.MorningTimeRange[0], Constants.MorningTimeRange[1]);
      Assert.IsTrue(result);
    }
  }
}