using System;

public class Challenge3
{
    // A recent commercial probe sent to land on an asteroid has crashed! You are assigned to the 
    // investigation team. THe code below has been set up to simulate the conditions of the crash.
    
    // You must evaluate this landing control software 
    // and determine the cause of the crash, and provide a fix to the 
    // control system for next time. 
    
    // The leading theories are that either
    // (1) The initial atmospheric entry altitude may have been incorrect. 
    // (2) The landing rockets may not have put out as much power as expected.

    // For a successful landing, the velocity should be zero at the same time that the 
	// altitude is 250 meters (height of the landing site)
    
    // Alt: 400  Vel: 100
    // Alt: 300  Vel: 50
    // Alt: 250  Vel: 0
    // LANDED SAFELY!

    static int ROCKET_POWER = -50;
    static double METERS_TO_FT = 3.28;

	public static void Main()
	{
		int altitude = (int)(15244 * METERS_TO_FT); // atmospheric entry above ground level
		int velocity = (int)(152.44 * METERS_TO_FT); // ft per second
		int dt = 1; // time step
		bool retroFired = false;
		int velocityChange = 0;
		
		while(altitude > 250 && Math.Abs(velocity) < 1000 /* if velocity is too high something is wrong */) 
		{
			// Firing logic reviewed and approved by B. Eldridge 7/5/2020
			if(CheckFireRetroRockets(altitude) && 
			   retroFired == false /* don't fire if we already did */) 
			{
				retroFired = true;
				velocityChange = ROCKET_POWER;
			}
			
			altitude -= velocity * dt;
			
		    velocity += velocityChange;
			Console.WriteLine($"Alt: {altitude}  Vel: {velocity}");
		}	

        EvaluateResult(velocity);		
	}
	
	public static void EvaluateResult(int velocity) 
	{
	    if(velocity > 5) 
		{
			Console.WriteLine("CRASH!");
		}
		else if (velocity < -100) 
		{
			Console.WriteLine("YEET!");
		}
		else 
		{
			Console.WriteLine("LANDED SAFELY!");
		}
	}
	
	static int FIRE_ALTITUDE = 3067; // landing rockets should start to fire 
	                                 // when altitude reaches 1067 meters
	
	public static bool CheckFireRetroRockets(int altitude) 
	{
		return altitude < FIRE_ALTITUDE;
	}
}
