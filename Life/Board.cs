
using System;
using System.IO;

namespace Laba4_Life
{
    public class Board
    {
        public readonly Cell[,] Cells;
        public readonly int CellSize;

        public int Columns { get { return Cells.GetLength(0); } }
        public int Rows { get { return Cells.GetLength(1); } }
        public int Width { get { return Columns * CellSize; } }
        public int Height { get { return Rows * CellSize; } }

        public Board(int width, int height, int cellSize, double liveDensity = .1)
        {
            CellSize = cellSize;

            Cells = new Cell[width / cellSize, height / cellSize];
            for (int x = 0; x < Columns; x++)
                for (int y = 0; y < Rows; y++)
                    Cells[x, y] = new Cell();

            ConnectNeighbors();
            Randomize(liveDensity);
        }
        public void ReadFile(string file_name)
        {
            string[] board = File.ReadAllLines(file_name);
            int f_rows = board.Length;
            int f_columns = board[0].Length;
            for(int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)   
                {
                    if (((Rows > f_rows) && ((i < (Rows - f_rows) / 2) || (i >= (Rows - f_rows) / 2 + f_rows))) ||
                        ((Columns > f_columns) && ((j < (Columns - f_columns) / 2) || (j >= (Columns - f_columns) / 2 + f_columns))) ||
                        (Rows>f_rows && Columns>f_columns && board[i - (Rows - f_rows) / 2][j - (Columns - f_columns) / 2]=='-')||
                        (Rows <= f_rows && Columns > f_columns && board[i][j - (Columns - f_columns) / 2] == '-')||
                        (Rows > f_rows && Columns <= f_columns && board[i - (Rows - f_rows) / 2][j] == '-')||
                        ((Rows <= f_rows) && (Columns <= f_columns) && (board[i][j] == '-')))
                        Cells[j, i].IsAlive = false;

                    else
                        Cells[j, i].IsAlive = true;
                }
            }
        }

        public void Save(string file_name)
        {
            StreamWriter sr = new StreamWriter(file_name + ".txt");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Cells[j, i].IsAlive)
                        sr.Write("*");
                    else
                        sr.Write("-");
                }
                sr.WriteLine("");
            }
            sr.Close();

        }

        readonly Random rand = new Random();
        public void Randomize(double liveDensity)
        {
            foreach (var cell in Cells)
                cell.IsAlive = rand.NextDouble() < liveDensity;
        }

        public void Advance()
        {
            foreach (var cell in Cells)
                cell.DetermineNextLiveState();
            foreach (var cell in Cells)
                cell.Advance();
        }
        private void ConnectNeighbors()
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    int xL = (x > 0) ? x - 1 : Columns - 1;
                    int xR = (x < Columns - 1) ? x + 1 : 0;

                    int yT = (y > 0) ? y - 1 : Rows - 1;
                    int yB = (y < Rows - 1) ? y + 1 : 0;

                    Cells[x, y].neighbors.Add(Cells[xL, yT]);
                    Cells[x, y].neighbors.Add(Cells[x, yT]);
                    Cells[x, y].neighbors.Add(Cells[xR, yT]);
                    Cells[x, y].neighbors.Add(Cells[xL, y]);
                    Cells[x, y].neighbors.Add(Cells[xR, y]);
                    Cells[x, y].neighbors.Add(Cells[xL, yB]);
                    Cells[x, y].neighbors.Add(Cells[x, yB]);
                    Cells[x, y].neighbors.Add(Cells[xR, yB]);
                }
            }
        }


        private int CountPattern(byte[,] pattern)
        {
            int count = 0;
            int p_columns = pattern.GetLength(1);
            int p_rows = pattern.GetLength(0);
            for (int col = 0; col < Columns; col++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    bool isAcceptable = true;
                    for (int p_row = 0; p_row < p_rows; p_row++)
                    {
                        for (int p_col = 0; p_col < p_columns; p_col++)
                        {
                            if (Cells[(col + p_col) % Columns, (row + p_row) % Rows].IsAlive != ((pattern[p_row, p_col]==0)? false:true) && (pattern[p_row,p_col]!=2))
                            {
                                isAcceptable = false;
                                break;
                            }
                        }
                        if (!isAcceptable) break;
                    }
                    if (isAcceptable) 
                        count++;
                }
            }
            return count;
        }

        private byte[,] RotateMatrix (byte[,] mat)
        {
            int m_columns = mat.GetLength(1);
            int m_rows = mat.GetLength(0);
            byte[,] res = new byte[m_columns, m_rows];
            for (int row = 0; row < m_rows; row++)
            {
                for (int col = 0; col < m_columns; col++)
                {
                    res[col, (m_rows - row - 1)] = mat[row, col];
                }
            }
            return res;
        }
        public int CountPond()
        {
            byte[,] pattern = { { 2, 0, 0, 0, 0, 2},
                                 { 0, 0, 1, 1, 0, 0},
                                 { 0, 1, 0, 0, 1, 0},
                                 { 0, 1, 0, 0, 1, 0},
                                 { 0, 0, 1, 1, 0, 0},
                                 { 2, 0, 0, 0, 0, 2 } };
            
            return CountPattern(pattern);
        }

        public int CountHive()
        {
            byte[,] pattern = { { 2, 0, 0, 0, 2 },
                                { 0, 0, 1, 0, 0 },
                                { 0, 1, 0, 1, 0 },
                                { 0, 1, 0, 1, 0 },
                                { 0, 0, 1, 0, 0 },
                                { 2, 0, 0, 0, 2 } };
            return CountPattern(pattern)+CountPattern(RotateMatrix(pattern));

        }

        public int CountLoaf()
        {
            byte[,] pattern1 = { { 2, 0, 0, 0, 0, 2 },
                                 { 0, 0, 1, 1, 0, 0 },
                                 { 0, 1, 0, 0, 1, 0 },
                                 { 0, 0, 1, 0, 1, 0 },
                                 { 0, 0, 0, 1, 0, 0 },
                                 { 2, 0, 0, 0, 0, 2 } };

            byte[,] pattern2 = RotateMatrix(pattern1);

            byte[,] pattern3 = RotateMatrix(pattern2);

            byte[,] pattern4 = RotateMatrix(pattern3);
            return CountPattern(pattern1)+CountPattern(pattern2)+CountPattern(pattern3)+CountPattern(pattern4);

        }

        public int CountSnake()
        {
            byte[,] pattern1 = { { 0, 0, 0, 0, 0, 0 }, 
                                 { 0, 1, 0, 1, 1, 0 }, 
                                 { 0, 1, 1, 0, 1, 0 }, 
                                 { 0, 0, 0, 0, 0, 0 } };
            byte[,] pattern2 = { { 0, 0, 0, 0, 0, 0 },
                                 { 0, 1, 1, 0, 1, 0 },
                                 { 0, 1, 0, 1, 1, 0 },
                                 { 0, 0, 0, 0, 0, 0 } };

            return CountPattern(pattern1)+CountPattern(pattern2)+CountPattern(RotateMatrix(pattern1))+CountPattern(RotateMatrix(pattern2));
        }

        public int CountBarge()
        {
            byte[,] pattern = { { 2, 0, 0, 0, 2, 2 }, 
                                { 0, 0, 1, 0, 0, 2 }, 
                                { 0, 1, 0, 1, 0, 0 }, 
                                { 0, 0, 1, 0, 1, 0 }, 
                                { 2, 0, 0, 1, 0, 0 }, 
                                { 2, 2, 0, 0, 0, 2 } };
            return CountPattern(pattern)+CountPattern(RotateMatrix(pattern));

        }

        public int CountBoat()
        {
            byte[,] pattern1 = { { 2, 0, 0, 0, 2 }, 
                                 { 0, 0, 1, 0, 0 }, 
                                 { 0, 1, 0, 1, 0 }, 
                                 { 0, 0, 1, 1, 0 }, 
                                 { 2, 0, 0, 0, 0 } };
            byte[,] pattern2 = RotateMatrix(pattern1);

            byte[,] pattern3 = RotateMatrix(pattern2);

            byte[,] pattern4 = RotateMatrix(pattern3);
            return CountPattern(pattern1) + CountPattern(pattern2) + CountPattern(pattern3) + CountPattern(pattern4);

        }

        public int CountShip()
        {
            byte[,] pattern = { { 0, 0, 0, 0, 2 },
                                { 0, 1, 1, 0, 0 },
                                { 0, 1, 0, 1, 0 },
                                { 0, 0, 1, 1, 0 },
                                { 2, 0, 0, 0, 0 } };
            return CountPattern(pattern)+CountPattern(RotateMatrix(pattern));
        }

        public int CountLongBarge()
        {
            byte[,] pattern = { { 2, 0, 0, 0, 2, 2, 2 }, 
                                { 0, 0, 1, 0, 0, 2, 2 }, 
                                { 0, 1, 0, 1, 0, 0, 2 }, 
                                { 0, 0, 1, 0, 1, 0, 0 }, 
                                { 2, 0, 0, 1, 0, 1, 0 }, 
                                { 2, 2, 0, 0, 1, 0, 0 }, 
                                { 2, 2, 2, 0, 0, 0, 2 } };
            return CountPattern(pattern) + CountPattern(RotateMatrix(pattern));
        }
        

        public int CountLongBoat()
        {
            byte[,] pattern1 = { { 2, 0, 0, 0, 2, 2 }, 
                                 { 0, 0, 1, 0, 0, 2 }, 
                                 { 0, 1, 0, 1, 0, 0 }, 
                                 { 0, 0, 1, 0, 1, 0 }, 
                                 { 2, 0, 0, 1, 1, 0 }, 
                                 { 2, 2, 0, 0, 0, 0 } };
            byte[,] pattern2 = RotateMatrix(pattern1);

            byte[,] pattern3 = RotateMatrix(pattern2);

            byte[,] pattern4 = RotateMatrix(pattern3);
            return CountPattern(pattern1) + CountPattern(pattern2) + CountPattern(pattern3) + CountPattern(pattern4);

        }

        public int CountLongShip()
        {
            byte[,] pattern = { { 0, 0, 0, 0, 2, 2 }, 
                                { 0, 1, 1, 0, 0, 2 }, 
                                { 0, 1, 0, 1, 0, 0 }, 
                                { 0, 0, 1, 0, 1, 0 }, 
                                { 2, 0, 0, 1, 1, 0 }, 
                                { 2, 2, 0, 0, 0, 0 } };
            return CountPattern(pattern) + CountPattern(RotateMatrix(pattern));
        }

        public int CountBox()
        {
            byte[,] pattern = { { 2, 0, 0, 0, 2 }, 
                                { 0, 0, 1, 0, 0 }, 
                                { 0, 1, 0, 1, 0 }, 
                                { 0, 0, 1, 0, 0 }, 
                                { 2, 0, 0, 0, 2 } };
            return CountPattern(pattern);
        }

        public int CountBlock()
        {
            byte[,] pattern = { { 0, 0, 0, 0 }, 
                                { 0, 1, 1, 0 }, 
                                { 0, 1, 1, 0 }, 
                                { 0, 0, 0, 0 } };
            return CountPattern(pattern);
        }

        public int CountBlinker()
        {
            byte[,] pattern = { { 0, 0, 0, 0, 0 }, 
                                { 0, 1, 1, 1, 0 }, 
                                { 0, 0, 0, 0, 0 } };
            return CountPattern(pattern)+CountPattern(RotateMatrix(pattern));
        }

        public int CountCarrier()
        {
            byte[,] pattern1 = { { 0, 0, 0, 0, 2, 2 }, 
                                 { 0, 1, 1, 0, 0, 0 }, 
                                 { 0, 1, 0, 0, 1, 0 }, 
                                 { 0, 0, 0, 1, 1, 0 }, 
                                 { 2, 2, 0, 0, 0, 0 } };
            byte[,] pattern2 = { { 2, 2, 0, 0, 0, 0 },
                                 { 0, 0, 0, 1, 1, 0 },
                                 { 0, 1, 0, 0, 1, 0 },
                                 { 0, 1, 1, 0, 0, 0 },
                                 { 0, 0, 0, 0, 2, 2 } };
            return CountPattern(pattern1) + CountPattern(pattern2) + CountPattern(RotateMatrix(pattern1)) + CountPattern(RotateMatrix(pattern2));
        }

        public int CountAliveCells()
        {
            int count = 0;
            foreach(var cell in Cells)
            {
                if (cell.IsAlive) count++;
            }
            return count;
        }

        public double SymmetryVertical()
        {
            int count_of_indentical = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns/2; col++)
                {
                    if(Cells[col, row].IsAlive == Cells[Columns-col-1, row].IsAlive)
                    {
                        count_of_indentical+=2;
                    }
                }
            }
            return ((double)count_of_indentical / (Rows * Columns));
        }

        public double SymmetryHorizontal()
        {
            int count_of_indentical = 0;
            for (int row = 0; row < Rows/2; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (Cells[col, row].IsAlive == Cells[col, Rows-row-1].IsAlive)
                    {
                        count_of_indentical += 2;
                    }
                }
            }
            return ((double)count_of_indentical / (Rows * Columns));
        }

        public double SymmetryCentral()
        {
            int count_of_indentical = 0;
            for (int row = 0; row < Rows / 2; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (Cells[col, row].IsAlive == Cells[Columns - col - 1, Rows-row-1].IsAlive)
                    {
                        count_of_indentical += 2;
                    }
                }
            }
            return ((double)count_of_indentical / (Rows * Columns));
        }
    }
}
