namespace SnakeGame
{
  partial class MainWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.DrawingZone = new System.Windows.Forms.PictureBox();
      this.numericUpDown_Speed = new System.Windows.Forms.NumericUpDown();
      this.LabelSpeed = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox_Score = new System.Windows.Forms.TextBox();
      this.Timer_SpeedOfPlay = new System.Windows.Forms.Timer(this.components);
      this.labelGameOver = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.radioButtonBorderDeathON = new System.Windows.Forms.RadioButton();
      this.radioButtonBorderDeathOFF = new System.Windows.Forms.RadioButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.radioButtonOnSelfDeathON = new System.Windows.Forms.RadioButton();
      this.radioButtonOnSelfDeathOFF = new System.Windows.Forms.RadioButton();
      this.labelPause = new System.Windows.Forms.Label();
      this.TimeCounter = new System.Windows.Forms.Timer(this.components);
      this.numericUpDownSnakeBoxSize = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.DrawingZone)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Speed)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSnakeBoxSize)).BeginInit();
      this.SuspendLayout();
      // 
      // DrawingZone
      // 
      this.DrawingZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.DrawingZone.Location = new System.Drawing.Point(12, 12);
      this.DrawingZone.Name = "DrawingZone";
      this.DrawingZone.Size = new System.Drawing.Size(660, 660);
      this.DrawingZone.TabIndex = 0;
      this.DrawingZone.TabStop = false;
      this.DrawingZone.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      // 
      // numericUpDown_Speed
      // 
      this.numericUpDown_Speed.Location = new System.Drawing.Point(837, 62);
      this.numericUpDown_Speed.Name = "numericUpDown_Speed";
      this.numericUpDown_Speed.Size = new System.Drawing.Size(120, 20);
      this.numericUpDown_Speed.TabIndex = 1;
      this.numericUpDown_Speed.ValueChanged += new System.EventHandler(this.SpeedChanged);
      // 
      // LabelSpeed
      // 
      this.LabelSpeed.AutoSize = true;
      this.LabelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabelSpeed.Location = new System.Drawing.Point(688, 64);
      this.LabelSpeed.Name = "LabelSpeed";
      this.LabelSpeed.Size = new System.Drawing.Size(56, 20);
      this.LabelSpeed.TabIndex = 2;
      this.LabelSpeed.Text = "Speed";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(688, 91);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 20);
      this.label2.TabIndex = 3;
      this.label2.Text = "Score";
      // 
      // textBox_Score
      // 
      this.textBox_Score.Location = new System.Drawing.Point(837, 88);
      this.textBox_Score.Name = "textBox_Score";
      this.textBox_Score.Size = new System.Drawing.Size(120, 20);
      this.textBox_Score.TabIndex = 4;
      // 
      // Timer_SpeedOfPlay
      // 
      this.Timer_SpeedOfPlay.Interval = 250;
      this.Timer_SpeedOfPlay.Tick += new System.EventHandler(this.Timer_SpeedOfPlay_Tick);
      // 
      // labelGameOver
      // 
      this.labelGameOver.AutoSize = true;
      this.labelGameOver.BackColor = System.Drawing.Color.Transparent;
      this.labelGameOver.Font = new System.Drawing.Font("Goudy Stout", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.labelGameOver.Location = new System.Drawing.Point(19, 318);
      this.labelGameOver.Name = "labelGameOver";
      this.labelGameOver.Size = new System.Drawing.Size(646, 48);
      this.labelGameOver.TabIndex = 5;
      this.labelGameOver.Text = "GAME OVER BITCH";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(688, 111);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(118, 20);
      this.label1.TabIndex = 3;
      this.label1.Text = "Border = Death";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(688, 131);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(119, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "OnSelf = Death";
      // 
      // radioButtonBorderDeathON
      // 
      this.radioButtonBorderDeathON.AutoSize = true;
      this.radioButtonBorderDeathON.Checked = true;
      this.radioButtonBorderDeathON.Location = new System.Drawing.Point(0, 3);
      this.radioButtonBorderDeathON.Name = "radioButtonBorderDeathON";
      this.radioButtonBorderDeathON.Size = new System.Drawing.Size(41, 17);
      this.radioButtonBorderDeathON.TabIndex = 6;
      this.radioButtonBorderDeathON.TabStop = true;
      this.radioButtonBorderDeathON.Text = "ON";
      this.radioButtonBorderDeathON.UseVisualStyleBackColor = true;
      // 
      // radioButtonBorderDeathOFF
      // 
      this.radioButtonBorderDeathOFF.AutoSize = true;
      this.radioButtonBorderDeathOFF.Location = new System.Drawing.Point(75, 3);
      this.radioButtonBorderDeathOFF.Name = "radioButtonBorderDeathOFF";
      this.radioButtonBorderDeathOFF.Size = new System.Drawing.Size(45, 17);
      this.radioButtonBorderDeathOFF.TabIndex = 6;
      this.radioButtonBorderDeathOFF.Text = "OFF";
      this.radioButtonBorderDeathOFF.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.radioButtonBorderDeathON);
      this.panel1.Controls.Add(this.radioButtonBorderDeathOFF);
      this.panel1.Location = new System.Drawing.Point(837, 111);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(120, 21);
      this.panel1.TabIndex = 8;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.radioButtonOnSelfDeathON);
      this.panel2.Controls.Add(this.radioButtonOnSelfDeathOFF);
      this.panel2.Location = new System.Drawing.Point(837, 131);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(120, 21);
      this.panel2.TabIndex = 8;
      // 
      // radioButtonOnSelfDeathON
      // 
      this.radioButtonOnSelfDeathON.AutoSize = true;
      this.radioButtonOnSelfDeathON.Checked = true;
      this.radioButtonOnSelfDeathON.Location = new System.Drawing.Point(0, 3);
      this.radioButtonOnSelfDeathON.Name = "radioButtonOnSelfDeathON";
      this.radioButtonOnSelfDeathON.Size = new System.Drawing.Size(41, 17);
      this.radioButtonOnSelfDeathON.TabIndex = 6;
      this.radioButtonOnSelfDeathON.TabStop = true;
      this.radioButtonOnSelfDeathON.Text = "ON";
      this.radioButtonOnSelfDeathON.UseVisualStyleBackColor = true;
      // 
      // radioButtonOnSelfDeathOFF
      // 
      this.radioButtonOnSelfDeathOFF.AutoSize = true;
      this.radioButtonOnSelfDeathOFF.Location = new System.Drawing.Point(75, 3);
      this.radioButtonOnSelfDeathOFF.Name = "radioButtonOnSelfDeathOFF";
      this.radioButtonOnSelfDeathOFF.Size = new System.Drawing.Size(45, 17);
      this.radioButtonOnSelfDeathOFF.TabIndex = 6;
      this.radioButtonOnSelfDeathOFF.Text = "OFF";
      this.radioButtonOnSelfDeathOFF.UseVisualStyleBackColor = true;
      // 
      // labelPause
      // 
      this.labelPause.AutoSize = true;
      this.labelPause.BackColor = System.Drawing.Color.Transparent;
      this.labelPause.Font = new System.Drawing.Font("Goudy Stout", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelPause.ForeColor = System.Drawing.Color.Black;
      this.labelPause.Location = new System.Drawing.Point(227, 318);
      this.labelPause.Name = "labelPause";
      this.labelPause.Size = new System.Drawing.Size(230, 48);
      this.labelPause.TabIndex = 5;
      this.labelPause.Text = "PAUSE";
      // 
      // TimeCounter
      // 
      this.TimeCounter.Interval = 1000;
      // 
      // numericUpDownSnakeBoxSize
      // 
      this.numericUpDownSnakeBoxSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this.numericUpDownSnakeBoxSize.Location = new System.Drawing.Point(837, 158);
      this.numericUpDownSnakeBoxSize.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
      this.numericUpDownSnakeBoxSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.numericUpDownSnakeBoxSize.Name = "numericUpDownSnakeBoxSize";
      this.numericUpDownSnakeBoxSize.ReadOnly = true;
      this.numericUpDownSnakeBoxSize.Size = new System.Drawing.Size(120, 20);
      this.numericUpDownSnakeBoxSize.TabIndex = 1;
      this.numericUpDownSnakeBoxSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.numericUpDownSnakeBoxSize.ValueChanged += new System.EventHandler(this.SnakeBoxSizeChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(688, 160);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(121, 20);
      this.label4.TabIndex = 2;
      this.label4.Text = "Snake Box Size";
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1047, 693);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.labelPause);
      this.Controls.Add(this.labelGameOver);
      this.Controls.Add(this.textBox_Score);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.LabelSpeed);
      this.Controls.Add(this.numericUpDownSnakeBoxSize);
      this.Controls.Add(this.numericUpDown_Speed);
      this.Controls.Add(this.DrawingZone);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "MainWindow";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Snake Game";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.DrawingZone)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Speed)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSnakeBoxSize)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox DrawingZone;
    private System.Windows.Forms.NumericUpDown numericUpDown_Speed;
    private System.Windows.Forms.Label LabelSpeed;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox_Score;
    private System.Windows.Forms.Timer Timer_SpeedOfPlay;
    private System.Windows.Forms.Label labelGameOver;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.RadioButton radioButtonBorderDeathON;
    private System.Windows.Forms.RadioButton radioButtonBorderDeathOFF;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.RadioButton radioButtonOnSelfDeathON;
    private System.Windows.Forms.RadioButton radioButtonOnSelfDeathOFF;
    private System.Windows.Forms.Label labelPause;
    private System.Windows.Forms.Timer TimeCounter;
    private System.Windows.Forms.NumericUpDown numericUpDownSnakeBoxSize;
    private System.Windows.Forms.Label label4;
  }
}

