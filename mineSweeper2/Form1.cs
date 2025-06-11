using System;
using System.Drawing;
using System.Windows.Forms;

namespace mineSweeper2
{
    public partial class Form1 : Form
    {
        private Board board;
        private ComboBox DifBox;
        private Label timerLabel;
        public Timer timer;
        private int seconds = 0;


        public Form1()
        {
            InitializeComponents();
            InitializeComponent();
            InitializeGame(new Easy());



        }
        private void InitializeComponents()
        {
            DifBox = new ComboBox();
            DifBox.Size = new Size(120, 80);
            DifBox.Font = new Font("Arial", 15, FontStyle.Bold);
            DifBox.Items.AddRange(new string[] { "Easy", "Medium", "Hard" });
            DifBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DifBox.Text = "Easy";
            DifBox.SelectedIndexChanged += DifBox_SelectedIndexChanged;
            Controls.Add(DifBox);

            timerLabel = new Label();
            timerLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            timerLabel.ForeColor = Color.Black;
            timerLabel.Location = new Point(365, 10);
            timerLabel.Text = "Time : 0";
            Controls.Add(timerLabel);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            timerLabel.Text = "Time : " + seconds;
        }

        private void resetTimer()
        {
            timerLabel.Text = "Time : 0";
            timerLabel.Location = new Point(this.Width - 150, 10);
            seconds = 0;
        }

        private void DifBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDifficulty = DifBox.SelectedItem.ToString();
            Difficulty difficulty = null;
            switch (selectedDifficulty)
            {
                case "Easy":
                    difficulty = new Easy();
                    break;
                case "Medium":
                    difficulty = new Medium();
                    break;
                case "Hard":
                    difficulty = new Hard();
                    break;
            }
            if (difficulty != null)
            {
                InitializeGame(difficulty);
                resetTimer();
            }
        }

        private void InitializeGame(Difficulty difficult)
        {


            if (board != null && board.GamePanel != null)
            {
                Controls.Remove(board.GamePanel);
                board.GamePanel.Dispose();
            }

            int rows = difficult.Rows;
            int columns = difficult.Columns;
            int mines = difficult.Mines;

            timer.Stop();
            timer.Start();

            board = new Board(rows, columns, mines, timer);
            board.GamePanel.Location = new Point(0, 40);
            Controls.Add(board.GamePanel);

            this.Size = new Size(board.GamePanel.Width + 15, board.GamePanel.Height + 80);
        }

    }
}