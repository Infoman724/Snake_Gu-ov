using Snake_Gužov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Snake
{
	class Program
	{


		static void Main(string[] args)
		{
			int score = 0;
			Console.WriteLine("Enter your name please it should be at least 3 letters long--> ");
			string name = Console.ReadLine();


			Console.SetWindowSize(90, 35);//установка размера окна консоли
			Walls walls = new Walls(80, 25);//отрисовка стен
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point(4, 5, '*', ConsoleColor.Red);
			Snake snake = new Snake(p, 8, Direction.RIGHT);//при запуске игры змейка начинает движение вправо из указаной точки
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$', ConsoleColor.Green);//создание объекта еда с условиями длина,ширина карты и символ как еда будет выглядеть
			Point food = foodCreator.CreateFood();//наш объект
			food.Draw();//отрисовка еды 
			Params settings = new Params();
			Sounds sound = new Sounds(settings.GetResourceFolder());
			Sounds kus = new Sounds(settings.GetResourceFolder());
			//sound.Play();
			

			while (true)
			{

				if (walls.IsHit(snake) || snake.IsHitTail())//если змея врезается в стенку или хвост то программа прерывается
				{

					break;
				}
				if (snake.Eat(food))//если змейка косается "еды" то создается еще одна "еда" и добовляется одно очко и проигрывается звук "поедания"
				{
					kus.PlayEat();
					food = foodCreator.CreateFood();//создания объекта "еда"
					food.Draw();//отрисовка
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
				if (score >= 1)
				{
					StreamWriter to_file = new StreamWriter(@"..\..\Vast.txt", true);
					to_file.WriteLine(name + " - " + score);
					to_file.Close();
				}
			}
			
			
			Snake_Gužov.funktsionid.nedogameover(score, name);
			//Snake_Gužov.funktsionid.WriteGameOver();//этот кусочек кода отвечает за вывод "ненавистной" надписи GameOver!
			Console.ReadLine();//этот костыль для того чтобы программа не закрывалась сразу после окончания работы
							   






		}

	}
}
