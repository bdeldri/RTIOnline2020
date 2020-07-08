	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class RiseAboveScoring
	{
		// Talk about structs
		// Talk about lists
		// Talk about functions again
		
		// Game field setup
		// 27 total risers (9 teal, 9 orange, 9 purple)
		// 9 goals in a square, number the positions 0 through 8:
		//
		//     
		//  [ 0 ]      [ 1 ]      [ 2 ] 
		//  [ 3 ]      [ 4 ]      [ 5 ] 
		//  [ 6 ]      [ 7 ]      [ 8 ]
		//
		// A total of 8 rows are possible (3 horizontal, 3 vertical, two diagonal)
		// Each goal can have up to three risers at different heights, call the heights 0, 1 and 2

		// A base riser is touching the game field, worth 1 point
		// A stacked riser is on top of another riser, worth 1 point
		// A completed row is a row that has all three of the same color, worth 3 points
		// A completed stack is a goal that has three risers of the same color AND is in a completed row, worth 30 points
		
		public struct Goal 
		{
			public int Position;
			public int Height;
			public string Color;
		}
		
		public static void Main()
		{
			List<Goal> board = new List<Goal>();

            // SETUP THE BOARD HERE
			board.Add(new Goal() { Position = 1, Height = 0, Color = "purple" });
			board.Add(new Goal() { Position = 2, Height = 0, Color = "purple" });
			
			board.Add(new Goal() { Position = 0, Height = 0, Color = "purple" });
			board.Add(new Goal() { Position = 0, Height = 1, Color = "purple" });
			board.Add(new Goal() { Position = 0, Height = 2, Color = "purple" });

			board.Add(new Goal() { Position = 4, Height = 0, Color = "orange" });
			// END OF BOARD SETUP
			
			if(IsBoardValid(board) == false)
			{
				Console.WriteLine("Invalid board");
			}
			else
			{			
				int totalScore = 
					1 * CalculateNumberOfBaseRisers(board) +
					1 * CalculateNumberOfStackedRisers(board) +
					3 * CalculateNumberOfCompletedRows(board) +
					30 * CalculateNumberOfCompletedStacks(board);
					
				Console.WriteLine($"Score = {totalScore}");
			}
		}
		
		// This function check to see that the board configuration is possible and returns true or false
		// BONUS TASK: add a check that makes sure there aren't any floating risers
		public static bool IsBoardValid(List<Goal> p_board) 
		{
			int purpleCount = 0;
			int tealCount = 0;
			int orangeCount = 0;
			
			foreach(var goal in p_board)
			{
				if(goal.Color == "purple")
				{
					purpleCount++;
				}
				else if (goal.Color == "teal")
				{
					tealCount++;
				}
				else if (goal.Color == "orange")
				{
					orangeCount++;
				}
				else 
				{
					Console.WriteLine("Invalid color!");
					return false;
				}

			    // This is a slick way to check for duplicates in C#, don't worry about how this works right now
			    if(p_board.Count(g => g.Position == goal.Position && g.Height == goal.Height) > 1) 
			    {
			        Console.WriteLine("Two risers in the same position");
			        return false;
			    }
			}
			
			if(purpleCount > 9 || tealCount > 9 || orangeCount > 9) 
			{
				Console.WriteLine("Too many risers");
				return false;
			}
			
			// Everything looks ok
			return true;
		}

		// This function returns the color of the riser at the specified position and height, or an empty string "" if no riser is present
		public static string ColorAtPosition(List<Goal> p_board, int p_pos, int p_height) 
		{
			foreach(var goal in p_board) 
			{
				if(goal.Position == p_pos && goal.Height == p_height) 
				{
					return goal.Color;
				}
			}
			
			return "";
		}
		
		// This function returns true if the three risers at the specified positions all exist and are the same color
		public static bool IsRowComplete(List<Goal> p_board, int p_pos1, int p_pos2, int p_pos3) 
		{
			string color1 = ColorAtPosition(p_board, p_pos1, 0);
			string color2 = ColorAtPosition(p_board, p_pos2, 0);
			string color3 = ColorAtPosition(p_board, p_pos3, 0);
			
			bool allRisersPresent = color1 != "" && color2 != "" && color3 != "";
			bool colorsMatch = (color1 == color2 && color2 == color3);
			
			if(allRisersPresent && colorsMatch)
			{
				return true;
			}			
			else 
			{
				// Risers not present or color doesn't match
				return false;
			}		
		}

		// This function determines if a stack is complete at the specified position 
		// Remember, a completed stack means all three risers are stacked and are the same color (like a vertical row)
		public static bool IsStackComplete(List<Goal> p_board, int p_pos) 
		{
			throw new NotImplementedException();
		}	
		
		// This function counts all the risers that are touching the board (height is 0)
		public static int CalculateNumberOfBaseRisers(List<Goal> p_board) 
		{
			int baseRisers = 0;
			foreach(var goal in p_board) 
			{
				if(goal.Height == 0) 
				{
					baseRisers++;    
				}
			}
			return baseRisers;
		}

		// This function counts all the stacked risers (height greater than 1) 
		public static int CalculateNumberOfStackedRisers(List<Goal> p_board) 
		{
			throw new NotImplementedException();
		}
		
		// This function counts how many completed rows are in the board. 
		// Remember, a completed row means we have three risers in the same row of the same color
		public static int CalculateNumberOfCompletedRows(List<Goal> p_board)
		{
			int completedRows = 0;
			
			// Row 1 - horizontal
			if(IsRowComplete(p_board, 0, 1, 2))
			{
				completedRows++;
			}

			//TODO: finish this code

			throw new NotImplementedException();
			
			return completedRows;
		}

		// This function counts how many completed stacks are in a completed row. 
		// If the row is not complete, a zero will be returned.
		public static int CalculateCompletedStacksInRow(List<Goal> p_board, int p_pos1, int p_pos2, int p_pos3) 
		{
			int stacksInRow = 0;
			
			if(IsRowComplete(p_board, p_pos1, p_pos2, p_pos3)) 
			{
				if(IsStackComplete(p_board, p_pos1))
				{
					stacksInRow++;
				}

				if(IsStackComplete(p_board, p_pos2))
				{
					stacksInRow++;
				}

				if(IsStackComplete(p_board, p_pos3))
				{
					stacksInRow++;
				}
			}
			
			return stacksInRow;
		}

		// A completed stack is three risers stacked in a goal AND a completed row
		public static int CalculateNumberOfCompletedStacks(List<Goal> p_board) 
		{
			int completedStacks = 0;
			
			// Row 1 - horizontal
			completedStacks += CalculateCompletedStacksInRow(p_board, 0, 1, 2);

			//TODO: Finish this code
			
			throw new NotImplementedException();
			
			return completedStacks;
		}
	}
		
