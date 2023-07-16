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
            ResizeProductList();

        }
        ///------ resize product list -------/////////
        private void ResizeProductList()
        {
            //chooseDesignDatagrideView();
            //foreach (Panel p in productListPanel.Controls)
            //{
            //    int left = 3;
            //    p.Width = Convert.ToInt32(productListPanel.Width * 0.97);
            //    foreach (Control chCntr in p.Controls)
            //    {
            //        string[] name = chCntr.Name.Split(',');
            //        if (name.Length > 1)
            //        {
            //            if (name[1] == "name") { chCntr.Left = NameAdd.Left; chCntr.Width = NameAdd.Width; chCntr.Height = NameAdd.Height; }
            //            else if (name[1] == "brand") { chCntr.Left = BrandAdd.Left - left; }
            //            else if (name[1] == "gender") { chCntr.Left = GenderAdd.Left - left; }
            //            else if (name[1] == "image") { chCntr.Left = ImageAdd.Left - left; }
            //            else if (name[1] == "delete") { chCntr.Left = BtnAdd.Left + left; }
            //            else if (name[1] == "open") { chCntr.Left = BtnAdd.Left + 5 + BtnAdd.Width; }
            //        }
            //    }
            //}
        }
        private void product_Load(object sender, EventArgs e)
        {
            loadCategoreyValue();
            //BtnAdd.Image = new Bitmap("C:\\Users\\DELL 7400\\Downloads\\plus.png");
            retriveProduct("", "", "");
        }

        private void product_SizeChanged(object sender, EventArgs e)
        {
            resizeAddProductBar();
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
            UploadIamge("add", "");
            //productListPanel.Controls.Clear();
        }
        /// ------------ retrive my products-------------/
        int top;int height = 60;string ImageProductPath = "D:\\perfume_shop_storg\\musk_shop_store\\bin\\Debug\\image\\download.png";
        private void retriveProduct(string name, string categorey, string gender)
        {
            productListPanel.Controls.Clear();
            top = 0;
            prp.Connection.Close();
            prp.Connection.Open();
            cmd = new OleDbCommand("SELECT  category_sh.name, product_sh.*, img_product_sh.img FROM (category_sh INNER JOIN product_sh ON category_sh.ID = product_sh.ctg_id) LEFT JOIN img_product_sh ON product_sh.ID = img_product_sh.prd_id;", prp.Connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                ////---- create a panel object -----///
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Width = Convert.ToInt32(panel1.Width * 0.97);
                panel.Height = 60;
                productListPanel.Controls.Add(panel);
                ////---- create the list number -----///
                Label listNum = new Label();
                listNum.Text = top.ToString();
                listNum.Width = label1.Width+20;
                listNum.Height = height;
                listNum.TextAlign=ContentAlignment.MiddleCenter;
                panel.Controls.Add(listNum);
                ////---- create the image -----///
                PictureBox image =new PictureBox();
                image.Width = ImageAdd.Width;
                image.Height = 60;
                if(File.Exists(Environment.CurrentDirectory + "\\image\\product" + dataReader["img"] + ".jpeg"))
                {
                    ImageProductPath = Environment.CurrentDirectory + "\\image\\product" + dataReader["img"] + ".jpeg";
                }
                image.Image = new Bitmap(ImageProductPath);
                panel.Controls.Add(image);
                image.SizeMode = PictureBoxSizeMode.Zoom;
                ////------ finaly ----------------/////
                if (top % 2 == 0) { panel.BackColor =Color.FromArgb(230, 230, 230); }
                top++;
            }

            prp.Connection.Close();
            //resizeProductList();
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


            foreach (Control panel in productListPanel.Controls)
            {
                foreach (Control control in panel.Controls)
                {
                    control.Dispose();
                }
                panel.Controls.Clear();
                panel.Dispose();
            }
            productListPanel.Controls.Clear();
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
                            newfileName = "";
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
