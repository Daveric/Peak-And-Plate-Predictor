using System;

namespace PicoYPlaca
{
  class Program
  {
    private static CoreFunctions _coreFunctions;
    private static void Main(string[] args)
    {
      _coreFunctions = new CoreFunctions();
      Implementation();
    }

    private static void Implementation()
    {
      Console.WriteLine("PICO Y PLACA PREDICTOR");
      while (true)
      {
        Console.WriteLine(Constants.PlateInput);
        var plate = Console.ReadLine();
        var correctPlateInput = _coreFunctions.CheckPlateInput(plate, out var lastDigitPlate);
        //checking if plate string is correct according to regulations
        while (!correctPlateInput || lastDigitPlate == -1)
        {
          Console.WriteLine(Constants.InvalidInput + " " + Constants.PlateInput);
          plate = Console.ReadLine();
          correctPlateInput = _coreFunctions.CheckPlateInput(plate, out lastDigitPlate);
        }
        
        Console.WriteLine(Constants.Input + "date:");
        var date = Console.ReadLine();
        var correctDateInput = DateTime.TryParse(date, out var currentDate);
        //checking if the date has a correct input
        while (!correctDateInput)
        {
          Console.WriteLine(Constants.InvalidInput + " " + Constants.Input + "date:");
          date = Console.ReadLine();
          correctDateInput = DateTime.TryParse(date, out currentDate);
        }

        Console.WriteLine(Constants.Input + "time:");
        var time = Console.ReadLine();
        var correctTimeInput = DateTime.TryParse(time, out var currentTime);
        //checking if the date has a correct input
        while (!correctTimeInput)
        {
          Console.WriteLine(Constants.InvalidInput + " " + Constants.Input + "time:");
          time = Console.ReadLine();
          correctTimeInput = DateTime.TryParse(time, out currentTime);
        }
        
        //checking the plate, date and time to return the result
        Console.WriteLine("");
        var result = _coreFunctions.CheckPlateOnRoad(lastDigitPlate, currentDate, currentTime);
        Console.WriteLine(result);
        Console.WriteLine("");

        //checking the key input to continue with another plate or exit the program
        Console.WriteLine(Constants.CheckNextPlate);
        if (Console.ReadKey().Key != ConsoleKey.Enter)
        {
          Environment.Exit(0);
        }
      }
    }
  }
}
