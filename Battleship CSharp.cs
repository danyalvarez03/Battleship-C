/*
 * Created by SharpDevelop.
 * User: 0726176
 * Date: 4/27/2018
 * Time: 11:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Battleship
{
	class BattleShipBoard
	{
		public void displayBoard(char[,] Board)
			{
				int Row;
				int Column;
				
				Console.WriteLine("  | 0 1 2 3 4 5 6 7 8 9");
				Console.WriteLine("----------------");
				for (Row = 0; Row <= 9; Row++)
				{
					Console.Write((Row).ToString() + " | ");
					for (Column = 0; Column <= 9; Column++)
					{
						Console.Write(Board[Column, Row] + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine("\n");
			}
	}
			
	class Player
	{
		char[,] Grid = new char[10, 10];
		public int HitCount = 0;
		public int MissCount = 0;
		int x = 0;
		int y = 0;
		
		public int getHitCount()
		{
			return HitCount;
		
		}
		
		public int getMissCount()
		{
			return MissCount;
		}
		
		public void AskCoordinates()
		{
			Console.WriteLine("Enter x");
			string line = Console.ReadLine();
			int value;
			
			if (int.TryParse(line, out value))
			{
				x = value;
			}
		    else
		    {
			    Console.WriteLine("Not an integer!");
		    }
		    
		    Console.WriteLine("Enter y");
			line = Console.ReadLine();
			
			if (int.TryParse(line, out value))
			{
				y = value;
			}
		    else
		    {
			    Console.WriteLine("Not an integer!");
		    }
		    
		    try
		    {
		    	if (Grid[x,y].Equals('5'))
		    	{
		    		Grid[x,y] = "H";
		    		Console.Clear();
		    		Console.WriteLine("Hit!\r\n");
		    		HitCount += 1;
		    	}
		    	else
		    	{
		    		Grid[x,y] = "M";
		    		Console.Clear();
		    		Console.WriteLine("Miss!\r\n");
		    		MissCount += 1;
		    	}
		    }
		    catch
		    {
		    	Console.Clear();
		    	Console.WriteLine("Error");
		    }
		    	
	    }
		public char[,] GetGrid()
		{
			return Grid;
		}
		public void SetGrid(int q, int w)
		{
			Grid[q,w] = 's';			
		}
		public void Randomize()
		{
			Random r = new Random(2);
			//1 of length 2
			SetGrid(1,2);
			SetGrid(2,2);
			
			//2 of length 3
			SetGrid(4,3);
			SetGrid(4,4);
			SetGrid(4,5);
			
			SetGrid(5,0);
			SetGrid(6,0);
			SetGrid(7,0);
			
			//1 of length 4
			SetGrid(0,8);
			SetGrid(1,8);
			SetGrid(2,8);
			SetGrid(3,8);
			
			//1 of length 5
			SetGrid(7,4);
			SetGrid(7,5);
			SetGrid(7,6);
			SetGrid(7,7);
			SetGrid(7,8);
			
		}
			
	}
		
	
	class Program
	{
	
	public static void Main(string[] args)
		{
			Console.Title = "Battleship!!"
			Console.WriteLine("Welcome to battleship!\r\n\r\n");
			Console.WriteLine("What is your name?");
			string name = System.Console.ReadLine();
			Console.WriteLine();
			BattleShipBoard b = new BattleShipBoard();
			Player p = new Player();
			p.Randomize();
			
			while(p.getHitCount() < 17)
			{
				b.displayBoard(p.GetGrid());
				p.AskCoordinates();
			}
			
			Console.WriteLine("Congrats, " + name + "You Win!\r\n");
			Console.WriteLine("You missed: " + p.getMissCount() + "times\r\n");
			Console.WriteLine("Thanks for playing Battleship. Press enter to quit.");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}