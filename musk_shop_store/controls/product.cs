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
            resizeProductList();

        }
        ///------ resize product list -------/////////
        private void resizeProductList()
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
            uploadIamge("add", "");
            //productListPanel.Controls.Clear();
        }
        //------ retrive product ----------////
        private void chooseDesignDatagrideView()
        {
            // Customize the default cell style
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            // Customize the header cell style
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            // Auto-size columns based on their contents
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Set a minimum height for rows
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowsDefaultCellStyle.Minimum = 50;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.EnableHeadersVisualStyles = false;// Adjust cell height

            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Adjust row height // Specify the desired height in pixels

        }
        private void retriveProduct(string name, string categorey, string gender)
        {
            chooseDesignDatagrideView();
            dataGridView1.Columns.Clear();
            // Create a DataGridViewImageColumn
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Image"; 
            //imageColumn.FillWeight = 200;
            dataGridView1.Columns.Add(imageColumn);
            ///////////////////////////////////////////////////////////////////////
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.Name = "Name";
            //textColumn.FillWeight = 200;
            dataGridView1.Columns.Add(textColumn);
            // Assuming you have a list of image paths
            prp.Connection.Close();
            prp.Connection.Open();
            adapter = new OleDbDataAdapter("SELECT category_sh.name, product_sh.*, img_product_sh.img FROM (category_sh INNER JOIN product_sh ON category_sh.ID = product_sh.ctg_id) LEFT JOIN img_product_sh ON product_sh.ID = img_product_sh.prd_id;", prp.Connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            prp.Connection.Close();
            foreach(DataRow rows in dataTable.Rows)
            {

                object images= rows["img"];
                object prdName = rows["product_sh.name"];
                object gender_ = rows["gender"];
                object status = rows["status_"];
                object brand = rows["category_sh.name"];
                /////////////////////////////////////////////////////////////////////////////////////////////

                DataGridViewRow row = new DataGridViewRow();
                    row.Height = 100;
                    DataGridViewImageCell imageCell = new DataGridViewImageCell();
                    imageCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    row.Cells.Add(imageCell);
                if (File.Exists(Environment.CurrentDirectory + "\\image\\product\\" + images + ".jpeg"))
                {
                    Image image = Image.FromFile(Environment.CurrentDirectory + "\\image\\product\\" + images + ".jpeg");
                   
                    imageCell.Value = image;
                }
                    ///////////////////////////////////////////////////////////
                    DataGridViewTextBoxCell textCell = new DataGridViewTextBoxCell();
                    textCell.Value =prdName;
                    row.Cells.Add(textCell);
                    dataGridView1.Rows.Add(row);
                //MessageBox.Show(otherCellValue.ToString());
            }


                prp.Connection.Close();
            //resizeProductList();
        }
        ///------ upload image-------/////////
        private void uploadIamge(string type, string id)
        {
            // open file dialog   
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
