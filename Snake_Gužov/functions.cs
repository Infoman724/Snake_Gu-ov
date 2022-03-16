using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Gužov
{
    class functions
    {
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор:владемир гужов", xOffset + 2, yOffset++);
            WriteText("Специально для моего обучения", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }









    }
}
