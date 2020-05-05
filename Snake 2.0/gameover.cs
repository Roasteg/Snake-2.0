using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
	class GameOver
	{
		public void WriteGameOver(int score)
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			Console.WriteLine("Ваш счёт - " + score);
			Console.Write("Введите ваше имя: ");
			string name = Console.ReadLine();
			using (var file = new System.IO.StreamWriter("result.txt", true))
			{
				file.WriteLine("Name - " + name + "& Score - " + score);
				file.Close();
			}
		}
		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}
