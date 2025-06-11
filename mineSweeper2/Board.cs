
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace mineSweeper2
{
    public class Board
    {

        private int rows;
        private int columns;
        private int mineCount;
        private int revealedCellsCount = 0;
        private Cell[,] cells;
        private Timer t;


        public Panel GamePanel { get; private set; }

        private Random random = new Random();

        public Board(int rows, int columns, int mineCount, Timer timer)
        {
            this.rows = rows;
            this.columns = columns;
            this.mineCount = mineCount;
            t = timer;

            cells = new Cell[rows, columns];

            GamePanel = new Panel();
            GamePanel.Size = new Size(columns * 50, rows * 50);


            InitializeCells();
            PlaceMines();
            CalculateAdjacentMineCounts();


        }


        private void InitializeCells()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Cell cell = new Cell(row, col);
                    cell.Location = new Point(col * 50, row * 50);
                    cell.Click += OnCellClick;
                    cell.MouseDown += Cell_MouseDown;

                    cells[row, col] = cell;
                    GamePanel.Controls.Add(cell);
                }
            }
        }

        private void PlaceMines()
        {
            int placedMines = 0;

            while (placedMines < mineCount)
            {
                int row = random.Next(rows);
                int col = random.Next(columns);

                if (!cells[row, col].IsMine)
                {
                    cells[row, col].IsMine = true;
                    placedMines++;
                }
            }
        }

        private void CalculateAdjacentMineCounts()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (!cells[row, col].IsMine)
                    {
                        int count = CountAdjacentMines(row, col);
                        cells[row, col].AdjacentMines = count;
                    }
                }
            }
        }

        private int CountAdjacentMines(int row, int col)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int r = row + i;
                    int c = col + j;

                    if (r >= 0 && r < rows && c >= 0 && c < columns)
                    {
                        if (cells[r, c].IsMine)
                            count++;
                    }
                }
            }

            return count;
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            Cell clickedCell = sender as Cell;

            if (clickedCell.IsFlagged)
                return;

            if (clickedCell.IsMine)
            {
                clickedCell.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "mine.jpg"));
                FinishGame(false);
            }
            else
            {
                RevealCell(clickedCell.Row, clickedCell.Column);
            }
        }
        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            Cell rClickedCell = sender as Cell;
            if (e.Button == MouseButtons.Right)
            {
                if (!rClickedCell.IsRevealed)
                {
                    if (!rClickedCell.IsFlagged)
                    {
                        rClickedCell.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "flag.jpg"));
                        rClickedCell.IsFlagged = true;
                    }
                    else
                    {
                        rClickedCell.Text = "";
                        rClickedCell.IsFlagged = false;
                        rClickedCell.Image = null;
                    }
                }
            }
        }


        private void RevealCell(int row, int col)
        {
            Cell cell = cells[row, col];

            if (cell.IsRevealed || cell.IsFlagged)
                return;

            cell.IsRevealed = true;
            cell.Enabled = false;
            revealedCellsCount++;
            cell.BackColor = Color.DimGray;
            CheckWinCondition();

            if (cell.AdjacentMines > 0)
            {
                cell.Text = cell.AdjacentMines.ToString();



            }
            else
            {

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int r = row + i;
                        int c = col + j;

                        if (r >= 0 && r < rows && c >= 0 && c < columns)
                        {
                            RevealCell(r, c);
                        }
                    }
                }
            }
        }

        private void FinishGame(bool isWin)
        {
            passiveAllCells();
            t.Stop();
            if (isWin)
            {
                MessageBox.Show("Congratulations! You won the game!");
            }
            else
            {
                RevealAllMines();
                MessageBox.Show("Game Over! You hit a mine!");
            }
        }
        private void CheckWinCondition()
        {
            if (revealedCellsCount + mineCount == rows * columns)
            {
                FinishGame(true);

            }
        }

        private void RevealAllMines()
        {
            foreach (Cell cell in cells)
            {
                if (cell.IsMine)
                {
                    cell.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "mine.jpg"));
                }
            }
        }
        private void passiveAllCells()
        {
            foreach (Cell cell in cells)
            {
                cell.Click -= OnCellClick;
                cell.MouseDown -= Cell_MouseDown;
            }
        }
    }
}


