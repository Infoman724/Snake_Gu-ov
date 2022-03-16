using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Snake : Figure //класс "Snake" является наследником класса "figure" так как тоже по сути образует фигуру из точек
	{
		Direction direction;//класс хранит данные о направлении куда должна двигаться змейка а заполнятются они вот тут
		public Snake(Point tail, int length, Direction _direction)//конструктор змейка принимает три аргумента - положения точки хвоста, длинну и направления куда змейка начнёт своё движение
		{
			direction = _direction;//приравниваем переменную "_direction" к данным direction таким образом мы сможем продолжить ими пользоваться 
			pList = new List<Point>();//создаём список точек
			for (int i = 0; i < length; i++)
			{
				Point p = new Point(tail);//создаём копию точки хвоста
				p.Move(i, direction);//смещаем точку на "i" по указаному направлению в нашем случае вправо 
				pList.Add(p);//и добовляем в наш список точек точку "p"
			}
		}

		public void Move()//метод движения змейки
		{
			Point tail = pList.First();//возвращает первую позицию списка точку хвоста 
			pList.Remove(tail);//точка которая раньше была хвостом уже не является частью змейки поэтому мы должны её удалить
			Point head = GetNextPoint();//
			pList.Add(head);

			tail.Clear();
			head.Draw();
		}

		public Point GetNextPoint()
		{
			Point head = pList.Last();//получаем позицию точки до перемещения
			Point nextPoint = new Point(head);//создаём переменую которая является копиеё предыдущей позиции головы
			nextPoint.Move(1, direction);//и сдвигаем эту самую точку на одну координату по направлению движения
			return nextPoint;//возвращаем значение новой/следующей точки
		}

		public bool IsHitTail()
		{
			var head = pList.Last();
			for (int i = 0; i < pList.Count - 2; i++)
			{
				if (head.IsHit(pList[i]))
					return true;
			}
			return false;
		}

		public void HandleKey(ConsoleKey key)
		{
			if (key == ConsoleKey.LeftArrow)
				direction = Direction.LEFT;
			else if (key == ConsoleKey.RightArrow)
				direction = Direction.RIGHT;
			else if (key == ConsoleKey.DownArrow)
				direction = Direction.DOWN;
			else if (key == ConsoleKey.UpArrow)
				direction = Direction.UP;
		}

		public bool Eat(Point food)
		{
			//int score = 0;
			Point head = GetNextPoint();
			if (head.IsHit(food))
			{
				food.sym = head.sym;
				pList.Add(food);
                /*for (int i = 0; i < length; i++)
                {

                }*/
				return true;
			}
			else
				return false;
		}
		
		





	}
}