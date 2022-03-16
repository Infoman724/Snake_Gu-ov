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
			

			Walls walls = new Walls(80, 25);//отрисовка стен
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);//при запуске игры змейка начинает движение вправо из указаной точки
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');//создание объекта еда с условиями длина,ширина карты и символ как еда будет выглядеть
			Point food = foodCreator.CreateFood();//наш объект
			food.Draw();//отрисовка еды 

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())//если змея врезается в стенку то программа прерывается
				{
					break;
				}
				if (snake.Eat(food))//если змейка косантся "еды" то создается еще одна "еда"
				{
					food = foodCreator.CreateFood();//создания объекта "еда"
					food.Draw();//отрисовка
				}
				else
				{
					snake.Move();//по иному движемся дальше (отрисовываем новые точки хвоста и удаляем точки головы заменя новыми
				}

				Thread.Sleep(100);//задержка 100 милисекунд
				if (Console.KeyAvailable)//если клавиши доступны
				{
					ConsoleKeyInfo key = Console.ReadKey();//здесь мы считываем нажатую клавишу для управления змейкой
					snake.HandleKey(key.Key);//здесь мы считаные данные применяем
				}
			}
            Snake_Gužov.funktsionid.WriteGameOver();//этот кусочек кода отвечает за вывод "ненавистной" надписи GameOver!
			Console.ReadLine();//этот костыль для того чтобы программа не закрывалась сразу после окончания работы
		}


		

		

	}
}