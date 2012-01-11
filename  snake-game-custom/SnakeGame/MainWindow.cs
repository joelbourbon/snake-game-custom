using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeGame
{
  public partial class MainWindow : Form
  {
    public Snake  ActualSnake;
    public bool   isGameOver    = false;   // Bool value to indicate Game Over status   (Not Game Over at the beginning)
    public bool   isPause       = true;    // Bool value to indicate Pause status       (Pause at the beginning)
    public bool   waitForTick   = false;   // Bool value to wait for the next tick before key sensing

    // Static int for the random generator to be different with 2 sequential demands
    static public int    incrementSeed = 1;

    public enum Direction
    {
      UP    = 1,
      DOWN  = 2,
      RIGHT = 3,
      LEFT  = 4
    }

    public enum PositionInSnake
    {
      HEAD      = 0,
      TAIL      = 1,
      MIDDLE    = 2
    }

    public class BoxOfSnake
    {
      public BoxOfSnake(Point iPosition, int iSnakeBoxSize)
      {
        Position = iPosition;
        Size = new Size(iSnakeBoxSize, iSnakeBoxSize);
      }

      public Point  Position;
      public Size   Size;
    }

    public class Treat
    {
      public Treat(Point iPosition, int iSnakeBoxSize)
      {
        Position = iPosition;
        Size = new Size(iSnakeBoxSize, iSnakeBoxSize);
      }

      public Point Position;
      public Size Size;
    }

    public class Snake
    {
      private PictureBox _drawingRef;
      public int SnakeBoxSize;
      public Direction SnakeDirection = Direction.UP;
      public List<BoxOfSnake> AllBoxes= new List<BoxOfSnake>();
      public Treat ActualTreat;
      public UInt16 Points;

      public Snake(UInt16 iSnakeLength, ref PictureBox iDrawingRef, int iSnakeBoxSize)
      {
        _drawingRef = iDrawingRef;
        SnakeBoxSize = iSnakeBoxSize;

        // Calculate the snake initial position depending of it's size
        // **May look ridiculous but with the int approximation the result is significant**
        //int wInitPos = (_drawingRef.Width/iSnakeBoxSize) / 2 * iSnakeBoxSize;
        Point wSnakePosition = RandomPoint(_drawingRef.Width, SnakeBoxSize);

        // Create the initial boxes to form the snake
        AllBoxes.Insert(0, new BoxOfSnake(wSnakePosition, iSnakeBoxSize));
        for(int i = 0; i < iSnakeLength - 1; i++)
          AppendBox(Direction.DOWN, PositionInSnake.TAIL);

        // Init a first treat at a random position
        ActualTreat = new Treat(RandomPoint(_drawingRef.Width, SnakeBoxSize), SnakeBoxSize);
      }

      private void AppendBox(Direction iDirection, PositionInSnake iPositionInSnake)
      {
        var newBox = new BoxOfSnake(iPositionInSnake == PositionInSnake.HEAD ? AllBoxes.First().Position : AllBoxes.Last().Position, SnakeBoxSize);

        if (iDirection == Direction.LEFT || iDirection == Direction.RIGHT)
          newBox.Position.X = iDirection == Direction.LEFT
                                     ? newBox.Position.X - SnakeBoxSize
                                     : newBox.Position.X + SnakeBoxSize;
        else
          newBox.Position.Y = iDirection == Direction.UP
                                     ? newBox.Position.Y - SnakeBoxSize
                                     : newBox.Position.Y + SnakeBoxSize;

        if(iPositionInSnake == PositionInSnake.HEAD)
          AllBoxes.Insert(0, newBox);
        else
          AllBoxes.Add(newBox);
      }

      public void Move(bool LoopBorder)
      {
        AppendBox(SnakeDirection, PositionInSnake.HEAD);

        if (LoopBorder)
        {
          if (AllBoxes.First().Position.X >= _drawingRef.Width)
            AllBoxes.First().Position.X = SnakeBoxSize;
          else if (AllBoxes.First().Position.X <= 0)
            AllBoxes.First().Position.X = _drawingRef.Width - SnakeBoxSize;
          else if (AllBoxes.First().Position.Y >= _drawingRef.Height)
            AllBoxes.First().Position.Y = SnakeBoxSize;
          else if (AllBoxes.First().Position.Y <= 0)
            AllBoxes.First().Position.Y = _drawingRef.Height - SnakeBoxSize;
        }

        if (AllBoxes[0].Position == ActualTreat.Position)
        {
          ++Points;
          ActualTreat.Position = RandomPoint(_drawingRef.Width, SnakeBoxSize);
        }
        else
          AllBoxes.RemoveAt(AllBoxes.Count - 1);
      }

      public bool isGameOver(bool borderDeath, bool selfDeath)
      {
        bool isGameOver = false;

        // If passing on himself and not allowed to
        if (selfDeath)
          for (int index = 1; index < AllBoxes.Count; index++)
          {
            BoxOfSnake box = AllBoxes[index];
            if (AllBoxes[0].Position == box.Position)
              isGameOver = true;
          }

        // If Outside of box and not allowed to
        if ( (  AllBoxes[0].Position.X >= _drawingRef.Width || AllBoxes[0].Position.X <= 0
             || AllBoxes[0].Position.Y >= _drawingRef.Height || AllBoxes[0].Position.Y <= 0) 
             && borderDeath)
          isGameOver = true;

        return isGameOver;
      }

      public void updateSize(int iSnakeBoxSize)
      {
        // Calculate the difference in size
        int wDifference = iSnakeBoxSize - SnakeBoxSize;
        SnakeBoxSize = iSnakeBoxSize;

        // Offset the treat by the difference in both directions
        ActualTreat.Position.Offset(new Point(-wDifference / 2, -wDifference / 2));
        ActualTreat.Size += new Size(wDifference, wDifference);

        // Offset the first box of the difference in both directions
        AllBoxes[0].Position.Offset(new Point(-wDifference / 2, -wDifference / 2));
        AllBoxes[0].Size = new Size(iSnakeBoxSize, iSnakeBoxSize);
        BoxOfSnake wFirstBoxOfSnake = AllBoxes[0];

        // List the directions of all the next boxes in the actual snake
        var wNextBoxDirection = new List<Direction>();
        Point wLastBoxPosition = AllBoxes[0].Position;
        for (int index = 1; index < AllBoxes.Count; index++)
        {
          BoxOfSnake box = AllBoxes[index];
          if      (box.Position.Y > wLastBoxPosition.Y)
            wNextBoxDirection.Add(Direction.DOWN);
          else if (box.Position.Y < wLastBoxPosition.Y)
            wNextBoxDirection.Add(Direction.UP);
          else if (box.Position.X < wLastBoxPosition.X)
            wNextBoxDirection.Add(Direction.LEFT);
          else
            wNextBoxDirection.Add(Direction.RIGHT);
          wLastBoxPosition = box.Position;
        }

        // Clear the list of boxes and repopulate it with the new boxes
        AllBoxes.Clear();
        AllBoxes.Add(wFirstBoxOfSnake);
        foreach (Direction Direction in wNextBoxDirection)
          AppendBox(Direction, PositionInSnake.TAIL);
      }
    }

    public MainWindow()
    {
      InitializeComponent();

      ActualSnake = new Snake(3, ref DrawingZone, (int)numericUpDownSnakeBoxSize.Value);
      DrawingZone.BackColor = Color.White;
      numericUpDown_Speed.Value = 25;
      labelGameOver.Visible = false;
      labelPause.Visible = false;
    }

    private void DrawingZone_Paint(object sender, PaintEventArgs e)
    {
      // Get the graphics object 
      Graphics gfx = e.Graphics; 

      // Create a new pen that we shall use for drawing the line 
      var myPen = new Pen(Color.Black);
      var treatBrush = new SolidBrush(Color.Red);
      var snakeBrush = new SolidBrush(Color.GreenYellow);

      // Print the treat
      gfx.FillEllipse(treatBrush, new Rectangle(ActualSnake.ActualTreat.Position.X - ActualSnake.ActualTreat.Size.Width / 2,
                                                ActualSnake.ActualTreat.Position.Y - ActualSnake.ActualTreat.Size.Height / 2,
                                                ActualSnake.ActualTreat.Size.Width,
                                                ActualSnake.ActualTreat.Size.Height
                                                ));

      // Print the snake
      foreach (BoxOfSnake box in ActualSnake.AllBoxes)
        gfx.FillRectangle(snakeBrush, box.Position.X - ActualSnake.SnakeBoxSize / 2, box.Position.Y - ActualSnake.SnakeBoxSize / 2, box.Size.Width, box.Size.Height);
    }

    //
    //  Method that handles all the pressed keys in the application (MainWindow with KeyPreview)
    //
    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
      // Necessary state to avoid Pause State overrides
      bool isNewState = false;

      // Verify that a Game Tick passed since the last pressed key
      if(!waitForTick)
        switch (e.KeyCode)
        {
          // "W" Is the UP key for the snake direction control
          case Keys.W:
            if (ActualSnake.SnakeDirection != Direction.DOWN)
              ActualSnake.SnakeDirection = Direction.UP;
            break;
          // "W" Is the LEFT key for the snake direction control
          case Keys.A:
            if (ActualSnake.SnakeDirection != Direction.RIGHT)
              ActualSnake.SnakeDirection = Direction.LEFT;
            break;
          // "W" Is the DOWN key for the snake direction control
          case Keys.S:
            if (ActualSnake.SnakeDirection != Direction.UP)
              ActualSnake.SnakeDirection = Direction.DOWN;
            break;
          // "W" Is the RIGHT key for the snake direction control
          case Keys.D:
            if (ActualSnake.SnakeDirection != Direction.LEFT)
              ActualSnake.SnakeDirection = Direction.RIGHT;
            break;
          // "P" Is the PAUSE key for the game
          case Keys.P:
            Timer_SpeedOfPlay.Enabled = false;  // Stop the playing timer
            isPause = true;                     // Enable the pause state
            isNewState = true;                  // Avoid further Pause State override
            labelPause.Visible = true;          // Display the "Pause" banner
            break;
        }

      // GameOver state handling
      if (isGameOver)
      {
        ActualSnake = new Snake(3, ref DrawingZone, (int) numericUpDownSnakeBoxSize.Value);
        labelGameOver.Visible = false;
        isGameOver = false;
        incrementSeed = 0; // Reset the increment to avoid getting stuck to the max
        DrawingZone.Refresh();
      }

      // Pause state handling if not game over
      else if (isPause && !isNewState)
      {
        Timer_SpeedOfPlay.Enabled = true;
        labelPause.Visible = false;
        isPause = false;
      }

      // Setting the validation bool for the wait for tick
      waitForTick = true;
    }

    //
    //  Method to generate a random point inside the drawing zone and accessible by the snake
    //
    static public Point RandomPoint(int drawingZoneSize, int snakeBoxSize)
    {
      // Define the Min/Max of the position multiplier
      int minimum = 0;
      int maximum = (drawingZoneSize / snakeBoxSize) - 1;

      // Calculate the minimum position constant
      int wCoordConstant = ((snakeBoxSize - 1) / 2) + 1;

      // Initialize and use a random generator to create and return the new point
      Random random = new Random(incrementSeed);
      incrementSeed++;
      Point newPoint = new Point(random.Next(minimum, maximum) * snakeBoxSize + wCoordConstant,  // X
                                 random.Next(minimum, maximum) * snakeBoxSize + wCoordConstant   // Y
                                 );
      return newPoint;
    }

    private void Timer_SpeedOfPlay_Tick(object sender, EventArgs e)
    {
      // A tick is actually done --> Reset the waiting
      waitForTick = false;

      // Move the snake
      ActualSnake.Move(radioButtonBorderDeathOFF.Checked);
      // Refresh score
      textBox_Score.Text = ActualSnake.Points.ToString();

      // Verify conditions for the snake to die (Depending on the desired options)
      if (ActualSnake.isGameOver(radioButtonBorderDeathON.Checked, radioButtonOnSelfDeathON.Checked))
      {
        Timer_SpeedOfPlay.Enabled = false;  // Stop the timer to pause the game
        isGameOver                = true;   // Set isGameOver value for verification elsewhere
        isPause                   = true;   // Set isPause value for pause after Game Over recovery
        labelGameOver.Visible     = true;   // Show the "Game Over Bitch" Label
      }

      // Refresh display with the new state
      DrawingZone.Refresh();
    }

    private void SpeedChanged(object sender, EventArgs e)
    {
      // Change the speed of play according to the value asked with the numeric Up/Down
      Timer_SpeedOfPlay.Interval = (int) (1000 / ((NumericUpDown) sender).Value);
    }

    private void SnakeBoxSizeChanged(object sender, EventArgs e)
    {
      bool turnBackOnTimer = false;
      // Disable the playing timer
      if (Timer_SpeedOfPlay.Enabled)
      {
        Timer_SpeedOfPlay.Enabled = false;
        turnBackOnTimer = true;
      }

      // Update size of the snake to the desired size
      ActualSnake.updateSize((int) numericUpDownSnakeBoxSize.Value);
      DrawingZone.Refresh();

      // Resume the playing timer
      if(turnBackOnTimer)
        Timer_SpeedOfPlay.Enabled = true;
    }
  }
}
