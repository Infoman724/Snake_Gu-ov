using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			int score = 0;
			Console.WriteLine("Enter your name please--> ");
			string name = Console.ReadLine();			
			Console.SetWindowSize(90,35);//установка размера окна консоли
			Walls walls = new Walls(80, 25);//отрисовка стен
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 8, Direction.RIGHT);//при запуске игры змейка начинает движение вправо из указаной точки
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');//создание объекта еда с условиями длина,ширина карты и символ как еда будет выглядеть
			Point food = foodCreator.CreateFood();//наш объект
			food.Draw();//отрисовка еды 
			

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())//если змея врезается в стенку или хвост то программа прерывается
				{
					break;
				}
				if (snake.Eat(food))//если змейка косается "еды" то создается еще одна "еда"
				{
					food = foodCreator.CreateFood();//создания объекта "еда"
					food.Draw();//отрисовка
					score++;
				}
				else
				{
					snake.Move();//по иному движемся дальше в том  же направлении (отрисовываем новые точки хвоста и удаляем точки головы заменя новыми в том же направлении в каком двигались до этого)
				}

				Thread.Sleep(100);//задержка 100 милисекунд
				if (Console.KeyAvailable)//проверка на нажатие клавиши
				{
					ConsoleKeyInfo key = Console.ReadKey();//здесь мы считываем нажатую клавишу для управления змейкой
					snake.HandleKey(key.Key);//здесь мы считаные данные применяем
				}
			}
			nedogameover(score, name);
			//Snake_Gužov.funktsionid.WriteGameOver();//этот кусочек кода отвечает за вывод "ненавистной" надписи GameOver!
			Console.ReadLine();//этот костыль для того чтобы программа не закрывалась сразу после окончания работы
			static void nedogameover(int score, string name)
			{
				int xOffset = 25;
				int yOffset = 8;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.SetCursorPosition(xOffset, yOffset++);
				WriteText("============================", xOffset, yOffset++);
				WriteText("GameOver!", xOffset + 10, yOffset++);
				yOffset++; WriteText($"{name}, {score}", xOffset + 8, yOffset++);
				WriteText("Creator:Vlademir Gužov", xOffset + 4, yOffset++);
				WriteText("Special for my education purposes", xOffset - 1, yOffset++);
				WriteText("============================", xOffset, yOffset++);
				
			}
			
		}
		public static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}






	}
}