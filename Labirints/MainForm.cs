using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Labirints
{
    public partial class MainForm : Form
    {
        FileMatrix t;
        public static bool CorrectField = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (MapOpen.ShowDialog() == DialogResult.OK)
            {
                CorrectField = true;
                t = new FileMatrix();
                Worker.ReadMatrix(MapOpen.FileName, t);
                Worker.Check(t);
                if (MainForm.CorrectField)
                {
                    LabyrynthG.ShowSolve = false;
                    Worker.Solve(t);
                    if (t.CanSolve)
                    {
                        Solve.Enabled = true;
                        CanSolve.Text = "You can solve this labirynth by " + t.StepCount + " steps!";
                        CanSolve.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        Solve.Enabled = false;
                        CanSolve.Text = "You can't solve this labirynth!";
                        CanSolve.ForeColor = Color.DarkRed;
                    }
                    LabyrynthG.MatrixData = t;
                }
                else
                {
                    Solve.Enabled = false;
                    CanSolve.Text = "Incorrect labirynth!";
                    CanSolve.ForeColor = Color.DarkRed;
                }
                LabyrynthG.Refresh();
            }
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            LabyrynthG.ShowSolve = true;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            LabyrynthG.Refresh();
        }
    }
}