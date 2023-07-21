using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;

namespace musk_shop_store
{
    public partial class product : UserControl
    {
        public product()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbDataReader dataReader;
        DataTable dataTable;
        OleDbDataAdapter adapter;
        string newfileName;
        // load lenght of brand
        private int catLenght()
        {
            int a = 0; ;
            try
            {
                prp.Connection.Close();
                prp.Connection.Open();
                cmd = new OleDbCommand("select count(id) from category_sh where status_='active'", prp.Connection);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    a = dataReader.GetInt32(0);
                }
                prp.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return a;
        }
        // load value for brand
        string[,] categorey;
        private void loadCategoreyValue()
        {
            BrandAdd.Items.Clear();
            categorey = new string[catLenght(), 2];
            prp.Connection.Close();
            prp.Connection.Open();
            BrandAdd.Items.Add("All");
            cmd = new OleDbCommand("select id,name from category_sh where status_='active'", prp.Connection);
            dataReader = cmd.ExecuteReader();
            int i = 0;
            while (dataReader.Read())
            {
                categorey[i, 0] = dataReader["id"].ToString();
                categorey[i, 1] = dataReader["name"].ToString();
                BrandAdd.Items.Add(dataReader["name"]);
                i++;
            }
            prp.Connection.Close();
        }
        ///------ resize product list -------/////////
        private void ResizeProductList()
        {
            //chooseDesignDatagrideView();
            foreach (Panel p in productListPanel.Controls)
            {
                p.Width = Convert.ToInt32(productListPanel.Width * 0.97);
                foreach (Control chCntr in p.Controls)
                {
                    if (chCntr is RichTextBox)
                    {
                        chCntr.Width = NameAdd.Width;  
                    }
                }
            }
        }
        private void product_Load(object sender, EventArgs e)
        {
            CreateAList();
            loadCategoreyValue();
            //BtnAdd.Image = new Bitmap("C:\\Users\\DELL 7400\\Downloads\\plus.png");
            retriveProduct("", "", "");
        }

        private void product_SizeChanged(object sender, EventArgs e)
        {
            resizeAddProductBar();
            ResizeProductList();
        }

        ///---------------------- check brand
        private bool checkBrand()
        {
            bool a = false;
            for (int i = 1; i < BrandAdd.Items.Count; i++)
            {
                if (BrandAdd.Text == BrandAdd.Items[i].ToString())
                {
                    a = true;
                }
            }
            if (!a) { MessageBox.Show("Please Choose Right Brand"); BrandAdd.Select(); }
            return a;
        }

        private void ImageAdd_Click(object sender, EventArgs e)
        {
            ImageAdd.Image = null;
            UploadIamge("add", "");
            //productListPanel.Controls.Clear();
        }
        ///---- rsize add product control -------/////
        private void resizeAddProductBar()
        {
            int value = 270;
            if (AddPanel.Width < 700) { value = 170; }
            int auto = AddPanel.Width - isSearch.Width - ImageAdd.Width - value - BrandAdd.Width - GenderAdd.Width - BtnAdd.Width;
            isSearch.Left = 40;
            isSearch.Top = 15;
            label1.Left = 5;
            ImageAdd.Left = 135;
            label2.Left = ImageAdd.Left - 5;
            NameAdd.Width = auto;
            NameAdd.Left = 210;
            label3.Left = NameAdd.Left - 5;
            BrandAdd.Left = auto + 220;
            label4.Left = BrandAdd.Left - 5;
            GenderAdd.Left = auto + 350;
            label5.Left = GenderAdd.Left - 5;
            BtnAdd.Left = auto + 460;
            label6.Left = BtnAdd.Left - 5;

        }
        /// ------------ retrive my products-------------/
        private void CreateAList()
        {
            for (int i = 0; i < 50; i++)
            {
                ////---- create a panel object -----///
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Width = Convert.ToInt32(panel1.Width * 0.97);
                panel.Height = 60;
                productListPanel.Controls.Add(panel);
                ////---- create the list number -----///
                Label listNum = new Label();
                listNum.Text = "  " + Convert.ToInt32(i + 1);
                listNum.Width = label1.Width + 50;
                listNum.Height = height;
                listNum.TextAlign = ContentAlignment.MiddleLeft;
                panel.Controls.Add(listNum);
                ////---- create the image -----///
                PictureBox image = new PictureBox();
                image.Width = ImageAdd.Width;
                image.Height = 55;
                image.Name = "name";
                panel.Controls.Add(image);
                image.SizeMode = PictureBoxSizeMode.Zoom;
                ///------- create a textbox for name -------//
                RichTextBox txtName = new RichTextBox();
                txtName.BorderStyle = BorderStyle.None;
                txtName.Height = 55;
                txtName.Margin = new Padding(10, 0, 0, 0);
                panel.Controls.Add(txtName);
                if (textBoxWidth == false)
                {
                    txtName.Width = NameAdd.Width + 50;
                }
                else
                {
                    txtName.Width = NameAdd.Width;
                }
                ///------- create a combobox for brand -------//
                ComboBox BrandCmb = new ComboBox();
                BrandCmb.Width = BrandAdd.Width;
                BrandCmb.Height = 55;
                BrandCmb.FlatStyle = FlatStyle.Flat;
                BrandCmb.Margin = new Padding(10, 15, 0, 0);
                panel.Controls.Add(BrandCmb);
                ///------- create a textbox for name -------//
                ComboBox gender = new ComboBox();
                gender.Width = GenderAdd.Width;
                gender.Height = 55;
                gender.FlatStyle = FlatStyle.Flat;
                gender.Margin = new Padding(10, 15, 0, 0);
                panel.Controls.Add(gender);
                ///------- create a button for delete -------//
                PictureBox delete = new PictureBox();
                if (File.Exists(Environment.CurrentDirectory + "\\image\\delete.png"))
                    delete.Image = new Bitmap(Environment.CurrentDirectory + "\\image\\delete.png");
                delete.SizeMode = PictureBoxSizeMode.StretchImage;
                delete.Margin = new Padding(25, 15, 0, 0);
                delete.Height = 35;
                delete.Width = 35;
                panel.Controls.Add(delete);
                ///------- create a button for open -------//
                PictureBox open = new PictureBox();
                if (File.Exists(Environment.CurrentDirectory + "\\image\\open.png"))
                    open.Image = new Bitmap(Environment.CurrentDirectory + "\\image\\open.png");
                open.SizeMode = PictureBoxSizeMode.StretchImage;
                open.Margin = new Padding(25, 15, 0, 0);
                open.Height = 35;
                open.Width = 35;
                panel.Controls.Add(open);
                ////------ finaly ----------------/////
                if (i % 2 == 0)
                {
                    panel.BackColor = Color.FromArgb(230, 230, 230);
                    txtName.BackColor = Color.FromArgb(230, 230, 230);
                    BrandCmb.BackColor = Color.FromArgb(230, 230, 230);
                    gender.BackColor = Color.FromArgb(230, 230, 230);
                }
            }
            if (textBoxWidth == false)
            {
                textBoxWidth = true;
            }
        }
        int top; int height = 60; string ImageProductPath;
        bool textBoxWidth = false, chooseBrandAndGender = false, selectImage = true;
        private void retriveProduct(string name, string categorey, string gender)
        {
            prp.Connection.Close();
            prp.Connection.Open();
            adapter = new OleDbDataAdapter("SELECT top 50 category_sh.name, product_sh.*, img_product_sh.img FROM " +
                "(category_sh INNER JOIN product_sh ON category_sh.ID = product_sh.ctg_id) LEFT JOIN img_product_sh" +
                " ON product_sh.ID = img_product_sh.prd_id where product_sh.name='" + name + "'", prp.Connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            prp.Connection.Close();

            DataRow[] dataRows = dataTable.Select();

            for (int i = 0; i < productListPanel.Controls.Count; i++)
            {
                productListPanel.Controls[i].Visible = true;
                if (i < dataRows.Length)
                {
                    DataRow row = dataRows[i];
                    //string categoryName = row["name"].ToString();
                    foreach(Control control in productListPanel.Controls[i].Controls)
                    {
                        if (control is PictureBox pictureBox &&
                               File.Exists(Environment.CurrentDirectory + "\\image\\product\\" + row["img"] + ".jpeg")
                               && control.Name == "name")
                        {
                            pictureBox.Image = new Bitmap(Environment.CurrentDirectory + "\\image\\product\\" + row["img"] + ".jpeg");
                        }
                        else if (control is RichTextBox)
                        { control.Text = row["product_sh.name"].ToString(); }
                        else if (control is ComboBox && chooseBrandAndGender == false)
                        { control.Text = row["category_sh.name"].ToString(); chooseBrandAndGender = true; }
                        else if (control is ComboBox && chooseBrandAndGender == true)
                        { control.Text = row["gender"].ToString(); chooseBrandAndGender = false; }
                    }
                }
                else
                    productListPanel.Controls[i].Visible = false;
            }

        }

        private void NameAdd_TextChanged(object sender, EventArgs e)
        {
            retriveProduct(NameAdd.Text, "", "");
        }

        ///------ upload image-------/////////
        private void UploadIamge(string type, string id)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Random random = new Random();
                    newfileName = "" + "" + DateTime.Now.Year + "_" +
                       "" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_"
                       + DateTime.Now.Millisecond + "_" + random.Next(1, 999999999);
                    string destinationFilePath = Path.Combine(Environment.CurrentDirectory + "\\image\\product", newfileName + ".jpeg");
                    File.Copy(open.FileName, destinationFilePath);
                    // display image in picture box  
                    if (type == "add")
                    {
                        ImageAdd.Image = new Bitmap(open.FileName);
                    }
                    else if (type == "update")
                    {
                        //foreach (Control panel in productListPanel.Controls)
                        //{
                        //    foreach (Control chCnt in panel.Controls)
                        //    {

                        //        if (chCnt is PictureBox pictureBox && chCnt.Name == id)
                        //        {
                        //            string[] newName = id.Split(',');
                        //            if (prp.query("update product_sh set img='" + newfileName + "' where id=" + newName[0]))
                        //            {

                        //                string source = newfileName;
                        //                pictureBox.Image = Image.FromFile(Environment.CurrentDirectory + "\\image\\product\\" + source + ".jpeg");
                        //                newfileName = "";
                        //                break;
                        //            }
                        //        }

                        //    }
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (NameAdd.Text != "" && checkBrand() == true && (GenderAdd.Text == "Fe-Male" || GenderAdd.Text == "Male"))
            {
                //    BtnAdd.Image = new Bitmap("C:\\Users\\DELL 7400\\Downloads\\loader.png");
                //BtnAdd.Enabled = false;
                if (prp.query("insert into product_sh(name,ctg_id,gender,status_) " +
                    "values('" + NameAdd.Text + "'," + categorey[BrandAdd.SelectedIndex, 0] + ",'" + GenderAdd.SelectedItem + "','active')"))
                {
                    //MessageBox.Show("");
                    if (newfileName != "")
                    {
                        int a = prp.retNum("select max(id) from product_sh");
                        if (prp.query("insert into img_product_sh(prd_id,img) values(" + a + ",'" + newfileName + "')"))
                        {
                            //newfileName = "";
                        }
                    }
                    retriveProduct("", "", "");
                }
                // BtnAdd.Image = new Bitmap("C:\\Users\\DELL 7400\\Downloads\\plus.png");
                //BtnAdd.Enabled = true;
            }
            else if (NameAdd.Text == "") { MessageBox.Show("Please Fill Name Box"); NameAdd.Focus(); }
            else if (GenderAdd.Text != "Fe-Male" || GenderAdd.Text != "Male") { MessageBox.Show("Please Choose Right Gender!"); ; GenderAdd.Focus(); }
        }

    }
}
