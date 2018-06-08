using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingWindow
{
    public partial class WindowMovingForm : Form
    {
        public WindowMovingForm()
        {
            InitializeComponent();
        }

        private int moveStep = 6;
        private MoveDirection moving;

        private void WindowMovingForm_KeyDown(object sender, KeyEventArgs e)
        {
            MoveFormTimer.Start();
            DirectionControler(e.KeyCode);
        }

        private void DirectionControler(Keys key)
        {
            MoveFormTimer.Start();

            switch (key)
            {
                case Keys.Right:
                    moving = MoveDirection.Right;
                    break;
                case Keys.Left:
                    moving = MoveDirection.Left;
                    break;
                case Keys.Up:
                    moving = MoveDirection.Up;
                    break;
                case Keys.Down:
                    moving = MoveDirection.Down;
                    break;
                case Keys.Enter:
                    CenterToScreen();
                    MoveFormTimer.Stop();
                    break;
            }
        }

        private void MoveFormTimer_Tick(object sender, EventArgs e)
        {
            switch (moving)
            {
                case MoveDirection.Down:
                    if (Location.Y + Height != Screen.PrimaryScreen.Bounds.Height)
                    {
                        if (Location.Y + moveStep + Height <= Screen.PrimaryScreen.Bounds.Height)
                        {
                            Location = new Point(Location.X, Location.Y + moveStep);
                        }
                        else
                        {
                            Location = new Point(Location.X, Screen.PrimaryScreen.Bounds.Height - Height);
                        }
                    }
                    else
                    {
                        DirectionControler(Keys.Up);
                    }
                    break;
                case MoveDirection.Up:
                    if (Location.Y != 0)
                    {
                        if (Location.Y - moveStep >= 0)
                        {
                            Location = new Point(Location.X, Location.Y - moveStep);
                        }
                        else
                        {
                            Location = new Point(Location.X, 0);
                        }
                    }
                    else
                    {
                        DirectionControler(Keys.Down);
                    }
                    break;
                case MoveDirection.Left:
                    if (Location.X != 0)
                    {
                        if (Location.X - moveStep >= 0)
                        {
                            Location = new Point(Location.X - moveStep, Location.Y);
                        }
                        else
                        {
                            Location = new Point(0, Location.Y);
                        }
                    }
                    else
                    {
                        DirectionControler(Keys.Right);
                    }
                    break;
                case MoveDirection.Right:
                    if (Location.X + Width != Screen.PrimaryScreen.Bounds.Width)
                    {
                        if (Location.X + moveStep + Width <= Screen.PrimaryScreen.Bounds.Width)
                        {
                            Location = new Point(Location.X + moveStep, Location.Y);
                        }
                        else
                        {
                            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, Location.Y);
                        }
                    }
                    else
                    {
                        DirectionControler(Keys.Left);
                    }
                    break;
            }
        }
    }
}