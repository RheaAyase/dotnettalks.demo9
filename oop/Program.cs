using System;

namespace OpenHouse
{
	static class Program
	{
		static void Main(string[] args)
		{
			//Create a `plastic` `Bottle` and fill it with some water set by the user.
			Console.WriteLine("Creating a new Bottle object with Material = plastic.");
			Bottle plasticBottle = new Bottle("plastic");

			Console.WriteLine($"How much water is in it? (Capacity: {plasticBottle.Capacity}l)");
			float newVolume = float.Parse(Console.ReadLine());

			plasticBottle.Fill(newVolume);
			Console.WriteLine($"The {plasticBottle.Material} bottle now has {plasticBottle.Volume} liter(s) of water.");


			//Create a `glass` `Bottle` and fill it with some water set by the user.
			Console.WriteLine("Creating a new Bottle object with Material = glass.");
			Bottle glassBottle = new Bottle("glass");

			Console.WriteLine($"How much water is in it? (Capacity: {glassBottle.Capacity}l)");
			newVolume = float.Parse(Console.ReadLine());

			glassBottle.Fill(newVolume);
			Console.WriteLine($"The {glassBottle.Material} bottle now has {glassBottle.Volume} liter(s) of water.");


			//Pour some of the water from the `plasticBottle` into the `glassBottle`.
			Console.WriteLine($"How much water do you want to pour from the plastic bottle into the glass bottle?");
			newVolume = float.Parse(Console.ReadLine());

			plasticBottle.PourInto(glassBottle, newVolume);
			Console.WriteLine($"The {plasticBottle.Material} bottle now has {plasticBottle.Volume} liter(s) of water.");
			Console.WriteLine($"The {glassBottle.Material} bottle now has {glassBottle.Volume} liter(s) of water.");


			//Empty both of the bottles.
			Console.WriteLine("Spilling the water out.");
			plasticBottle.Empty();
			glassBottle.Empty();
			Console.WriteLine($"The {plasticBottle.Material} bottle now has {plasticBottle.Volume} liter(s) of water.");
			Console.WriteLine($"The {glassBottle.Material} bottle now has {glassBottle.Volume} liter(s) of water.");
		}
	}
}
