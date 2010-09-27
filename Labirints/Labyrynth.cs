using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Labirints
{
    public partial class Labyrynth : Control
    {
        public Labyrynth()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
ControlStyles.AllPaintingInWmPaint |
ControlStyles.UserPaint, true);
        }
        public FileMatrix MatrixData;
        private bool pShowSolve = false;
        public bool ShowSolve
        {
            get { return pShowSolve; }
            set
            {
                pShowSolve = value;

                if (pShowSolve)
                {
                    Step = MatrixData.StepCount;
                    Decrement.Start();
                }
                else
                {
                    this.Refresh();
                }
            }
        }
        private int Step = 0;
        private int Side = 20;

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (!MainForm.CorrectField)
            {
                string t = "Map is incorrect!";
                Font ef = new Font("Verdana", 28, FontStyle.Bold);
                SizeF ss = pe.Graphics.MeasureString(t, ef);
                pe.Graphics.DrawString(t, ef, Brushes.DarkRed,
                    new Point((int)((this.Width - ss.Width) / 2),
                              (int)((this.Height - ss.Height) / 2)));
            }
            else if (MatrixData != null)
            {
                SetScale();
                int side = Side;
                #region Draw net
                for (int i = 2; i < MatrixData.Width; i++)
                {
                    for (int j = 2; j < MatrixData.Height; j++)
                    {
                        System.Drawing.Rectangle r = new Rectangle(((i - 2) * side) + 1, ((j - 2) * side) + 1, side, side);
                        pe.Graphics.DrawRectangle(new Pen(Brushes.Silver), r);
                    }
                }
                Rectangle frame = new Rectangle(1, 1, side * (MatrixData.Width - 2), side * (MatrixData.Height - 2));
                pe.Graphics.DrawRectangle(new Pen(Brushes.Black), frame);
                #endregion
                #region Draw walls
                for (int i = 2; i < MatrixData.Width; i++)
                {
                    for (int j = 2; j < MatrixData.Height; j++)
                    {

                        if (MatrixData.Matrix[j, i] == -100)
                        {
                            Color FColor = new Color();
                            FColor = Color.DarkGray;
                            System.Drawing.Rectangle r = new Rectangle(((i - 2) * side) + 1, ((j - 2) * side) + 1, side, side);
                            SolidBrush blueBrush = new SolidBrush(FColor);
                            pe.Graphics.FillRectangle(blueBrush, r);

                            pe.Graphics.DrawRectangle(new Pen(Brushes.Black), r);
                        }
                    }
                }
                #endregion
                #region Draw path
                if (MatrixData.CanSolve)
                {
                    if (ShowSolve)
                    {
                        int cx = MatrixData.StartPoint.X;
                        int cy = MatrixData.StartPoint.Y;

                        while (MatrixData.Matrix[cx, cy] > Step)
                        {
                            Pen nPen = new Pen(Brushes.DarkRed);
                            nPen.Width = 4;
                            if (MatrixData.Matrix[cx - 1, cy] == MatrixData.Matrix[cx, cy] - 1)
                            {
                                cx--;
                                pe.Graphics.DrawLine(nPen,
                                    new Point((cy - 2) * Side + 1 + (side / 2), (cx - 1) * Side + 1 - Side / 2),
                                    new Point((cy - 2) * Side + 1 + (side / 2), (cx) * Side + 1 - Side / 2));
                            }
                            else if (MatrixData.Matrix[cx + 1, cy] == MatrixData.Matrix[cx, cy] - 1)
                            {
                                cx++;
                                pe.Graphics.DrawLine(nPen,
                                    new Point((cy - 2) * Side + 1 + (side / 2), (cx - 2) * Side + 1 - Side / 2),
                                    new Point((cy - 2) * Side + 1 + (side / 2), (cx - 1) * Side + 1 - Side / 2));
                            }
                            else if (MatrixData.Matrix[cx, cy - 1] == MatrixData.Matrix[cx, cy] - 1)
                            {
                                cy--;
                                pe.Graphics.DrawLine(nPen,
                                    new Point((cy - 1) * Side + 1 - Side / 2, (cx - 2) * Side + 1 + (side / 2)),
                                    new Point((cy) * Side + 1 - Side / 2, (cx - 2) * Side + 1 + (side / 2)));
                            }
                            else if (MatrixData.Matrix[cx, cy + 1] == MatrixData.Matrix[cx, cy] - 1)
                            {
                                cy++;
                                pe.Graphics.DrawLine(nPen,
                                    new Point((cy - 2) * Side + 1 - Side / 2, (cx - 2) * Side + 1 + (side / 2)),
                                    new Point((cy - 1) * Side + 1 - Side / 2, (cx - 2) * Side + 1 + (side / 2)));
                            }

                            Rectangle r = new Rectangle(
                                new Point((cy - 2) * Side + 1,
                                          (cx - 2) * Side + 1),
                                new Size(Side, Side));
                            //pe.Graphics.FillRectangle(Brushes.Black, r);
                        }
                    }
                }
                #endregion
                #region Draw finnish
                Bitmap b = new Bitmap(Labirints.Properties.Resources.flag);
                b.MakeTransparent(Color.White);
                pe.Graphics.DrawImage(b,
                    new Rectangle(new Point((MatrixData.FinishPoint.Y - 2) * side + 1,
                                            (MatrixData.FinishPoint.X - 2) * side + 1),
                                  new Size(side, side)));
                #endregion
                #region Draw start
                Rectangle rc = new Rectangle(new Point((MatrixData.StartPoint.Y - 2) * side + 1 + (side / 4),
                                            (MatrixData.StartPoint.X - 2) * side + 1 + (side / 4)),
                                  new Size(side - (side / 2), side - (side / 2)));
                pe.Graphics.FillEllipse(Brushes.DarkGreen, rc);
                pe.Graphics.DrawEllipse(new Pen(Brushes.Black), rc);
                #endregion
            }

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
        private void SetScale()
        {
            int side = Math.Min(this.Height / (MatrixData.Height -2), this.Width / (MatrixData.Width-2));
            Side = Math.Max(side, 6);
        }
        private void Decrement_Tick(object sender, EventArgs e)
        {
            Step--;
            this.Refresh();
            if (Step <= 0)
            {
                Decrement.Stop();
            }
        }
    }
}
