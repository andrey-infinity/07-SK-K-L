namespace Labirints
{
    partial class MainForm
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
            this.MapOpen = new System.Windows.Forms.OpenFileDialog();
            this.LeftPan = new System.Windows.Forms.Panel();
            this.ShowPan = new System.Windows.Forms.Panel();
            this.Solve = new System.Windows.Forms.Button();
            this.CanSolve = new System.Windows.Forms.Label();
            this.Open = new System.Windows.Forms.Button();
            this.LabPan = new System.Windows.Forms.Panel();
            this.LabyrynthG = new Labirints.Labyrynth();
            this.LeftPan.SuspendLayout();
            this.ShowPan.SuspendLayout();
            this.LabPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPan
            // 
            this.LeftPan.Controls.Add(this.ShowPan);
            this.LeftPan.Controls.Add(this.CanSolve);
            this.LeftPan.Controls.Add(this.Open);
            this.LeftPan.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPan.Location = new System.Drawing.Point(0, 0);
            this.LeftPan.Name = "LeftPan";
            this.LeftPan.Size = new System.Drawing.Size(149, 446);
            this.LeftPan.TabIndex = 4;
            // 
            // ShowPan
            // 
            this.ShowPan.Controls.Add(this.Solve);
            this.ShowPan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ShowPan.Location = new System.Drawing.Point(0, 399);
            this.ShowPan.Name = "ShowPan";
            this.ShowPan.Size = new System.Drawing.Size(149, 47);
            this.ShowPan.TabIndex = 3;
            // 
            // Solve
            // 
            this.Solve.Enabled = false;
            this.Solve.Location = new System.Drawing.Point(12, 12);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(123, 23);
            this.Solve.TabIndex = 1;
            this.Solve.Text = "Show solve";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.Solve_Click);
            // 
            // CanSolve
            // 
            this.CanSolve.AutoEllipsis = true;
            this.CanSolve.AutoSize = true;
            this.CanSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CanSolve.Location = new System.Drawing.Point(12, 48);
            this.CanSolve.MaximumSize = new System.Drawing.Size(123, 0);
            this.CanSolve.Name = "CanSolve";
            this.CanSolve.Size = new System.Drawing.Size(0, 13);
            this.CanSolve.TabIndex = 2;
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(12, 12);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(123, 23);
            this.Open.TabIndex = 0;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // LabPan
            // 
            this.LabPan.Controls.Add(this.LabyrynthG);
            this.LabPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabPan.Location = new System.Drawing.Point(149, 0);
            this.LabPan.Name = "LabPan";
            this.LabPan.Size = new System.Drawing.Size(483, 446);
            this.LabPan.TabIndex = 5;
            // 
            // LabyrynthG
            // 
            this.LabyrynthG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabyrynthG.Location = new System.Drawing.Point(0, 0);
            this.LabyrynthG.Name = "LabyrynthG";
            this.LabyrynthG.ShowSolve = false;
            this.LabyrynthG.Size = new System.Drawing.Size(483, 446);
            this.LabyrynthG.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.LabPan);
            this.Controls.Add(this.LeftPan);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Labirints";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.LeftPan.ResumeLayout(false);
            this.LeftPan.PerformLayout();
            this.ShowPan.ResumeLayout(false);
            this.LabPan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog MapOpen;
        private System.Windows.Forms.Panel LeftPan;
        private System.Windows.Forms.Panel LabPan;
        private System.Windows.Forms.Label CanSolve;
        private System.Windows.Forms.Button Solve;
        private System.Windows.Forms.Button Open;
        private Labyrynth LabyrynthG;
        private System.Windows.Forms.Panel ShowPan;
    }
}

