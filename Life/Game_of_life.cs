using System;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace Laba4_Life
{
    public class Game_of_life
    {
        private static Board board;
        public Board Board { get { return board; } }
        public Game_of_life(int width, int height, int cellSize, double liveDensity = .1)
        {
            board = new Board(width, height, cellSize, liveDensity);
        }
        public void Reset(int width, int height, int cellSize, double liveDensity = .1)
        {
            board = new Board(width, height,cellSize,liveDensity);
        }
        public void Reset(string settig_file = "settings.json")
        {
            string settings = File.ReadAllText(settig_file);
            Board_Settings set = JsonSerializer.Deserialize<Board_Settings>(settings);
            board = new Board(set.width, set.height, set.cellSize, set.liveDensity);
        }
        public void Render()
        {
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Columns; col++)
                {
                    var cell = board.Cells[col, row];
                    if (cell.IsAlive)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.Write('\n');
            }
        }
        public int Run(bool print = true, int time = 100)
        {
            if (print) Render();
            int count_of_generations = 0;
            int previous_count_alive_cells = board.CountAliveCells();
            int count_of_repetioins = 1;
            int file_number = 0;
            while (count_of_repetioins <= 5 && count_of_generations-count_of_repetioins+1<10000)
            {
                if (!Console.IsInputRedirected && Console.KeyAvailable)
                {
                    ConsoleKeyInfo name = Console.ReadKey();
                    if (name.KeyChar == 'q') break;
                    else if (name.KeyChar == 's')
                    {
                        file_number++;
                        board.Save("gen-" + file_number.ToString());
                    }
                }
                board.Advance();
                if (print)
                {
                    Console.Clear();
                    Render();
                    Thread.Sleep(time);
                }
                if (previous_count_alive_cells == board.CountAliveCells()) count_of_repetioins++;
                else
                {
                    previous_count_alive_cells = board.CountAliveCells();
                    count_of_repetioins = 1;
                }
                count_of_generations++;
            }
            count_of_generations += -count_of_repetioins + 1;
            if(print) Console.WriteLine("Перешло в стабильную фазу за " + count_of_generations + " поколений.");
            return count_of_generations;
        }
        
        public void LoadBoard(string file_name)
        {
            board.ReadFile(file_name);
        }

        public void SaveBoard(string file_name)
        {
            board.Save(file_name);
        }
        public void PrintStatistic()
        {
            int h = board.CountHive();
            int l = board.CountLoaf();
            int p = board.CountPond();
            int box = board.CountBox();
            int block = board.CountBlock();
            int sn = board.CountSnake();
            int blinker = board.CountBlinker();
            int c = board.CountCarrier();
            int barge = board.CountBarge();
            int boat = board.CountBoat();
            int sh = board.CountShip();
            int l_barge = board.CountLongBarge();
            int l_boat = board.CountLongBoat();
            int l_sh = board.CountLongShip();
            Console.WriteLine("Статистика:\n");
            Console.WriteLine("Общее количество клеток на поле: " + board.CountAliveCells());
            Console.WriteLine("Общее количество комбнаций: " + (h + l + p + box + block + sn + blinker + c + barge + boat + sh + l_barge + l_boat + l_sh).ToString());
            Console.WriteLine("Статистика комбинаций:");
            Console.WriteLine(" Улий - "+h);
            Console.WriteLine(" Каравай - "+l);
            Console.WriteLine(" Пруд - "+p);
            Console.WriteLine(" Ящик - " + box);
            Console.WriteLine(" Блок - "+block);
            Console.WriteLine(" Змея - "+sn);
            Console.WriteLine(" Мигалка - " + blinker);
            Console.WriteLine(" Перевозчик - " + c);
            Console.WriteLine(" Баржа - "+barge);
            Console.WriteLine(" Лодка - "+boat);
            Console.WriteLine(" Корабль - "+sh);
            Console.WriteLine(" Длинная баржа - "+l_barge);
            Console.WriteLine(" Длинная лодка - "+l_boat);
            Console.WriteLine(" Длинный корабль - "+l_sh);
            Console.WriteLine("Симметрия (процентное соотношение): ");
            Console.WriteLine(" Вертикальная - " + board.SymmetryVertical() * 100);
            Console.WriteLine(" Горизонтальная - " + board.SymmetryHorizontal() * 100);
            Console.WriteLine(" Центральная - " + board.SymmetryCentral() * 100);
        }

        public double AvarageCountOfGeneration(int count_of_exp, int width, int height, int cellSize, double liveDensity)
        {
            int sum = 0;
            for (int i = 0; i <count_of_exp;i++)
            {
                board = new Board(width, height, cellSize, liveDensity);
                sum += Run(false);
            }
            Console.WriteLine("Среднее количество поколений: " + sum/count_of_exp);
            return sum / count_of_exp;
        }
    }
    class Board_Settings
    {
        public int width { get; set; }
        public int height { get; set; }
        public int cellSize { get; set; }
        public double liveDensity { get; set; }
    }
}
