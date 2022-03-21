using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class FoodCreator
	{
		int mapWidht;//поля определяющие ширину и высоту карты и символ которым будет отрисована "еда"
		int mapHeight;
		char sym;
		public ConsoleColor color;//возможность выбрать цвет точки

		Random random = new Random();//объевляем переменную типа рандом и создаём её экземпляр

		public FoodCreator(int mapWidth, int mapHeight, char sym ,ConsoleColor color)//консруктор по кторому работает наш "генератор еды" в нём указаны
		{
			this.mapWidht = mapWidth;//обращение к полям класса а не к данным как аргмуент значениям
			this.mapHeight = mapHeight;// обращение к полям класса а не к данным как аргмуент значениям
			this.sym = sym;//обращение к полям класса а не к данным как аргмуент значениям
			this.color = color;
		}

		public Point CreateFood()//метод создания "еды" не замысловатыми действиями спавним(отрисовываем) еду в случайной точке по оси х и y с указаным символом 
		{
			int x = random.Next(2, mapWidht - 2);
			int y = random.Next(2, mapHeight - 2);
			return new Point(x, y, sym , ConsoleColor.Green);
		}
	}
}