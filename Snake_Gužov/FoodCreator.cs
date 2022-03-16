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

		Random random = new Random();//объевляем переменную типа рандом и создаём её экземпляр

		public FoodCreator(int mapWidth, int mapHeight, char sym)//консруктор по кторому работает наш "генератор еды" в нём указаны
		{
			this.mapWidht = mapWidth;//конкретно эта ширина 
			this.mapHeight = mapHeight;//конкретно эта длинна 
			this.sym = sym;//конкретно этот символ
		}

		public Point CreateFood()//метод создания "еды" не замысловатыми действиями спавним(отрисовываем) еду в случайной точке по оси х и y с указаным символом 
		{
			int x = random.Next(2, mapWidht - 2);
			int y = random.Next(2, mapHeight - 2);
			return new Point(x, y, sym);
		}
	}
}