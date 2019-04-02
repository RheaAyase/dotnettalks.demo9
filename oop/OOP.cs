using System;

namespace OpenHouse
{
	class Bottle								// Class definiton for `Bottle` type objects
	{
		public float Capacity = 1; //liter		// Member variable `Capacity`
		public float Volume = 0;   //liter		// Public member variable `Volume`
		public string Material = "unknown";		// Public member variable `Material`

		public Bottle(string material)			// Constructor, sets the `Material` of the newly created `Bottle` object
		{
			this.Material = material;
		}

		public void Fill(float volume)			// Method, adds a specific `volume` of liquid to the `Volume`...
		{										// ...without overflowing over the maximum `Capacity`
			this.Volume = Math.Min(this.Volume + volume, this.Capacity);
		}

		public void PourInto(Bottle targetBottle, float volume) // Method, fills a target bottle from `this` one...
		{														// ...up to the `Volume` currently held
			volume = Math.Min(volume, this.Volume);		// Is the desired `volume` greater than the currently held?
			targetBottle.Fill(volume);					// Fill the target bottle with it.
			this.Volume -= volume;						// Remove the `volume` from `this` bottle.
		}

		public void Empty()			// Method, sets the current `Volume` to zero.
		{
			this.Volume = 0;
		}
	}
}
