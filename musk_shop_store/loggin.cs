using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musk_shop_store
{
    public partial class loggin : Form
    {
        public loggin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

        }
        private const int cGrip = 15;      // Grip size
        private const int cCaption = 15;   // Caption bar height;

        private void loggin_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption); 
            Color customColor = ColorTranslator.FromHtml("#0abf88");
            e.Graphics.FillRectangle(new SolidBrush(customColor), rc);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        /// resize function 
        private void resizeWindow()
        {
            if (this.Width < 450) { this.Width = 450; }
            if (this.Height < 450) { this.Height = 450; }
            //pictureBox1.Image = Bitmap.FromFile(@"C:\Users\yahya\Downloads\download.png");
            mainPanel.Height = this.Height - 50;
            mainPanel.Width = this.Width;
            ////////////////////////////////////////////////////////////
            mainPanel.Top = 40;
            controlPanel.Left = 0;
            controlPanel.Top = 15;
            controlPanel.Width = mainPanel.Width;
            ////////////////////////////////////////////////////////////
            pictureBox1.Width = Convert.ToInt32(mainPanel.Width * 0.5);
            ////////////////////////////////////////////////////////////
            childPanel.Width = parentPanel.Width;
            ////////////////////////////////////////////////////////////
            childPanel.Top = (parentPanel.Height - childPanel.Height) / 2;
            ////////////////////////////////////////////////////////////
            parentPanel.Width = Convert.ToInt32(mainPanel.Width * 0.5);
            ////////////////////////////////////////////////////////////
            usernameTextbox.Width = Convert.ToInt32(childPanel.Width * 0.9);
            ////////////////////////////////////////////////////////////
            usernameTextbox.Left = (childPanel.Width - usernameTextbox.Width - 5) / 2;
            ////////////////////////////////////////////////////////////
            passwordTextbox.Width = Convert.ToInt32(childPanel.Width * 0.9);
            ////////////////////////////////////////////////////////////
            passwordTextbox.Left = (childPanel.Width - passwordTextbox.Width - 5) / 2;
            ////////////////////////////////////////////////////////////
            kryptonCheckBox1.Left = usernameTextbox.Left + 5;
            ////////////////////////////////////////////////////////////
            label1.Left = usernameTextbox.Left;
            label2.Left = passwordTextbox.Left;
            ////////////////////////////////////////////////////////////
            kryptonButton1.Width = Convert.ToInt32(childPanel.Width * 0.9);
            ////////////////////////////////////////////////////////////
            kryptonButton1.Left = (childPanel.Width - kryptonButton1.Width - 5) / 2;
        }
        private void loggin_SizeChanged(object sender, EventArgs e)
        {
            resizeWindow();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if ( this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            resizeWindow();
        }
        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void loggin_MaximumSizeChanged(object sender, EventArgs e)
        {
            resizeWindow();
        }

        private void loggin_MinimumSizeChanged(object sender, EventArgs e)
        {
            resizeWindow();
        }
    }
}
