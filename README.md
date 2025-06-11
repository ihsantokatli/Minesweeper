
# 🎲 Minesweeper (C# WinForms)

A personal spin on the classic **Minesweeper** puzzle—built from scratch in C# using Windows Forms. Originally developed as a desktop project during my Computer Engineering studies, this version keeps the core gameplay intact while giving you three difficulty tiers, a running timer, and tidy, modular code.

---


## 📋 Features

- **Three Difficulty Levels**  
  Easy (9×9, 10 mines), Medium (16×16, 40 mines), Hard (30×16, 99 mines)  
  Switch on the fly from the combo-box at the top.

- **Live Game Timer**  
  Starts at 0 and ticks up every second—perfect for chasing your best time.

- **Flagging Mode**  
  Right-click (or use the flag button) to mark suspicious tiles before you clear them.

- **Dynamic Board Generation**  
  The grid and mine placement rebuild instantly when you change difficulty.

- **Clean, OOP-Driven Code**  
  `Board.cs` handles all grid logic, `Difficulty` subclasses define rows/mines, and `Form1.cs` orchestrates UI & timer.

---

## 🚀 Getting Started

1. **Clone the repo**  
   ```bash
   git clone https://github.com/ihsantokatli/Minesweeper.git
     ````

2. **Open the solution**
   Launch `mineSweeper2.sln` in Visual Studio 2019 (or later).

3. **Build & Run**
   Press F5 or click **Start**. The game window appears immediately.

4. **Play**

   * Select “Easy”, “Medium” or “Hard” from the top combo box.
   * Left-click to reveal a tile.
   * Right-click to place or remove a flag.
   * Watch the timer in the upper-right corner!

---

## 📂 Project Structure

```
Minesweeper/
├── mineSweeper2.sln        # Visual Studio solution
├── mineSweeper2/           # WinForms project
│   ├── Form1.cs            # Main form (UI + event wiring)
│   ├── Board.cs            # Grid generation & mine logic
│   ├── Difficulty.cs       # Abstract base class
│   ├── Easy.cs             # Easy settings
│   ├── Medium.cs           # Medium settings
│   ├── Hard.cs             # Hard settings
│   ├── Resources/          # Images used in the game
│   │   ├── mine.jpg
│   │   └── flag.jpg
│   └── Program.cs          # Entry point
├── .gitignore              # Ignored files & folders
└── README.md               # ← You are here
```

---

## 🔧 How It Works

1. **On launch**, Form1 creates a `Board` instance using the default difficulty.
2. **Board** generates a 2D array of tiles, randomly places mines, and builds a `Panel` of buttons.
3. **Timer** in `Form1` starts on the first click and stops when you hit a mine or clear all safe tiles.
4. **Difficulty changes** dispose the existing board panel, rebuild it with new dimensions, and reset the timer.

---

### ✅ Gameplay Win Condition
![minesweepergif](https://github.com/user-attachments/assets/f7f0d8e2-7fd5-496d-bf63-89f7d38992ca)

### ❌ Gameplay Lose Condition
![mslosegif](https://github.com/user-attachments/assets/09d9eae1-2515-4aa9-b64f-ab3bb91b1f91)

## 🌱 Future Improvements

* **Leaderboard**: Track and display top scores per difficulty.
* **Sound effects**: Add click and explosion sounds.
* **Right-click UX**: Alternate between flag/place modes.
* **Custom themes**: Dark mode or alternative color schemes.

---

**Author**: İhsan Tokatlı
Computer Engineering Student | [GitHub Profile](https://github.com/ihsantokatli)
