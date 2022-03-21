using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class HorisontalLine : Figure//класс "горизонтальная линия" является наследником класса фигура 
	{
		public HorisontalLine(int xLeft, int xRight, int y, char sym)//конструктор принимающий значения левой точки "х" и правой точек "х" а также координату "y" символ которым будет отрисована линия
		{
			pList = new List<Point>();//создаём по класике новый список точек
			for (int x = xLeft; x <= xRight; x++)//и за каждый "х" слева меньше правого прибавляем один
			{
				Point p = new Point(x, y, sym, ConsoleColor.Red);//создаёем переменную "p" типа "point" на каждом витке цикла
				pList.Add(p);//и добовляем ее в список на каждом витке цикла
			}
		}
	}
}