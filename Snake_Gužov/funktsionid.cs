using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace Snake_Gužov
{
	public class funktsionid//класс содержащий ввсего два метода вывода на экран текста
	{
		     
		
			public static void nedogameover(int score, string name)
		    {
				
				
				int xOffset = 25;
				int yOffset = 8;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.SetCursorPosition(xOffset, yOffset++);
				WriteText("============================", xOffset, yOffset++);
				WriteText("GameOver!", xOffset + 10, yOffset++);
				yOffset++; WriteText($"{name} your score is-->{score}", xOffset + 8, yOffset++);
				WriteText("Creator:Vlademir Gužov", xOffset + 4, yOffset++);
				WriteText("Special for my education purposes", xOffset - 1, yOffset++);
				WriteText("============================", xOffset, yOffset++);
				

		    }
		public static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
	

















}

