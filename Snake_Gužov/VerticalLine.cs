using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class VerticalLine : Figure//класс "горизонтальная линия" является наследником класса фигура
	{
		public VerticalLine(int yUp, int yDown, int x, char sym)//конструктор принимающий значения верхней точки "у" и нижней точек "у" а также координату "х" символ которым будет отрисована линия
		{
			pList = new List<Point>();//создаём по класике новый список точек
			for (int y = yUp; y <= yDown; y++)//и за каждый "у"  меньше нижнего прибавляем один
			{
				Point p = new Point(x, y, sym);//создаёем переменную "p" типа "point" на каждом витке цикла
				pList.Add(p);//и добовляем ее в список на каждом витке цикла
			}
		}
		}
	}
}