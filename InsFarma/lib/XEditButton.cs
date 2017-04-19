using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace InsFarma
{
    /// <summary>
    /// Component TextBox amb botó (i event per a aquest botó).
    /// http://stackoverflow.com/questions/15868817/button-inside-a-winforms-textbox
    /// </summary>
    public class XEditButton : TextBox
    {
        private readonly Button btn;
        public event EventHandler ButtonClick { add { btn.Click += value; } remove { btn.Click -= value; } }

        public XEditButton()
        {
            btn = new Button { Cursor = Cursors.Default };
            btn.Size = new Size(16, 16);
            btn.Location = new Point(this.ClientSize.Width - btn.Width, -1);
            btn.SizeChanged += (o, e) => OnResize(e);
            this.Controls.Add(btn);
        }

        public Button Button
        {
            get
            {
                return btn;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
//            btn.Size = new Size(btn.Width, this.ClientSize.Height + 2);
//            btn.Size = new Size(16, 16);
            btn.Location = new Point(this.ClientSize.Width - btn.Width, -1);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
