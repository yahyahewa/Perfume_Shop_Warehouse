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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        // categorey
        category category = new category();
        private void categoryBtn_Click(object sender, EventArgs e)
        {
            selectPage(category);
        }
        // this methode for choosing we wanna select to show
        private void selectPage(UserControl control)
        {
            ContentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            ContentPanel.Controls.Add(control);
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            ContentPanel.Width = this.Width - BtnContainer.Width-20;
            BtnContainer.Height = leftSidePanel.Height - 40;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            selectPage(product);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
        }

        product product = new product();
        public void kryptonButton1_Click(object sender, EventArgs e)
        {
            selectPage(product);
        }
    }
}
