using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Point//класс точка один из самых важных так как отвечает за положения всех символов на экране он приниает аргументы,
	{
		public int x;//положение точки по оси х
		public int y;//положение точки по оси y
		public char sym;//и символ который будет отрисован

		public Point()//конструктор по умолчанию создан как альтернатива для демонстрации
		{
		}

		public Point(int x, int y, char sym)//конструктор по которому работает этот класс
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
		}

		public Point(Point p)//конструктор точки который запрашивает переменную типа "point"
		{
			x = p.x;
			y = p.y;
			sym = p.sym;
		}

		public void Move(int offset, Direction direction)//функция/метод движения
		{
			if (direction == Direction.RIGHT)//если направление вправо увеличеиваем кординату х на величину смещения "offset" далее таже логика
			{
				x = x + offset;
			}
			else if (direction == Direction.LEFT)
			{
				x = x - offset;
			}
			else if (direction == Direction.UP)
			{
				y = y - offset;
			}
			else if (direction == Direction.DOWN)
			{
				y = y + offset;
			}
		}

		public bool IsHit(Point p)
		{
			return p.x == this.x && p.y == this.y;
		}

		public void Draw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(sym);
		}

		public void Clear()
		{
			sym = ' ';
			Draw();
		}

		public override string ToString()
		{
			return x + ", " + y + ", " + sym;
		}
	}
}