using System;

public class Challenge2
{
	// Talk about methods/functions
	// You may need math function documentation here: https://docs.microsoft.com/en-us/dotnet/api/system.math?view=netcore-3.1
	
	// This program should print an output that looks EXACTLY like this:
	//
	// ####
    // #####
    // ######
    // ##########
    // ####################
    // ####################
    // ####################
    // ##########
    // ######
    // #####
	// ####
    //
	
	public static void Main()
	{
		for(int i = -5; i <= 5; i++) 
		{
			var result = ChangeValue(i);
			for(int j = 0; j < result; j++) 
			{
				Console.Write("#");
			}
			Console.WriteLine();
		}
	}
	
	public static int ChangeValue(int a) 
	{
	    if(a == 0){
	        return 20;
	    } else{
		return 20 / Math.Abs(a);
	    }
	}
}
