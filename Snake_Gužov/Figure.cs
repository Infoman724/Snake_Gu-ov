using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class Figure
	{
		protected List<Point> pList;//создаем список который видно только наследникам класса

		public void Draw()//метод/функция отрисовки точек
		{
			foreach (Point p in pList)//за каждую переменую "p" типа Point в списке рисуем её
			{
				p.Draw();
			}
		}

		internal bool IsHit(Figure figure)//передаём в качестве аргумента переменную "figure" типа "Figure"
		{
			foreach (var p in pList)//за каждую переменую типа точка в списке "pList"
			{
				if (figure.IsHit(p))//если фигура касается(их координаты совпадают) с точкой из списка возвращается "true"
					return true;
			}
			return false;//по иному возращаем "false"
		}

		private bool IsHit(Point point)//метод для сравнения пересечения кординат точек
		{
			foreach (var p in pList)//за каждую переменую типа точка в списке точек "pList"
			{
				if (p.IsHit(point))//если точка касается точки возвращается "true"
					return true;
			}
			return false;// по иному возрвращаем "false" 
		}
	}
}