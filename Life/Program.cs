using System;

namespace Laba4_Life
{
    public class Program
    {

        static void Main(string[] args)
        {
            Game_of_life Life = new Game_of_life(50, 30, 1, 0.5);
            int steps = Life.Run(true, 100);
            Console.WriteLine("Количество ходов: " + steps);
            Life.PrintStatistic();
            Life.AvarageCountOfGeneration(100, 50, 30, 1, 0.5);

        }    
    }
}
