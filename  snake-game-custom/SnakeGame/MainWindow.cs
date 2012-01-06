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
    public bool   isGameOver  = false;   // Bool value to indicate Game Over status   (Not Game Over at the beginning)
    public bool   isPause     = true;    // Bool value to indicate Pause status       (Pause at the beginning)
    public bool   waitForTick = false;   // Bool value to wait for the next tick before key sensing

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
        Size = new Size(iSnakeBoxSize - 2, iSnakeBoxSize - 2);
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
        Point wSnakePosition = new Point(_drawingRef.Width/2, _drawingRef.Height/2);

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

        if (selfDeath)
          for (int index = 1; index < AllBoxes.Count; index++)
          {
            BoxOfSnake box = AllBoxes[index];
            if (AllBoxes[0].Position == box.Position)
              isGameOver = true;
          }

        // If Outside of box
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
        ActualTreat.Position.Offset(new Point(-wDifference, -wDifference));
        ActualTreat.Size += new Size(wDifference, wDifference);

        // Offset the first box of the difference in both directions
        AllBoxes[0].Position.Offset(new Point(-wDifference, -wDifference));
        AllBoxes[0].Size = new Size(iSnakeBoxSize, iSnakeBoxSize);
        BoxOfSnake wFirstBoxOfSnake = AllBoxes[0];

        // List the directions of all the next boxes in the actual snake
        var wNextBoxDirection = new List<Direction>();
        Point wLastBoxPosition = AllBoxes[0].Position;
        for (int index = 1; index < AllBoxes.Count; index++)
        {
          BoxOfSnake box = AllBoxes[index];
          if (box.Position.Y > wLastBoxPosition.Y)
            wNextBoxDirection.Add(Direction.UP);
          else if (box.Position.Y < wLastBoxPosition.Y)
            wNextBoxDirection.Add(Direction.DOWN);
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

      // Print the treat
      gfx.DrawEllipse(myPen, new Rectangle(ActualSnake.ActualTreat.Position.X - ActualSnake.ActualTreat.Size.Width / 2,
                                           ActualSnake.ActualTreat.Position.Y - ActualSnake.ActualTreat.Size.Height / 2,
                                           ActualSnake.ActualTreat.Size.Width,
                                           ActualSnake.ActualTreat.Size.Height
                                           ));

      // Print the snake
      foreach (BoxOfSnake box in ActualSnake.AllBoxes)
        gfx.DrawRectangle(myPen, box.Position.X - ActualSnake.SnakeBoxSize / 2, box.Position.Y - ActualSnake.SnakeBoxSize / 2, box.Size.Width, box.Size.Height);
    }

    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
      bool isNewState = false;
      if(!waitForTick)
        switch (e.KeyCode)
        {
          case Keys.W:
            if (ActualSnake.SnakeDirection != Direction.DOWN)
              ActualSnake.SnakeDirection = Direction.UP;
            break;
          case Keys.A:
            if (ActualSnake.SnakeDirection != Direction.RIGHT)
              ActualSnake.SnakeDirection = Direction.LEFT;
            break;
          case Keys.S:
            if (ActualSnake.SnakeDirection != Direction.UP)
              ActualSnake.SnakeDirection = Direction.DOWN;
            break;
          case Keys.D:
            if (ActualSnake.SnakeDirection != Direction.LEFT)
              ActualSnake.SnakeDirection = Direction.RIGHT;
            break;
          case Keys.P:
            Timer_SpeedOfPlay.Enabled = false;
            isPause = true;
            isNewState = true;
            labelPause.Visible = true;
            break;
        }

      if (isGameOver)
      {
        ActualSnake = new Snake(3, ref DrawingZone, (int) numericUpDownSnakeBoxSize.Value);
        labelGameOver.Visible = false;
        isGameOver = false;
        DrawingZone.Refresh();
      }

      else if (isPause && !isNewState)
      {
        Timer_SpeedOfPlay.Enabled = true;
        labelPause.Visible = false;
        isPause = false;
      }
      waitForTick = true;
    }

    static public Point RandomPoint(int DrawingZoneSize, int SnakeBoxSize)
    {
      int minimum = 1;
      int maximum = DrawingZoneSize / SnakeBoxSize - 1;
      Random random = new Random();
      Point newPoint = new Point(random.Next(minimum, maximum) * SnakeBoxSize, random.Next(minimum, maximum) * SnakeBoxSize);
      return newPoint;
    }

    private void Timer_SpeedOfPlay_Tick(object sender, EventArgs e)
    {
      waitForTick = false;
      ActualSnake.Move(radioButtonBorderDeathOFF.Checked);
      textBox_Score.Text = ActualSnake.Points.ToString();

      if (ActualSnake.isGameOver(radioButtonBorderDeathON.Checked, radioButtonOnSelfDeathON.Checked))
      {
        Timer_SpeedOfPlay.Enabled = false;  // Stop the timer to pause the game
        isGameOver                = true;   // Set isGameOver value for verification elsewhere
        isPause                   = true;   // Set isPause value for pause after Game Over recovery
        labelGameOver.Visible     = true;   // Show the "Game Over Bitch" Label
      }

      DrawingZone.Refresh();
    }

    private void SpeedChanged(object sender, EventArgs e)
    {
      Timer_SpeedOfPlay.Interval = (int) (1000 / ((NumericUpDown) sender).Value);
    }

    private void SnakeBoxSizeChanged(object sender, EventArgs e)
    {
      Timer_SpeedOfPlay.Enabled = false;
      ActualSnake.updateSize((int) numericUpDownSnakeBoxSize.Value);
      DrawingZone.Refresh();
      Timer_SpeedOfPlay.Enabled = true;
    }
  }
}
