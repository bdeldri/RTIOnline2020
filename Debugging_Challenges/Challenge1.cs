using System;

public class Challenge1
{
	public static void Main()
	{
		int[] valuesToPrint = new int[] { 55, 66, 77, 88, 99 };
		
		// OBJECTIVE: Print the values in the provided array. Output should look like this:
		//
		// 55
		// 66
		// 77
		// 88
		// 99
		//
		
        for(var i = 0; i < 5; i++) {
            Console.WriteLine(valuesToPrint[i]);
        }
	}
} 
