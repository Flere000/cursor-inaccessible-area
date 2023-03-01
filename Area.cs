using System;
using System.Drawing;
using System.Windows.Forms;

namespace CursorInaccessibleArea
{
    public partial class Area : Form
    {
        Point cursor;

        public Area()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                cursor = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(Location.X + e.X - cursor.X, Location.Y + e.Y - cursor.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void ClickCmenuDelete(object sender, EventArgs e)
        {
            this.Close();
        }

        


        private const int cGrip = 16; //Grip size

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {   //Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                    {
                        m.Result = (IntPtr)17; //HTBOTTOMRIGHT
                        return;
                    }
                    if (pos.X <= cGrip && pos.Y <= cGrip)
                    {
                        m.Result = (IntPtr)13; //HTTOPLEFT
                        return;
                    }
                    if (pos.X >= this.ClientSize.Width - cGrip && pos.Y <= cGrip)
                    {
                        m.Result = (IntPtr)14; //HTTOPRIGHT
                        return;
                    }
                    if (pos.X <= cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                    {
                        m.Result = (IntPtr)16; //HTBOTTOMLEFT
                        return;
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
}
