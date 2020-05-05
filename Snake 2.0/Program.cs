using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WMPLib;


namespace Snake
{
	class Program
	{

		static void Main(string[] args)
		{
			Console.SetWindowSize(80, 25);
			Walls walls = new Walls(80, 25);
			walls.Draw();

			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			Snake_2._0.Params settings = new Snake_2._0.Params();
			Snake_2._0.Sounds sound = new Snake_2._0.Sounds(settings.GetResourceFolder());

			Snake_2._0.Sounds sound1 = new Snake_2._0.Sounds(settings.GetResourceFolder());

			Snake_2._0.Sounds sound2 = new Snake_2._0.Sounds(settings.GetResourceFolder());
			var enableSound = MessageBox.Show("Включить звук?", "Настройка звука", MessageBoxButtons.YesNo);
			if (enableSound == DialogResult.Yes)
			{
				sound.Play();
			}

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					if (enableSound == DialogResult.No)
					{
						break;
					}
					else if (enableSound == DialogResult.Yes)
					{
						sound.Stop();
						sound2.PlayLose();
						break;
					}

				}
				if (snake.Eat(food))
				{
					if (enableSound == DialogResult.Yes)
					{
						sound1.PlayEat();
						food = foodCreator.CreateFood();
						food.Draw();
					}
					else if (enableSound == DialogResult.No)
					{
						food = foodCreator.CreateFood();
						food.Draw();
					}
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			Snake_2._0.GameOver over = new Snake_2._0.GameOver();
			over.WriteGameOver(snake.score);
			Console.ReadLine();
		}
	}

}