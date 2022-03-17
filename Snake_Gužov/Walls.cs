using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Walls//класс ответственный за отрисовку стен/рамочки и имеющий методы для проверки столкновения змейки с объктами
	{
		List<Figure> wallList;//создаём список фигур

		public Walls(int mapWidth, int mapHeight)
		{
			wallList = new List<Figure>();

			// Отрисовка рамочки
			HorisontalLine upLine = new HorisontalLine(0, mapWidth - 2, 0, '+');
			HorisontalLine downLine = new HorisontalLine(0, mapWidth - 2, mapHeight - 1, '+');
			VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
			VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

			wallList.Add(upLine);//здесь мы добовляем в список фигур/стен наши линии/стены мы можем это сделать так как они(линии) являются наследниками класаа фигура
 			wallList.Add(downLine);
			wallList.Add(leftLine);
			wallList.Add(rightLine);
		}

		internal bool IsHit(Figure figure)//метод принимающий как аргумента "фигуру" типа "Figure"
		{
			foreach (var wall in wallList)//и за каждую переменую типа "стена" в списке стен проверяет 
			{
				if (wall.IsHit(figure))//коснулась-ли стена обьекта типа "фигура" и если да то возращаем "true"
				{
					return true;
				}
			}
			return false;//по иному возвращаем "false"
		}

		public void Draw()//метод отрисовки "стен"
		{
			foreach (var wall in wallList)
			{
				wall.Draw();
			}
		}
	}
}