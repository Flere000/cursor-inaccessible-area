using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CursorInaccessibleArea
{
    public partial class SettingForm : Form
    {
        private System.Media.SoundPlayer player = new System.Media.SoundPlayer("sound.wav");

        private IntPtr hHook;
        private WindowsAPI.HOOKPROC proc;
        private Vector pcursor = new Vector(0, 0);

        List<Form> notch = new List<Form>();
        Color notchColor = Color.Red;


        //フォームの設定
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            SetHook();
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotchGenerator.BalloonTipTitle = "成功";
            NotchGenerator.BalloonTipText = "UnhookWindowsHookEx 成功";
            if (WindowsAPI.UnhookWindowsHookEx(hHook) == false)
            {
                NotchGenerator.BalloonTipTitle = "エラー";
                NotchGenerator.BalloonTipText = "UnhookWindowsHookEx 失敗";
            }
            NotchGenerator.ShowBalloonTip(3000);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Area f1 = (Area)sender;
            for (int i = 0; i < notch.Count; i++)
            {
                if (notch[i] == f1)
                {
                    notch.RemoveAt(i);
                    break;
                }
            }
        }



        //フォーム上の各要素のイベント設定
        private void ClickAddNotch(object sender, EventArgs e)
        {
            int x, y, width, height;
            bool result1 = int.TryParse(xTextBox.Text, out x);
            bool result2 = int.TryParse(yTextBox.Text, out y);
            bool result3 = int.TryParse(wTextBox.Text, out width);
            bool result4 = int.TryParse(hTextBox.Text, out height);

            if (!result1 || !result2 || !result3 || !result4 || width <= 0 || height <= 0)
            {
                MessageBox.Show("正しい値を入力してください(半角数字、幅と高さが1以上)", "入力エラー");
                return;
            }
            else
            {
                notch.Add(new Area());
                notch[notch.Count - 1].FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                notch[notch.Count - 1].Location = new System.Drawing.Point(x, y);
                notch[notch.Count - 1].BackColor = notchColor;
                notch[notch.Count - 1].Show(this);
                notch[notch.Count - 1].Size = new System.Drawing.Size(width, height);
                if (HideNotchs.Checked)
                {
                    notch[notch.Count - 1].Hide();
                }
            }
        }

        private void ClickDeleteNotch(object sender, EventArgs e)
        {
            int b = notch.Count;
            while (notch.Count > 0)
            {
                notch[0].Close();
            }
            //label1.Text = string.Format("Mouse Position : {0:d}, {1:d}", b, notch.Count);

        }

        private void ClickColorButton(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < notch.Count; i++)
                {
                    //選択された色の取得
                    notch[i].BackColor = cd.Color;
                }
                notchColor = cd.Color;
            }
        }

        private void ChangeHideNotchs(object sender, EventArgs e)
        {
            if (sender.Equals(HideNotchs) && disableNotchs.Checked != HideNotchs.Checked)
            {
                disableNotchs.Checked = HideNotchs.Checked;
            }
            else if (sender.Equals(disableNotchs) && disableNotchs.Checked != HideNotchs.Checked)
            {
                HideNotchs.Checked = disableNotchs.Checked;
            }
            else
            {
                return;
            }

            for (int i = 0; i < notch.Count; i++)
            {
                if (HideNotchs.Checked)
                {
                    notch[i].Hide();
                }
                else
                {
                    notch[i].Show(this);
                }
            }
        }

        private void ClickEditMode(object sender, EventArgs e)
        {
            if (EditMode.Checked)
            {
                disableNotchs.Checked = HideNotchs.Checked = false;
                disableNotchs.Enabled = HideNotchs.Enabled = false;
            }
            else
            {
                disableNotchs.Enabled = HideNotchs.Enabled = true;
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs && ((MouseEventArgs)e).Button != MouseButtons.Left)
            {
                return;
            }
            this.Show();
            this.WindowState = FormWindowState.Normal;
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Location = new System.Drawing.Point(x, y);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < notch.Count; i++)
            {
                //notch[i].Close();
            }
            this.Close();
        }



        //閉じるボタンで閉じずに非表示にする設定
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const long SC_CLOSE = 0xF060L;

            if (m.Msg == WM_SYSCOMMAND &&
                (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
            {
                this.Hide();
                return;
            }

            base.WndProc(ref m);
        }



        //フック関連
        private int SetHook()
        {
            IntPtr hmodule = WindowsAPI.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
            proc = (WindowsAPI.HOOKPROC)MyHookProc;
            hHook = WindowsAPI.SetWindowsHookEx(WindowsAPI.WH_MOUSE_LL, proc, hmodule, 0);
            if (hHook == null)
            {
                NotchGenerator.BalloonTipTitle = "エラー";
                NotchGenerator.BalloonTipText = "SetWindowsHookEx 失敗";
                NotchGenerator.ShowBalloonTip(3000);
                return -1;
            }
            else
            {
                NotchGenerator.BalloonTipTitle = "成功";
                NotchGenerator.BalloonTipText = "SetWindowsHookEx 成功";
                NotchGenerator.ShowBalloonTip(3000);
                return 0;
            }
        }

        private IntPtr MyHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= WindowsAPI.HC_ACTION)
            {
                WindowsAPI.MSLLHOOKSTRUCT MouseHookStruct = (WindowsAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WindowsAPI.MSLLHOOKSTRUCT));
                bool isHit = false, isSound = false;
                Vector cursor = new Vector(MouseHookStruct.pt.x, MouseHookStruct.pt.y);
                if (cursor.X < 0) cursor.X = 0;
                if (Screen.PrimaryScreen.Bounds.Width < cursor.X) cursor.X = Screen.PrimaryScreen.Bounds.Width;
                if (cursor.Y < 0) cursor.Y = 0;
                if (Screen.PrimaryScreen.Bounds.Height < cursor.Y) cursor.Y = Screen.PrimaryScreen.Bounds.Height;


                if (!HideNotchs.Checked && !EditMode.Checked)
                {
                    if (MouseHookStruct.dwExtraInfo == (IntPtr)22222016)
                    {
                        return WindowsAPI.CallNextHookEx(hHook, nCode, wParam, lParam);
                    }

                    for (int j = 0; j < notch.Count; j++)
                    {
                        Vector[] corners = new Vector[] {new Vector(notch[j].Left-1, notch[j].Top-1), new Vector(notch[j].Right, notch[j].Top-1),
                                                     new Vector(notch[j].Right, notch[j].Bottom), new Vector(notch[j].Left-1, notch[j].Bottom)};

                        double[] dist = new double[corners.Length];
                        Vector[] intersection = new Vector[corners.Length];
                        int count = 0, nearest = 0, second = 0;
                        for (int i = 0; i < corners.Length; i++)
                        {
                            Vector[] vec = new Vector[6];
                            double d1, d2, d3, d4;
                            vec[0] = cursor - pcursor;
                            vec[1] = corners[i] - pcursor;
                            vec[2] = corners[(i + 1) % corners.Length] - pcursor;

                            d1 = Vector.CrossProduct(vec[0], vec[1]);
                            d2 = Vector.CrossProduct(vec[0], vec[2]);

                            vec[3] = corners[(i + 1) % corners.Length] - corners[i];
                            vec[4] = pcursor - corners[i];
                            vec[5] = cursor - corners[i];

                            d3 = Vector.CrossProduct(vec[3], vec[4]);
                            d4 = Vector.CrossProduct(vec[3], vec[5]);
                            if (d1 * d2 > 0 || d3 * d4 > 0)
                            {
                                intersection[i] = new Vector(1e9, 1e9);
                                dist[i] = 1e9;
                                continue;
                            }

                            double det = (pcursor.X - cursor.X) * (corners[(i + 1) % corners.Length].Y - corners[i].Y) - (corners[(i + 1) % corners.Length].X - corners[i].X) * (pcursor.Y - cursor.Y);
                            double t = ((corners[(i + 1) % corners.Length].Y - corners[i].Y) * (corners[(i + 1) % corners.Length].X - cursor.X) + (corners[i].X - corners[(i + 1) % corners.Length].X) * (corners[(i + 1) % corners.Length].Y - cursor.Y)) / det;
                            intersection[i] = t * pcursor + (1.0 - t) * cursor;
                            dist[i] = Math.Sqrt(Math.Pow(pcursor.X - intersection[i].X, 2) + Math.Pow(pcursor.Y - intersection[i].Y, 2));
                            count++;
                            if (count == 1)
                            {
                                nearest = i;
                            }
                            else if (count == 2)
                            {
                                second = i;
                                if (dist[second] < dist[nearest])
                                {
                                    int tmp = second;
                                    second = nearest;
                                    nearest = tmp;
                                }
                            }
                        }

                        if (count > 0)
                        {
                            for (int k = 0; k < notch.Count; k++)
                            {
                                if (k != j)
                                {
                                    Vector[] otherC = new Vector[] {new Vector(notch[k].Left-1, notch[k].Top-1), new Vector(notch[k].Right, notch[k].Top-1),
                                                     new Vector(notch[k].Right, notch[k].Bottom), new Vector(notch[k].Left-1, notch[k].Bottom)};
                                    for (int l = 0; l < otherC.Length; l++)
                                    {
                                        Vector[] vec = new Vector[6];
                                        double d1, d2, d3, d4;
                                        vec[0] = corners[(nearest + 1) % corners.Length] - corners[nearest];
                                        vec[1] = otherC[l] - corners[nearest];
                                        vec[2] = otherC[(l + 1) % otherC.Length] - corners[nearest];

                                        d1 = Vector.CrossProduct(vec[0], vec[1]);
                                        d2 = Vector.CrossProduct(vec[0], vec[2]);

                                        vec[3] = otherC[(l + 1) % otherC.Length] - otherC[l];
                                        vec[4] = corners[nearest] - otherC[l];
                                        vec[5] = corners[(nearest + 1) % corners.Length] - otherC[l];

                                        d3 = Vector.CrossProduct(vec[3], vec[4]);
                                        d4 = Vector.CrossProduct(vec[3], vec[5]);
                                        if (d1 * d2 > 0 || d3 * d4 > 0)
                                        {
                                            continue;
                                        }
                                        Console.WriteLine("x" + cursor.X);
                                        Vector p1 = pcursor - otherC[l];
                                        Vector p2 = cursor - otherC[l];
                                        bool sx = l == 1 && p1.X >= 0 && p2.X < 0 || l == 3 && p1.X <= 0 && p2.X > 0;
                                        bool sy = l == 2 && p1.Y >= 0 && p2.Y < 0 || l == 0 && p1.Y <= 0 && p2.Y > 0;

                                        if (sx)
                                        {
                                            isHit = true;
                                            cursor.X = otherC[l].X;
                                            //Console.WriteLine("x"+cursor.X);
                                        }
                                        else if (sy)
                                        {
                                            isHit = true;
                                            cursor.Y = otherC[l].Y;
                                            //Console.WriteLine("y"+cursor.Y);
                                        }
                                    }
                                }
                            }
                        }

                        if (count == 1 && IsInNotch(corners[0], corners[2], cursor) || count == 2 && (nearest + second) % 2 == 0)
                        {
                            isHit = true;
                            if (corners[nearest].X == corners[(nearest + 1) % corners.Length].X)
                            {
                                cursor.X = corners[nearest].X;
                            }
                            else
                            {
                                cursor.Y = corners[nearest].Y;
                            }
                        }
                        else if (count == 2)
                        {
                            isHit = true;
                            if (corners[nearest].X == corners[(nearest + 1) % corners.Length].X && !Double.IsNaN(intersection[second].X))
                            {
                                cursor.X = cursor.X - Math.Abs((int)intersection[second].X - (int)corners[nearest].X);
                            }
                            else if (corners[nearest].Y == corners[(nearest + 1) % corners.Length].Y && !Double.IsNaN(intersection[second].Y))
                            {
                                cursor.Y = cursor.Y - Math.Abs((int)intersection[second].Y - (int)corners[nearest].Y);
                            }
                        }

                        if (pcursor.X != corners[0].X && corners[2].X != pcursor.X && pcursor.Y != corners[0].Y && corners[2].Y != pcursor.Y &&
                            ((cursor.X == corners[0].X || cursor.X == corners[2].X) && corners[0].Y <= cursor.Y && cursor.Y <= corners[2].Y ||
                            (cursor.Y == corners[0].Y || cursor.Y == corners[2].Y) && corners[0].X <= cursor.X && cursor.X <= corners[2].X))
                        {
                            isSound = true;
                        }
                    }

                    if (isSound)
                    {
                        Task.Run(() => player.Play());
                    }
                }

                pcursor = cursor;
                label1.Text = string.Format("Mouse Position : {0:d}, {1:d}", (int)pcursor.X, (int)pcursor.Y);
                if (isHit)
                {
                    MouseHookStruct.pt.x = (int)pcursor.X;
                    MouseHookStruct.pt.y = (int)pcursor.Y;
                    Task.Run(() => WindowsAPI.SendMouseMove((int)wParam, MouseHookStruct, Screen.PrimaryScreen));
                    return new IntPtr(1);
                }
            }
            return WindowsAPI.CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        private bool IsInNotch(Vector p1, Vector p2, Vector pos)
        {
            return p1.X < pos.X && pos.X < p2.X && p1.Y < pos.Y && pos.Y < p2.Y;
        }
    }
}
