using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專題
{
    public partial class Form2 : Form
    {
        int eyeID = 0;
        MedSysEntities mse = new MedSysEntities();
        public Form2(int id)
        {
            InitializeComponent();
            eyeID = id;
            LoadDataToCheckedListBoxCategory();
            //dataGridView5.CellClick += dataGridView5_CellClick;

        }

        private int selectedProductId = -1;
        private int selectedCategoryId = -1;

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the values from the clicked cell
                int productId = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
                //int categoryId = int.Parse(dataGridView5.Rows[e.RowIndex].Cells["CategoriesID"].Value.ToString());
                int cc = int.Parse(this.dataGridView5.CurrentCell.ToString());
                MessageBox.Show("cc=" + cc);
                // Update selected product and category IDs
                selectedProductId = productId;
                //selectedCategoryId = categoryId;
            }
        }

        private void LoadDataToCheckedListBoxCategory()
        {
            //var categories = mse.ProductsCategories.ToList();
            var q = from n in mse.ProductsCategories
                    select n.CategoriesName;
            foreach (var n in q)
            {

            }
            checkedListBox1.DisplayMember = "CategoriesName";
            checkedListBox1.ValueMember = "CategoriesID";
            checkedListBox1.DataSource = q.ToList();
        }





        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
            checkPage();


            var q = from d in mse.Employees
                    select new { 員工編號 = d.EmployeeID, 員工姓名 = d.EmployeeName, 員工生日 = d.EmployeeBirthDate, 員工電話 = d.EmployeePhoneNum, 員工信箱 = d.EmployeeEmail, 員工密碼 = d.EmployeePassWord, 員工類別 = d.EmployeeClass.Class };

            var q3 = from d in mse.EmployeeClasses
                     select d.Class;

            this.cboxClass.DataSource = q3.ToList();
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabProduct);
            var q = from n in mse.Products
                    select new
                    {
                        n.ProductID,
                        n.ProductName,
                        n.UnitPrice,
                        n.License,
                        n.Ingredient,
                        n.Description,
                        Count = n.ProductsClassifications.Count()
                    };
            this.bindingSource1.DataSource = q.ToList();
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.dataGridView4.DataSource = this.bindingSource1;
        }


        private void checkPage()
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            var q = from d in mse.Employees
                    where d.EmployeeName == txtName.Text
                    select new { 員工編號 = d.EmployeeID, 員工姓名 = d.EmployeeName, 員工生日 = d.EmployeeBirthDate, 員工電話 = d.EmployeePhoneNum, 員工信箱 = d.EmployeeEmail, 員工密碼 = d.EmployeePassWord, 員工類別 = d.EmployeeClass.Class };

            this.dataGridView1.DataSource = q.ToList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {


            if (txtName.Text == "" || txtPhone.Text == "" || txtMail.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("員工資料不完整", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (mse)
                {
                    var q = new Employee
                    {
                        EmployeeName = txtName.Text,
                        EmployeeClassID = cboxClass.SelectedIndex + 1,
                        EmployeeBirthDate = dateBirth.Value,
                        EmployeePhoneNum = txtPhone.Text,
                        EmployeeEmail = txtMail.Text,
                        EmployeePassWord = txtPwd.Text
                    };

                    mse.Employees.Add(q);
                    mse.SaveChanges();
                }

                var q2 = from d in mse.Employees
                         select new { 員工編號 = d.EmployeeID, 員工姓名 = d.EmployeeName, 員工生日 = d.EmployeeBirthDate, 員工電話 = d.EmployeePhoneNum, 員工信箱 = d.EmployeeEmail, 員工密碼 = d.EmployeePassWord, 員工類別 = d.EmployeeClass.Class };

                this.dataGridView1.DataSource = q2.ToList();
            }


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dlg.FileName;
            }
        }


        private void btnSearchCla_Click(object sender, EventArgs e)
        {


            var q = from d in mse.EmployeeClasses
                    where d.Class == txtEmpClass.Text
                    select new { 員工類別編號 = d.EmployeeClassID, 員工類別 = d.Class, 部落格權限 = d.BlogPermissionID };

            this.dataGridView3.DataSource = q.ToList();
        }

        private void btnAddCla_Click(object sender, EventArgs e)
        {

            if (txtEmpClass.Text == "")
            {
                MessageBox.Show("請輸入員工類別", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (mse)
                {
                    var q = new EmployeeClass { Class = txtEmpClass.Text };
                    mse.EmployeeClasses.Add(q);
                    mse.SaveChanges();
                }
            }
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                
                bindProduct();
            }
        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }
        public void bindProduct()
        {
            int x = (int)this.dataGridView4.CurrentRow.Cells[0].Value;
            var q = from n in mse.Products
                    where n.ProductID == x
                    select new
                    {
                        Name = n.ProductName,
                        Price = n.UnitPrice,
                        License = n.License,
                        Ingredient = n.Ingredient,
                        Description = n.Description,
                        n.Photo
                    };

            foreach (var g in q)
            {
                this.txtProductName.Text = g.Name;
                this.txtPrice.Text = g.Price.ToString();
                this.txtIngredient.Text = g.Ingredient;
                this.txtLicense.Text = g.License;
                this.txtDescription.Text = g.Description;
                System.IO.MemoryStream ms = new MemoryStream(g.Photo);
                this.pictureBox2.Image = Image.FromStream(ms);
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
            bindProduct();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.dataGridView4.Rows.Count - 1;
            bindProduct();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            System.IO.MemoryStream ms = new MemoryStream();
            this.pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytes = ms.GetBuffer();
            product.ProductName = this.txtProductName.Text;
            product.UnitPrice = int.Parse(this.txtPrice.Text);
            product.License = this.txtLicense.Text;
            product.Description = this.txtDescription.Text;
            product.Ingredient = this.txtIngredient.Text;
            product.Photo = bytes;
            mse.Products.Add(product);
            mse.SaveChanges();
            this.Read_RefreshDataGridView();
        }

        private void Read_RefreshDataGridView()
        {
            this.dataGridView4.DataSource = null;
            var q = from n in mse.Products
                    select new
                    {
                        n.ProductID,
                        n.ProductName,
                        n.UnitPrice,
                        n.License,
                        n.Ingredient,
                        n.Description,
                        Count = n.ProductsClassifications.Count()
                    };
            this.bindingSource1.DataSource = q.ToList();
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.dataGridView4.DataSource = this.bindingSource1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = Image.FromFile(op.FileName);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var product = (from n in mse.Products
                           where n.ProductName == this.txtProductName.Text
                           select n
                     ).FirstOrDefault();
            var productc = from n in mse.ProductsClassifications
                           where n.ProductID == product.ProductID
                           select n;
            if (productc != null)
            {
                foreach (var i in productc)
                {
                    this.mse.ProductsClassifications.Remove(i);
                }
                this.mse.SaveChanges();
                if (product == null) return;

                this.mse.Products.Remove(product);
                this.mse.SaveChanges();
                this.Read_RefreshDataGridView();

                this.txtProductName.Clear();
                this.txtPrice.Clear();
                this.txtLicense.Clear();
                this.txtDescription.Clear();
                this.txtIngredient.Clear();
                this.pictureBox2.Image = null;


            }
            else
            {
                return;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.label19.Text = "請選擇產品編號";
            comboBox1.Text = "產品編號";
            comboBox1.Items.Clear();
            this.tabControl1.SelectTab(tabClass);
            var q = from n in mse.Products
                    select n.ProductID;


            foreach (var i in q)
            {
                comboBox1.Items.Add(i.ToString());
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = int.Parse(this.comboBox1.Text);
            var q = from n in mse.ProductsClassifications
                     where n.ProductID == x
                     select new
                     {
                         產品名稱 = n.Product.ProductName,
                         保健食品分類 = n.ProductsCategory.CategoriesName
                     };

            this.dataGridView5.DataSource = q.ToList();


            //var q2 = (from n2 in mse.ProductsClassifications
            //    where n2.ProductID == x
            //    select n2.Product.ProductName).FirstOrDefault();

            //this.label19.Text = q2.ToString(); 


        }







        private void LoadDataToCheckListBox()
        {
            //Add Product

            // ProductsCategory productsCategory = new ProductsCategory { };
            // productsCategory.ProductsClassifications = this.

            // //Product product = new Product { ProductName = "Test " + DateTime.Now.ToString(), Discontinued = true };
            // //this.mse.Products.Add(product);
            // //this.mse.SaveChanges();

            // //this.Read_RefreshDataGridView();


            // var selectedCatagory = mse.ProductsCategories.Select(CategoryUpdate => CategoryUpdate.CategoriesID).ToList();


            //this.checkedListBox1.DataSource = selectedCatagory.ToList();


        }

        private void button7_Click(object sender, EventArgs e)
        {


            if (comboBox1.SelectedItem != null)
            {

                int productId = int.Parse(comboBox1.Text);
                string categoryName = checkedListBox1.Text;
                int categoryId = checkedListBox1.SelectedIndex + 1;

                mse.ProductsClassifications.Add(new ProductsClassification { ProductID = productId, CategoriesID = categoryId });
                mse.SaveChanges();

                var q = from n in mse.ProductsClassifications
                        where n.ProductID == productId
                        select new
                        {
                            //ProductID = n.ProductID,
                            //CategoryID = n.CategoriesID,
                            產品名稱 = n.Product.ProductName,
                            保健食品分類 = n.ProductsCategory.CategoriesName
                        };
                this.dataGridView5.DataSource = q.ToList();




            }
        }

        private void AddDataToProductsClassification(int productId, int categoryId)
        {




        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // 檢查是否已經存在相同的 ProductID
            int productId = GetProductIdByName(this.txtProductName.Text);

            if (productId != -1)
            {
                // 如果存在，執行更新操作
                UpdateProduct(productId);
            }
            else
            {
                // 如果不存在，執行新增操作
                AddNewProduct();
            }

            // 刷新資料
            this.Read_RefreshDataGridView();
        }

        private int GetProductIdByName(string productName)
        {
            // 查詢資料庫，獲取指定 ProductName 的 ProductID
            var product = mse.Products.FirstOrDefault(p => p.ProductName == productName);

            if (product != null)
            {
                return product.ProductID;
            }

            return -1; // 如果找不到，返回 -1
        }

        private void UpdateProduct(int productId)
        {
            // 使用 productId 進行更新操作
            var existingProduct = mse.Products.Find(productId);

            if (existingProduct != null)
            {
                System.IO.MemoryStream ms = new MemoryStream();
                this.pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bytes = ms.GetBuffer();

                // 更新屬性
                existingProduct.UnitPrice = int.Parse(this.txtPrice.Text);
                existingProduct.License = this.txtLicense.Text;
                existingProduct.Description = this.txtDescription.Text;
                existingProduct.Ingredient = this.txtIngredient.Text;
                existingProduct.Photo = bytes;

                mse.SaveChanges();
            }
        }

        private void AddNewProduct()
        {
            // 如果找不到相同的 ProductID，執行新增操作
            Product newProduct = new Product();
            System.IO.MemoryStream ms = new MemoryStream();
            this.pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytes = ms.GetBuffer();

            // 設定新增資料的屬性
            newProduct.ProductName = this.txtProductName.Text;
            newProduct.UnitPrice = int.Parse(this.txtPrice.Text);
            newProduct.License = this.txtLicense.Text;
            newProduct.Description = this.txtDescription.Text;
            newProduct.Ingredient = this.txtIngredient.Text;
            newProduct.Photo = bytes;

            mse.Products.Add(newProduct);
            mse.SaveChanges();
        }

        private void button8_Click(object sender, EventArgs e)


        {
            // 確保有選中的資料行
            if (dataGridView5.SelectedRows.Count > 0)
            {
                // 獲取選中行的 ProductName 或 CategoriesName
                string selectedProductName = dataGridView5.SelectedRows[0].Cells["產品名稱"].Value.ToString();
                string selectedCategoriesName = dataGridView5.SelectedRows[0].Cells["保健食品分類"].Value.ToString();

                // 在 ProductsClassification 表中找到並刪除相應的記錄
                var classificationsToDelete = mse.ProductsClassifications
                    .Where(pc => pc.Product.ProductName == selectedProductName && pc.ProductsCategory.CategoriesName == selectedCategoriesName);

                mse.ProductsClassifications.RemoveRange(classificationsToDelete);
                mse.SaveChanges();

                // 更新 DataGridView5
                Read_RefreshDataGridView5();
            }
            else
            {
                MessageBox.Show("請先選擇一行進行刪除。");
            }

            this.Read_RefreshDataGridView5();
            

           
        }
        void Read_RefreshDataGridView5()
        {
            this.dataGridView1.DataSource = null;
            int productId = int.Parse(comboBox1.Text);
            var q = from n in mse.ProductsClassifications
                    where n.ProductID == productId
                    select new
                    {
                        產品名稱 = n.Product.ProductName,
                        保健食品分類 = n.ProductsCategory.CategoriesName
                    };
            this.dataGridView5.DataSource = q.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 輸入的關鍵字
            string searchKeyword = this.txtProductName.Text.Trim();

            // 重新讀取並篩選資料
            Read_RefreshDataGridView(searchKeyword);
            // 顯示全部資料
            //Read_RefreshDataGridView();

        }

        private void Read_RefreshDataGridView(string searchKeyword)
        {
            this.dataGridView4.DataSource = null;

            // 使用 LINQ 查詢，篩選符合條件的資料
            var q = from n in mse.Products
                    where n.ProductName.Contains(searchKeyword) ||
                          n.License.Contains(searchKeyword) ||
                          n.Ingredient.Contains(searchKeyword) ||
                          n.Description.Contains(searchKeyword)
                    select new
                    {
                        n.ProductID,
                        n.ProductName,
                        n.UnitPrice,
                        n.License,
                        n.Ingredient,
                        n.Description,
                        Count = n.ProductsClassifications.Count()
                    };

            // 更新 DataGridView
            this.bindingSource1.DataSource = q.ToList();
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.dataGridView4.DataSource = this.bindingSource1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.txtProductName.Clear();
            this.txtPrice.Clear();
            this.txtLicense.Clear();
            this.txtDescription.Clear();
            this.txtIngredient.Clear();
            this.pictureBox2.Image = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 顯示全部資料，將 searchKeyword 設為空字串
            Read_RefreshDataGridView2(string.Empty);
        }

        private void Read_RefreshDataGridView2(string searchKeyword)
        {
            this.dataGridView4.DataSource = null;

            // 使用 LINQ 查詢，篩選符合條件的資料
            var q = from n in mse.Products
                    where n.ProductName.Contains(searchKeyword) ||
                          n.License.Contains(searchKeyword) ||
                          n.Ingredient.Contains(searchKeyword) ||
                          n.Description.Contains(searchKeyword)
                    select new
                    {
                        n.ProductID,
                        n.ProductName,
                        n.UnitPrice,
                        n.License,
                        n.Ingredient,
                        n.Description,
                        Count = n.ProductsClassifications.Count()
                    };

            // 更新 DataGridView
            this.bindingSource1.DataSource = q.ToList();
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.dataGridView4.DataSource = this.bindingSource1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            int Max = int.Parse(textBox1.Text);
            int Min = int.Parse(textBox2.Text);
            
            if (Max < Min)
            {
                MessageBox.Show("價格區間輸入錯誤!，最小值應小於等於最大值");
            }else if(textBox1.Text != "" &&textBox2.Text != "")
            {
                var q = from n in mse.Products
                        where n.UnitPrice > Min && n.UnitPrice < Max
                        select n;
                dataGridView4.DataSource= q.ToList();
                //查區間
            }else if(textBox1.Text != "")
            {
                //查大於min的產品價格
                var q2 = from n2 in mse.Products
                         where n2.UnitPrice >= Min
                         select n2;
                dataGridView4.DataSource = q2.ToList();

            }
            else if (textBox2.Text != "")
            {
                //查小於Max數字的產品
                var q3 = from n3 in mse.Products
                         where n3.UnitPrice >= Max
                         select n3;
                dataGridView4.DataSource = q3.ToList();
            }
            else if(textBox2.Text =="" &&textBox1.Text == "")
            {
                //亮出所有產品
                // 顯示全部資料
                Read_RefreshDataGridView2(string.Empty);
            }
            
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}

    

    
