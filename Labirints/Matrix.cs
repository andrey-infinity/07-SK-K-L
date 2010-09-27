using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace Labirints
{
    public enum FieldType
    {
        wall = -100,
        free = -1,
        start = -1,
        finish = 0,
    }

    public static class Worker
    {
        public static bool Check(FileMatrix _FM)
        {
            #region First Check
            if (((_FM.Height == _FM.Matrix.GetUpperBound(1)+1) &
                 (_FM.Width == _FM.Matrix.GetUpperBound(0)+1) &
                 (_FM.Width > 1) &
                 (_FM.Height > 1)))
            {
              //  throw new Exception("Check size failed");
                MainForm.CorrectField = false;
            }
            #endregion

            #region Second Check
            Point SaveFinish = _FM.FinishPoint;
            _FM.Matrix[_FM.FinishPoint.X, _FM.FinishPoint.Y] = -1;
            _FM.FinishPoint = new Point(1, 1);
            _FM.Matrix[_FM.FinishPoint.X, _FM.FinishPoint.Y] = 0;
            Solve(_FM);
            if (_FM.CanSolve)
            {
                //throw new Exception("Check Matrix failed");
                MainForm.CorrectField = false;
            }

            for (int i = 1; i <= _FM.Height; i++)
            {
                for (int j = 1; j <= _FM.Width; j++)
                {
                    if (_FM.Matrix[i, j]>0)
                    {
                        _FM.Matrix[i, j] = (int)FieldType.free;
                    }
                }
            }
            _FM.FinishPoint = SaveFinish;
            _FM.Matrix[1, 1] = (int)FieldType.free;
            _FM.Matrix[SaveFinish.X, SaveFinish.Y] = (int)FieldType.finish;
            #endregion

            return true;
        }
        public static void Solve(FileMatrix _FM)
        {
            int step = 0;
            bool Cont = true;
            while ((_FM.Matrix[_FM.StartPoint.X, _FM.StartPoint.Y] == (int)FieldType.free) && Cont)
            {
                Cont = false;
                for (int i = 1; i <= _FM.Height; i++)
                {
                    for (int j = 1; j <= _FM.Width; j++)
                    {
                        if (_FM.Matrix[i, j] == step)
                        {
                            if (_FM.Matrix[i + 1, j] == -1)
                            {
                                _FM.Matrix[i + 1, j] = step + 1;
                                Cont = true;
                            }
                            if (_FM.Matrix[i - 1, j] == -1)
                            {
                                _FM.Matrix[i - 1, j] = step + 1;
                                Cont = true;
                            }
                            if (_FM.Matrix[i, j + 1] == -1)
                            {
                                _FM.Matrix[i, j + 1] = step + 1;
                                Cont = true;
                            }
                            if (_FM.Matrix[i, j - 1] == -1)
                            {
                                _FM.Matrix[i, j - 1] = step + 1;
                                Cont = true;
                            }
                        }
                    }
                }
                step++;
            }
             
            _FM.StepCount = step;
            _FM.CanSolve=(_FM.Matrix[_FM.StartPoint.X, _FM.StartPoint.Y] != (int)FieldType.free);
        }
        public static void ReadMatrix(string _FileName, FileMatrix _FM)
        {
            if (File.Exists(_FileName))
            {
                string[] file = File.ReadAllLines(_FileName);
                _FM.Height = file.Length + 2;
                _FM.Width = file[0].Length + 2;
                _FM.FinishPointCount = 0;
                _FM.StartPointCount = 0;
                _FM.Matrix = new int[_FM.Height + 2, _FM.Width + 2];


                #region buldwall
                for (int i = 1; i < _FM.Width + 1; i++)
                {
                    _FM.Matrix[1, i] = -1;
                    _FM.Matrix[_FM.Height, i] = -1;
                }
                for (int i = 1; i <= _FM.Height + 1; i++)
                {
                    _FM.Matrix[i, 1] = -1;
                    _FM.Matrix[i, _FM.Width] = -1;
                }
                #endregion
                #region buildsecondwall
                for (int i = 0; i < _FM.Width + 2; i++)
                {
                    _FM.Matrix[0, i] = -100;
                    _FM.Matrix[_FM.Height + 1, i] = -100;
                }
                for (int i = 0; i < _FM.Height + 2; i++)
                {
                    _FM.Matrix[i, 0] = -100;
                    _FM.Matrix[i, _FM.Width + 1] = -100;
                }
                #endregion

                int value = 0;
                for (int i = 0; i < _FM.Height - 2; i++)
                {
                    for (int j = 0; j < _FM.Width - 2; j++)
                    {

                        switch (file[i][j])
                        {
                            case '#':
                                value = (int)FieldType.wall;
                                break;
                            case '.':
                                value = (int)FieldType.free;
                                break;
                            case 'S':
                                value = (int)FieldType.start;
                                _FM.StartPoint = new Point(i + 2, j + 2);
                                _FM.StartPointCount++;
                                break;
                            case 'F':
                                value = (int)FieldType.finish;
                                _FM.FinishPoint = new Point(i + 2, j + 2);
                                _FM.FinishPointCount++;
                                break;
                            default:
                               // throw new Exception("Unknow File structure");
                                MainForm.CorrectField = false;
                                break;
                        }
                        _FM.Matrix[i + 2, j + 2] = value;
                    }
                }
                

            }
            else
            {
               // throw new Exception("File not found");
                MainForm.CorrectField = false;
            }
        }

    }

    public class FileMatrix
    {
        #region Properties
        private int _height;
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int _width;
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private int[,] _matrix;
        public int[,] Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        private int _startpointcount;
        public int StartPointCount
        {
            get { return _startpointcount; }
            set { _startpointcount = value; }
        }

        private int _finishpointcount;
        public int FinishPointCount
        {
            get { return _finishpointcount; }
            set { _finishpointcount = value; }
        }

        private Point _startpoint;
        public Point StartPoint
        {
            get { return _startpoint; }
            set { _startpoint = value; }
        }

        private int _stepcount;
        public int StepCount
        {
            get { return _stepcount; }
            set { _stepcount = value; }
        }

        private Point _finishpoint;
        public Point FinishPoint
        {
            get { return _finishpoint; }
            set { _finishpoint = value; }
        }

        private bool _cansolve;
        public bool CanSolve
        {
            get { return _cansolve; }
            set { _cansolve = value; }
        }
        #endregion

        public FileMatrix()
        {
        }
    }
}

