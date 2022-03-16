using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Figure
	{
		protected List<Point> pList;//создаем список который видно только наследникам класса

		public void Draw()//метод/функция отрисовки точек
		{
			foreach (Point p in pList)//за каждую переменую "p" типа Point в списке рисуем её
			{
				p.Draw();
			}
		}

		internal bool IsHit(Figure figure)
		{
			foreach (var p in pList)
			{
				if (figure.IsHit(p))
					return true;
			}
			return false;
		}

		private bool IsHit(Point point)
		{
			foreach (var p in pList)
			{
				if (p.IsHit(point))
					return true;
			}
			return false;
		}
	}
}