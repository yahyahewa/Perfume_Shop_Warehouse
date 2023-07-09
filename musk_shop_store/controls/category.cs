using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace musk_shop_store
{
    public partial class category : UserControl
    {
        OleDbCommand cmd;
        OleDbDataReader dataReader;
        public category()
        {
            InitializeComponent();
        }
        string newfileName = "";bool loadPage = true;
        private void category_Load(object sender, EventArgs e)
        {
            categoryAddBox.Text = "Add Category";
            retriveCategorey();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            uploadIamge("add", "");
        }

        private void category_SizeChanged(object sender, EventArgs e)
        {
            resizeAddCategoreyelement();
            resizeCategoriesList();
        }
        /// resize catagoreise list
        private void resizeAddCategoreyelement()
        {
           // categoryBtn.Image = new Bitmap(@"C:\Users\yahya\Downloads\plus (2).png");
            categoryBtn.Width = 60;
            categoreyNameTextbox.Width = (categoryAddBox.Panel.Width - categoreyNameLable.Width - selectImageLable.Width - pictureBox1.Width) - 123;
            selectImageLable.Left = categoreyNameTextbox.Width + categoreyNameTextbox.Left + 5;
            pictureBox1.Left = selectImageLable.Width + selectImageLable.Left + 5;
            categoryBtn.Left = pictureBox1.Width + pictureBox1.Left + 5;
        }
        private void resizeCategoriesList()
        {
            int width = 0; 
            foreach (Control panel in categoryPanleList.Controls)
            {
                panel.Width = Convert.ToInt32(categoryPanleList.Width * 0.98);
                //panel.Left = (categoryPanleList.Width - panel.Width) / 2;
                foreach (Control chCnt in panel.Controls)
                {
                    string[] a = chCnt.Name.Split(',');
                    if (a.Length > 0)
                    {
                        if (a[1] == "image") { chCnt.Width = 100; chCnt.Left = 0; }
                        else if (a[1] == "name") { chCnt.Width = panel.Width - 260; chCnt.Left = 110; width = chCnt.Width; }
                        else if (a[1] == "show") { chCnt.Width = 55; chCnt.Left = width + 110; }
                        else if (a[1] == "delete") { chCnt.Width = 55; chCnt.Left = width + 185; }
                    }

                }
            }
        }
        /// ----- update text category------/////
        private void updateText(string id,string text)
        {
            if (loadPage) { prp.query("update category_sh set name='" + text + "' where id=" + id); }
        }
        private void delete(string id)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this Brand?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (prp.query("update category_sh set status_='disable' where id=" + id))
                {
                    retriveCategorey();
                }
            }
        }
        ///------ retrive categorey from database -------/////////
        private void retriveCategorey()
        {
            mainForm mainForm = new mainForm();
            loadPage = false;
            int heightElemnt = 55;
            int top = 0;
            categoryPanleList.Controls.Clear();
            prp.Connection.Close();
            prp.Connection.Open();
            cmd = new OleDbCommand("select * from category_sh where status_='active'", prp.Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                //------- panel ----------//
                Panel panel = new Panel();
                panel.Font = new Font("Shruti", 16);
                //------- image ----------//
                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = dataReader["id"] + "," + "image";
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Height = heightElemnt;
                if (File.Exists(Environment.CurrentDirectory + "\\image\\category\\" + dataReader["img"] + ".jpeg"))
                {
                    pictureBox.Image = new Bitmap(Environment.CurrentDirectory + "\\image\\category\\" + dataReader["img"] + ".jpeg");
                }
                pictureBox.Click += (object obj, EventArgs ev) =>
                {
                    uploadIamge("update", pictureBox.Name);
                };
                panel.Controls.Add(pictureBox);
                //-------name----------//
                TextBox textBox = new TextBox();
                textBox.BorderStyle = BorderStyle.None;
                textBox.Top = 15;
                textBox.Name = dataReader["id"] + "," + "name";
                textBox.Padding = new Padding(210, 220, 220, 225);
                textBox.Multiline = true;
                textBox.Height = heightElemnt-15;
                textBox.ForeColor = Color.FromArgb(106, 106, 106);
                textBox.ReadOnly = true;
                textBox.DoubleClick += (object obj, EventArgs ev) =>
                {
                    textBox.ReadOnly = false;
                    textBox.Select( textBox.TextLength, 0);
                };
                textBox.TextChanged += (object obj, EventArgs ev) =>
                {
                    string[] name = textBox.Name.Split(',');
                    updateText(name[0],textBox.Text);
                  };
                textBox.Text = dataReader["name"].ToString();
                panel.Controls.Add(textBox);
                ////-----------show----------//
                //PictureBox ShowBtn = new PictureBox();
                //if (File.Exists(Environment.CurrentDirectory + "\\image\\category\\" + dataReader["img"] + ".jpeg"))
                //{
                //    ShowBtn.Image = new Bitmap(@"C:\Users\yahya\Downloads\share.png");
                //}
                //ShowBtn.Name = dataReader["id"] + "," + "show";
                //ShowBtn.SizeMode = PictureBoxSizeMode.Zoom;
                //ShowBtn.Click += mainForm.kryptonButton1_Click;
                //ShowBtn.BackColor = Color.FromArgb(0, 170, 122);
                //ShowBtn.ForeColor = Color.White;
                //ShowBtn.Height = heightElemnt;
                //panel.Controls.Add(ShowBtn);
                //------- Delete  ----------//
                PictureBox deleteBtn = new PictureBox();
                deleteBtn.Click += (object obj, EventArgs ev) =>
                {
                    string[] name = textBox.Name.Split(',');
                    delete(name[0]);
                };
                if (File.Exists(Environment.CurrentDirectory + "\\image\\category\\" + dataReader["img"] + ".jpeg"))
                {// deleteBtn.Image = new Bitmap(@"C:\Users\yahya\Downloads\bin (2).png");
                }
                deleteBtn.Name = dataReader["id"] + "," + "delete";
                deleteBtn.SizeMode = PictureBoxSizeMode.Zoom;
                deleteBtn.ForeColor = Color.White;
                deleteBtn.Height = heightElemnt;
                panel.Controls.Add(deleteBtn);

                if (top % 2 == 0)
                {
                    int R = 230, G = 230, B = 230;
                    panel.BackColor = Color.FromArgb(R, G, B);
                    pictureBox.BackColor = Color.FromArgb(R, G, B);
                    textBox.BackColor = Color.FromArgb(R, G, B);
                }
                else
                {
                    int R = 250, G = 250, B = 255;
                    panel.BackColor = Color.FromArgb(R, G, B);
                    pictureBox.BackColor = Color.FromArgb(R, G, B);
                    textBox.BackColor = Color.FromArgb(R, G, B);
                }
                panel.Height = heightElemnt;
                panel.Top = top * 60;
                top++;
                categoryPanleList.Controls.Add(panel);
            }
            resizeCategoriesList();
            prp.Connection.Close();
            loadPage = true;
        }
        ///------ upload image-------/////////
        private void uploadIamge(string type, string id)
        {// open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // image file path  

                    Random random = new Random();
                    newfileName = "" + "" + DateTime.Now.Year + "_" +
                       "" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_"
                       + DateTime.Now.Millisecond + "_" + random.Next(1, 999999999);
                    string destinationFilePath = Path.Combine(Environment.CurrentDirectory + "\\image\\category", newfileName + ".jpeg");
                    File.Copy(open.FileName, destinationFilePath);
                    // display image in picture box  
                    if (type == "add")
                    {
                        pictureBox1.Image = new Bitmap(open.FileName);
                    }
                    else if (type == "update")
                    {
                        foreach (Control panel in categoryPanleList.Controls)
                        {
                            foreach (Control chCnt in panel.Controls)
                            {

                                if (chCnt is PictureBox pictureBox && chCnt.Name == id)
                                {
                                    string[] newName = id.Split(',');
                                    if (prp.query("update category_sh set img='" + newfileName + "' where id=" + newName[0]))
                                    {

                                        string source = newfileName;
                                        pictureBox.Image = Image.FromFile(Environment.CurrentDirectory + "\\image\\category\\" + source + ".jpeg");
                                        newfileName = "";
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uploadIamge("add", "");
        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            if (newfileName != "" && categoreyNameTextbox.Text != "")
            {
                if (
                prp.query("insert into category_sh (name,img,status_) VALUES ('" + categoreyNameTextbox.Text + "','" + newfileName + "','active')"))
                {
                    categoreyNameTextbox.Text = "";
                    pictureBox1.Image = null;
                    newfileName = "";
                    retriveCategorey();
                }
            }
            else
            {
                if (categoreyNameTextbox.Text == "") { MessageBox.Show("please fill category name "); categoreyNameTextbox.Focus(); }
                else if (newfileName == "") MessageBox.Show("please select an image ");
            }
        }
    }
}
