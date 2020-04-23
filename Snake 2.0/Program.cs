using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
			sound.Play();

			Snake_2._0.Sounds sound1 = new Snake_2._0.Sounds(settings.GetResourceFolder());

			Snake_2._0.Sounds sound2 = new Snake_2._0.Sounds(settings.GetResourceFolder());

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					sound2.PlayLose();
					break;
				}
				if (snake.Eat(food))
				{
					sound1.PlayEat();
					food = foodCreator.CreateFood();
					food.Draw();
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

			WriteGameOver();
			Console.ReadLine();
		}


		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			Console.Write("Введите ваше имя: ");
			string name = Console.ReadLine();
			System.IO.StreamWriter to_file = new System.IO.StreamWriter("Nimi.txt", true);
			{
				to_file.WriteLine(name);
			}
			to_file.Close();
		}
	
		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
		
	}
}