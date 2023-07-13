
namespace musk_shop_store
{
    partial class product
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.ImageAdd = new System.Windows.Forms.PictureBox();
            this.BrandAdd = new System.Windows.Forms.ComboBox();
            this.GenderAdd = new System.Windows.Forms.ComboBox();
            this.NameAdd = new System.Windows.Forms.RichTextBox();
            this.isSearch = new System.Windows.Forms.CheckBox();
            this.BtnAdd = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.AddPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAdd)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 558);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(122)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 37);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(118, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(243, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(432, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Brand";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(577, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gender";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(743, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Action";
            // 
            // AddPanel
            // 
            this.AddPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.AddPanel.Controls.Add(this.BtnAdd);
            this.AddPanel.Controls.Add(this.isSearch);
            this.AddPanel.Controls.Add(this.NameAdd);
            this.AddPanel.Controls.Add(this.GenderAdd);
            this.AddPanel.Controls.Add(this.BrandAdd);
            this.AddPanel.Controls.Add(this.ImageAdd);
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.AddPanel.Location = new System.Drawing.Point(0, 37);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(884, 50);
            this.AddPanel.TabIndex = 2;
            // 
            // ImageAdd
            // 
            this.ImageAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageAdd.Location = new System.Drawing.Point(124, 6);
            this.ImageAdd.Name = "ImageAdd";
            this.ImageAdd.Size = new System.Drawing.Size(60, 33);
            this.ImageAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageAdd.TabIndex = 2;
            this.ImageAdd.TabStop = false;
            this.ImageAdd.Click += new System.EventHandler(this.ImageAdd_Click);
            // 
            // BrandAdd
            // 
            this.BrandAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrandAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.BrandAdd.FormattingEnabled = true;
            this.BrandAdd.Location = new System.Drawing.Point(438, 6);
            this.BrandAdd.Name = "BrandAdd";
            this.BrandAdd.Size = new System.Drawing.Size(120, 33);
            this.BrandAdd.TabIndex = 3;
            this.BrandAdd.Text = "All";
            // 
            // GenderAdd
            // 
            this.GenderAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenderAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.GenderAdd.FormattingEnabled = true;
            this.GenderAdd.Items.AddRange(new object[] {
            "All",
            "Male",
            "Fe-Male"});
            this.GenderAdd.Location = new System.Drawing.Point(583, 6);
            this.GenderAdd.Name = "GenderAdd";
            this.GenderAdd.Size = new System.Drawing.Size(100, 33);
            this.GenderAdd.TabIndex = 4;
            this.GenderAdd.Text = "All";
            // 
            // NameAdd
            // 
            this.NameAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameAdd.Location = new System.Drawing.Point(247, 6);
            this.NameAdd.Name = "NameAdd";
            this.NameAdd.Size = new System.Drawing.Size(169, 33);
            this.NameAdd.TabIndex = 6;
            this.NameAdd.Text = "";
            // 
            // isSearch
            // 
            this.isSearch.AutoSize = true;
            this.isSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.isSearch.Location = new System.Drawing.Point(19, 15);
            this.isSearch.Name = "isSearch";
            this.isSearch.Size = new System.Drawing.Size(15, 14);
            this.isSearch.TabIndex = 7;
            this.isSearch.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.BtnAdd.Location = new System.Drawing.Point(747, 6);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(65, 33);
            this.BtnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAdd.TabIndex = 8;
            this.BtnAdd.TabStop = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.productListPanel);
            this.panel1.Controls.Add(this.AddPanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 532);
            this.panel1.TabIndex = 0;
            // 
            // productListPanel
            // 
            this.productListPanel.AutoScroll = true;
            this.productListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productListPanel.Location = new System.Drawing.Point(0, 87);
            this.productListPanel.Name = "productListPanel";
            this.productListPanel.Size = new System.Drawing.Size(884, 445);
            this.productListPanel.TabIndex = 3;
            // 
            // product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "product";
            this.Size = new System.Drawing.Size(890, 558);
            this.Load += new System.EventHandler(this.product_Load);
            this.SizeChanged += new System.EventHandler(this.product_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.AddPanel.ResumeLayout(false);
            this.AddPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAdd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel productListPanel;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.PictureBox BtnAdd;
        private System.Windows.Forms.CheckBox isSearch;
        private System.Windows.Forms.RichTextBox NameAdd;
        private System.Windows.Forms.ComboBox GenderAdd;
        private System.Windows.Forms.ComboBox BrandAdd;
        private System.Windows.Forms.PictureBox ImageAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
