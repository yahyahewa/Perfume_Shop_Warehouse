
namespace musk_shop_store
{
    partial class category
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
            this.categoreyNameTextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.categoreyNameLable = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selectImageLable = new System.Windows.Forms.LinkLabel();
            this.categoryAddBox = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.categoreisList = new System.Windows.Forms.GroupBox();
            this.categoryPanleList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.categoryBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryAddBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryAddBox.Panel)).BeginInit();
            this.categoryAddBox.Panel.SuspendLayout();
            this.categoryAddBox.SuspendLayout();
            this.categoreisList.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // categoreyNameTextbox
            // 
            this.categoreyNameTextbox.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon;
            this.categoreyNameTextbox.Location = new System.Drawing.Point(145, 5);
            this.categoreyNameTextbox.Multiline = true;
            this.categoreyNameTextbox.Name = "categoreyNameTextbox";
            this.categoreyNameTextbox.Size = new System.Drawing.Size(367, 51);
            this.categoreyNameTextbox.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.categoreyNameTextbox.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.categoreyNameTextbox.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.categoreyNameTextbox.StateActive.Border.Rounding = 0;
            this.categoreyNameTextbox.StateActive.Border.Width = 2;
            this.categoreyNameTextbox.StateActive.Content.Font = new System.Drawing.Font("Vani", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoreyNameTextbox.StateActive.Content.Padding = new System.Windows.Forms.Padding(5, 0, 0, 1);
            this.categoreyNameTextbox.StateNormal.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.categoreyNameTextbox.TabIndex = 8;
            // 
            // categoreyNameLable
            // 
            this.categoreyNameLable.AutoSize = true;
            this.categoreyNameLable.Font = new System.Drawing.Font("Shruti", 13F, System.Drawing.FontStyle.Bold);
            this.categoreyNameLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(122)))));
            this.categoreyNameLable.Location = new System.Drawing.Point(3, 17);
            this.categoreyNameLable.Name = "categoreyNameLable";
            this.categoreyNameLable.Size = new System.Drawing.Size(138, 29);
            this.categoreyNameLable.TabIndex = 9;
            this.categoreyNameLable.Text = "Category Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(667, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // selectImageLable
            // 
            this.selectImageLable.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(122)))));
            this.selectImageLable.AutoSize = true;
            this.selectImageLable.Font = new System.Drawing.Font("Shruti", 13F, System.Drawing.FontStyle.Bold);
            this.selectImageLable.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(122)))));
            this.selectImageLable.Location = new System.Drawing.Point(518, 17);
            this.selectImageLable.Name = "selectImageLable";
            this.selectImageLable.Size = new System.Drawing.Size(145, 29);
            this.selectImageLable.TabIndex = 13;
            this.selectImageLable.TabStop = true;
            this.selectImageLable.Text = "Select an Image";
            this.selectImageLable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // categoryAddBox
            // 
            this.categoryAddBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryAddBox.Location = new System.Drawing.Point(0, 0);
            this.categoryAddBox.Name = "categoryAddBox";
            // 
            // categoryAddBox.Panel
            // 
            this.categoryAddBox.Panel.Controls.Add(this.categoreisList);
            this.categoryAddBox.Panel.Controls.Add(this.panel1);
            this.categoryAddBox.Size = new System.Drawing.Size(815, 512);
            this.categoryAddBox.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.categoryAddBox.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.categoryAddBox.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(122)))));
            this.categoryAddBox.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.categoryAddBox.StateNormal.Border.Rounding = 5;
            this.categoryAddBox.StateNormal.Border.Width = 2;
            this.categoryAddBox.TabIndex = 15;
            // 
            // categoreisList
            // 
            this.categoreisList.Controls.Add(this.categoryPanleList);
            this.categoreisList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoreisList.Font = new System.Drawing.Font("Shruti", 13F);
            this.categoreisList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(122)))));
            this.categoreisList.Location = new System.Drawing.Point(0, 61);
            this.categoreisList.Name = "categoreisList";
            this.categoreisList.Size = new System.Drawing.Size(807, 425);
            this.categoreisList.TabIndex = 16;
            this.categoreisList.TabStop = false;
            this.categoreisList.Text = "Categoreis List";
            // 
            // categoryPanleList
            // 
            this.categoryPanleList.AutoScroll = true;
            this.categoryPanleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryPanleList.Location = new System.Drawing.Point(3, 35);
            this.categoryPanleList.Name = "categoryPanleList";
            this.categoryPanleList.Size = new System.Drawing.Size(801, 387);
            this.categoryPanleList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.categoryBtn);
            this.panel1.Controls.Add(this.categoreyNameLable);
            this.panel1.Controls.Add(this.selectImageLable);
            this.panel1.Controls.Add(this.categoreyNameTextbox);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 61);
            this.panel1.TabIndex = 15;
            // 
            // categoryBtn
            // 
            this.categoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(122)))));
            this.categoryBtn.BackgroundImage = global::musk_shop_store.Properties.Resources.plus;
            this.categoryBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.categoryBtn.Location = new System.Drawing.Point(737, 5);
            this.categoryBtn.Name = "categoryBtn";
            this.categoryBtn.Size = new System.Drawing.Size(55, 51);
            this.categoryBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.categoryBtn.TabIndex = 14;
            this.categoryBtn.TabStop = false;
            this.categoryBtn.Click += new System.EventHandler(this.categoryBtn_Click);
            // 
            // category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.categoryAddBox);
            this.Name = "category";
            this.Size = new System.Drawing.Size(815, 512);
            this.Load += new System.EventHandler(this.category_Load);
            this.SizeChanged += new System.EventHandler(this.category_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryAddBox.Panel)).EndInit();
            this.categoryAddBox.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoryAddBox)).EndInit();
            this.categoryAddBox.ResumeLayout(false);
            this.categoreisList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label categoreyNameLable;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox categoreyNameTextbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel selectImageLable;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox categoryAddBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox categoreisList;
        private System.Windows.Forms.Panel categoryPanleList;
        private System.Windows.Forms.PictureBox categoryBtn;
    }
}
