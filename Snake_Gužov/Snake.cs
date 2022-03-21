using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class Snake : Figure //класс "Snake" является наследником класса "figure" так как тоже по сути образует фигуру из точек
	{



		int score = 1;
		Direction direction;//класс хранит данные о направлении куда должна двигаться змейка а заполнятются они вот тут
		public int Score
		{
			set
			{
				this.score = value;
			}
			get { return score; }
		}

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
			return nextPoint;//возвращаем значение новой/следующей точки головы
		}

		public bool IsHitTail()//
		{
			var head = pList.Last();//получаем координаты головной точки
			for (int i = 0; i < pList.Count - 2; i++)//проверяем есть ли совпадения координат головной  точки с координатами всего оставшегося хвоста
			{
				if (head.IsHit(pList[i]))//и если мы касаемся то возвращается "true"
					return true;
			}
			return false;//else false
		}

		public void HandleKey(ConsoleKey key)//метод прежназначеный для управления змейкой суть ясна и объеснена в другом месте
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

		public bool Eat(Point food)//метод чтобы змейка могла взаимодействовать с едой(кушать)
		{
			
			Point head = GetNextPoint();//получуаем точку соответствущемы следующему положению головы змейки
			if (head.IsHit(food))//если змейка касается еды(кординате головы и еды совпали) выполняется цикл
			{
				food.sym = head.sym;//еда становится символом головы
				pList.Add(food);//еда добовляется в список точек
				return true;//и в таком случае/условиях возращяется "true"
			}
			else
				return false;//по иному "false"
		}
		public int Points(Point food)//метод для подчёта очков
        {
			
			Point head = GetNextPoint();
			if (head.IsHit(food))
            {
                for (int i = 0; i < score; score++)
                {

                }
				
            }
			return score;
		}
		public static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
		public static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("GameOver!", xOffset + 10, yOffset++);
            yOffset++; WriteText($"your score is", xOffset + 8, yOffset++);
			WriteText("Creator:Vlademir Gužov", xOffset + 4, yOffset++);
			WriteText("Special for my education purposes", xOffset - 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);

		}




	}
}