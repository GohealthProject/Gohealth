using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專題.Model;

namespace 期中專題
{
    public partial class Form2 : Form
    {   
        BlogManage bg = new BlogManage();
        int empID = 0;
        int blogPermission = 0;
        MedSysEntities mse = new MedSysEntities();
        public Form2(int id)
        {
            InitializeComponent();
            empID = id;
            var q = mse.Products.Select(n => n.ProductID);
            var q2 = mse.ProductsCategories.Select(n => n.CategoriesName);
            foreach (var x in q2)
            {
                this.checkedListBox1.Items.Add(x);
            }
            foreach (var x in q)
            {
                this.comboBox1.Items.Add(x);
            }
            PermissionToEdit(CheckBlogPermmison(empID));

            MessageBox.Show(blogPermission + "sss");

            var qu = (from x in mse.Employees
                     where x.EmployeeID == empID
                     select new { User = x.EmployeeName }).ToList();

            lblUser.Text = $"歡迎，{ qu[0].User}";
        }
        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabEmp);
            var q = mse.EmployeeClasses.Select(n => n.Class);
            cboxClass.DataSource = q.ToList();
            if (this.dataGridView1.DataSource == null)
            {
                Read_RefreshDataGridView("employee");
                bindEmployee();
            }
            //else
            //{
            //    MessageBox.Show("Test");
            //}

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabEmpCla);

            var q = from d in mse.EmployeeClasses
                    select new
                    {
                        類別編號 = d.EmployeeClassID,
                        員工類別 = d.Class,
                        部落格權限 = d.BlogManagement.PermissionType
                    };
            var q2 = from d in mse.BlogManagements
                     select d.PermissionType;

            this.cboxP.DataSource = q2.ToList();
            this.dataGridView3.DataSource = q.ToList();

            txtEmpClass.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.CurrentCellChanged -= DataGridView1_CurrentCellChanged;
            var q = mse.Employees.Where(n => n.EmployeeName == txtName.Text).Select(n => new { 員工編號 = n.EmployeeID, 員工姓名 = n.EmployeeName, 員工生日 = n.EmployeeBirthDate, 員工電話 = n.EmployeePhoneNum, 員工信箱 = n.EmployeeEmail, 員工密碼 = n.EmployeePassWord, 員工類別 = n.EmployeeClass.Class });
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
            Read_RefreshDataGridView("employee");
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
            var q = mse.EmployeeClasses.Where(n => n.Class == txtEmpClass.Text).Select(n => new { 員工類別編號 = n.EmployeeClassID, 員工類別 = n.Class, 部落格權限 = n.BlogPermissionID });
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
                var q = new EmployeeClass { Class = txtEmpClass.Text };
                    mse.EmployeeClasses.Add(q);
                    mse.SaveChanges();
            }
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
            txtProductName.Text = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = this.dataGridView4.CurrentRow.Cells[2].Value.ToString();
            txtLicense.Text = this.dataGridView4.CurrentRow.Cells[3].Value.ToString();
            txtIngredient.Text = this.dataGridView4.CurrentRow.Cells[4].Value.ToString();
            txtDescription.Text = this.dataGridView4.CurrentRow.Cells[5].Value.ToString();
            int x = (int)this.dataGridView4.CurrentRow.Cells[0].Value;
            var q = mse.Products.Where(n => n.ProductID == x).Select(n => new { n.Photo });
            System.IO.MemoryStream ms = new MemoryStream(q.ToList()[0].Photo);
            pictureBox2.Image = Image.FromStream(ms);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }



        private void Read_RefreshDataGridView(string c)
        {
            if (c == "product")
            {
                this.dataGridView4.DataSource = null;
                var q = mse.Products.Select(n => new { n.ProductID, n.ProductName, n.UnitPrice, n.License, n.Ingredient, n.Description, Count = n.ProductsClassifications.Count() });
                this.bindingSource1.DataSource = q.ToList();
                this.bindingNavigator1.BindingSource = this.bindingSource1;
                this.dataGridView4.DataSource = this.bindingSource1;
            }
            else if (c == "employee")
            {
                txtName.Text = null;
                cboxClass.SelectedIndex = 0;
                dateBirth.Value = DateTime.Now;
                txtPhone.Text = null;
                txtMail.Text = null;
                txtPwd.Text = null;
                pictureBox1.Image = null;
                var q = from d in mse.Employees
                        select new
                        {
                            員工編號 = d.EmployeeID,
                            員工姓名 = d.EmployeeName,
                            員工生日 = d.EmployeeBirthDate,
                            員工電話 = d.EmployeePhoneNum,
                            員工信箱 = d.EmployeeEmail,
                            員工密碼 = d.EmployeePassWord,
                            員工類別 = d.EmployeeClass.Class,
                        };

                this.bindingSource2.DataSource = q.ToList();
                this.bindingNavigator2.BindingSource = this.bindingSource2;
                this.dataGridView1.DataSource = this.bindingSource2;
                this.bindingSource2.Position = 0;
                bindEmployee();
            }
            else if (c == "blog")
            {
                bg.reBlog();
                this.dgvBlogs.DataSource = bg.Allblogs;
            }

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
            var product = mse.Products.Where(n => n.ProductName == this.txtProductName.Text).Select(n => n).FirstOrDefault();
            var productc = mse.ProductsClassifications.Where(n => n.ProductID == product.ProductID).Select(n => n);
            if (productc != null)
            {
                foreach (var i in productc) { this.mse.ProductsClassifications.Remove(i); }
                this.mse.SaveChanges();
                if (product == null) return;
                this.mse.Products.Remove(product);
                this.mse.SaveChanges();
                this.Read_RefreshDataGridView("product");
            }
            else
            {
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabClass);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from n in mse.ProductsCategories
                    where n.ProductsClassifications.FirstOrDefault().Product.ProductName == comboBox1.Text
                    select n;
            this.dataGridView5.DataSource = q.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabProduct);
            Read_RefreshDataGridView("product");
        }

        private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
        {
            bindEmployee();
        }
        private void bindEmployee()
        {
            try
            {
                txtName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dateBirth.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtPhone.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtMail.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtPwd.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                cboxClass.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                int x = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
                var q = from n in mse.Employees
                        where n.EmployeeID == x
                        select new
                        {
                            n.EmployeePhoto
                        };
                System.IO.MemoryStream ms = new MemoryStream(q.ToList()[0].EmployeePhoto);
                //System.IO.MemoryStream ms = new MemoryStream((byte[])this.dataGridView1.CurrentRow.Cells[7].Value);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch (ArgumentNullException)
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "發生例外狀況", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
        {
            bindEmployee();
        }

        private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
        {
            bindEmployee();
        }

        private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
        {
            bindEmployee();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var q = mse.Products.Where(n => n.License == txtLicense.Text).Select(n => n).FirstOrDefault();
            if (q == null) { return; }

            q.ProductName = txtProductName.Text;
            q.Description = txtDescription.Text;
            q.Ingredient = txtIngredient.Text;
            q.UnitPrice = int.Parse(txtPrice.Text);
            q.License = txtLicense.Text;

            mse.SaveChanges();
            Read_RefreshDataGridView("product");

        }

        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtMail.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("員工資料不完整", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var qq = from n in mse.Employees
                         where n.EmployeeEmail == txtMail.Text || n.EmployeePhoneNum == txtPhone.Text
                         select new
                         {
                             n.EmployeePhoneNum,
                             n.EmployeeEmail
                         };
                if (qq.Count() == 0)
                {
                    byte[] arrImg = null;
                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
                    arrImg = stream.GetBuffer();
                    var q = new Employee
                    {
                        EmployeeName = txtName.Text,
                        EmployeeClassID = cboxClass.SelectedIndex + 1,
                        EmployeeBirthDate = dateBirth.Value,
                        EmployeePhoneNum = txtPhone.Text,
                        EmployeeEmail = txtMail.Text,
                        EmployeePassWord = txtPwd.Text,
                        EmployeePhoto = arrImg
                    };

                    mse.Employees.Add(q);
                    mse.SaveChanges();

                    Read_RefreshDataGridView("employee");
                   // button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("有重複資料");
                }

            }
        }

        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"確定要刪除 {txtName.Text} 的員工帳號資料嗎?", "警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var q = from d in mse.Employees
                        where d.EmployeePhoneNum == txtPhone.Text
                        select d;

                foreach (var d in q)
                {
                    mse.Employees.Remove(d);
                }

                mse.SaveChanges();

                Read_RefreshDataGridView("employee");
            }
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {


            if (txtName.Text == "" || txtPhone.Text == "" || txtMail.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("員工資料不完整", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                byte[] arrImg = null;
                MemoryStream stream = new MemoryStream();
                Image img;

                img = pictureBox1.Image;
                img.Save(stream, ImageFormat.Jpeg);
                arrImg = stream.GetBuffer();

                stream.Close();
                var data = from d in mse.Employees
                           where d.EmployeeName == txtName.Text
                           select d;

                foreach (var q in data)
                {
                    q.EmployeeName = txtName.Text;
                    q.EmployeeClassID = cboxClass.SelectedIndex + 1;
                    q.EmployeeBirthDate = dateBirth.Value;
                    q.EmployeePhoneNum = txtPhone.Text;
                    q.EmployeeEmail = txtMail.Text;
                    q.EmployeePassWord = txtPwd.Text;
                    q.EmployeePhoto = arrImg;
                }

                mse.SaveChanges();

                Read_RefreshDataGridView("employee");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                bindEmployee();
            }
        }

        int CheckBlogPermmison(int emp)
        {
            var q = mse.Employees.Where(n => n.EmployeeID == emp).Select(n => n.EmployeeClass.BlogPermissionID);
            MessageBox.Show(q.ToList()[0].ToString());
            return q.ToList()[0];
        }
        private void PermissionToEdit(int blogPermmisionID)
        {
            if (blogPermmisionID == 3)
            {
                this.btnBlogManagement.Enabled = false;
                blogPermission = blogPermmisionID;
            }
            else if (blogPermmisionID == 2) { blogPermission = blogPermmisionID; }
            else { blogPermission = blogPermmisionID; }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabBlogs);

            if (this.dgvBlogs.DataSource == null)
            {
                this.dgvBlogs.DataSource = bg.Allblogs;
                foreach(var item in bg.AllCat.ToList())
                {
                    cbCategory.Items.Add(item.BlogCategory1);
                }
            }
        }
        byte[] BlogImag = null;
        private void btnBrowsePics_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pbBlogImage.Image = Image.FromFile(ofd.FileName);
                this.pbBlogImage.Image.Save(ms, ImageFormat.Jpeg);
                BlogImag = ms.GetBuffer();
                ms.Close();
            }
        }

        private void btnInsertBlog_Click(object sender, EventArgs e)
        {
            using (mse)
            {
                Blog blog = new Blog
                {
                    Title = this.txtBlogTitle.Text,
                    ArticleClassID = this.cbCategory.SelectedIndex + 1,
                    Views = 0,
                    CreatedAt = DateTime.Now,
                    Content = this.rtbBlogContent.Text,
                    BlogImage = BlogImag,
                    EmployeeID = this.empID,
                };
                mse.Blogs.Add(blog);
                mse.SaveChanges();
                Read_RefreshDataGridView("blog");
            }
        }

        private void dgvBlogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int selectblogID = (int)this.dgvBlogs.CurrentRow.Cells[1].Value;
                FrmBlogDetails blogdetail = new FrmBlogDetails(selectblogID, blogPermission);
                blogdetail.BlogUpdatedOrDeleted += () => { Read_RefreshDataGridView("blog"); };

                blogdetail.bdBlogID = selectblogID;
                blogdetail.Show();
            }
        }

        private void bindingNavigatorMoveNextItem_Click_1(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void bindingNavigatorMoveLastItem_Click_1(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void bindingNavigatorMovePreviousItem_Click_1(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void bindingNavigatorMoveFirstItem_Click_1(object sender, EventArgs e)
        {
            bindProduct();
        }
        private void button11_Click(object sender, EventArgs e)
        {

            int Max = 0;
            int Min = 0;

            if (Max < Min)
            {
                MessageBox.Show("價格區間輸入錯誤!，最小值應小於等於最大值");
            }
            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                Max = int.Parse(textBox2.Text);
                Min = int.Parse(textBox1.Text);
                var q = from n in mse.Products
                        where n.UnitPrice > Min && n.UnitPrice < Max
                        select n;
                bindingSource1.DataSource = q.ToList();
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView4.DataSource = bindingSource1;
                bindProduct();
                //查區間
            }
            else if (textBox1.Text != "")
            {
                Min = int.Parse(textBox1.Text);
                //查大於min的產品價格
                var q2 = from n2 in mse.Products
                         where n2.UnitPrice >= Min
                         select n2;
                bindingSource1.DataSource = q2.ToList();
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView4.DataSource = bindingSource1;
                bindProduct();
            }
            else if (textBox2.Text != "")
            {
                Max = int.Parse(textBox2.Text);
                //查小於Max數字的產品
                var q3 = from n3 in mse.Products
                         where n3.UnitPrice < Max
                         select n3;
                bindingSource1.DataSource = q3.ToList();
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView4.DataSource = bindingSource1;
                bindProduct();
            }
            else if (textBox2.Text == "" && textBox1.Text == "")
            {
                //亮出所有產品
                // 顯示全部資料
                Read_RefreshDataGridView2(string.Empty);
            }

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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

                //顯示圖片
                int selectedProductID = int.Parse(this.comboBox1.Text);

                // 從 Products 表中查詢選取的 ProductID 的圖片資料
                var product = mse.Products.FirstOrDefault(p => p.ProductID == selectedProductID);

                if (product != null && product.Photo != null)
                {
                    // 如果找到對應的產品並且圖片不為空，將圖片顯示在 pictureBox3 中
                    using (MemoryStream ms = new MemoryStream(product.Photo))
                    {
                        this.pictureBox3.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // 如果找不到對應的產品或圖片為空，可以顯示默認的圖片或採取其他處理方式
                    this.pictureBox3.Image = null; // 這樣 pictureBox3 會清空圖片
                }


            

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
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
                    .Where(pc => pc.Product.ProductName == selectedProductName && pc.ProductsCategory.CategoriesName == selectedCategoriesName).FirstOrDefault();

                mse.ProductsClassifications.Remove(classificationsToDelete);
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

        private void Read_RefreshDataGridView5()
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

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            int x = (int)this.dataGridView4.CurrentRow.Cells[0].Value;

            var q2 = from n in mse.ProductsClassifications
                     where n.ProductID == x
                     select n;
            foreach(var g in q2)
            {
                mse.ProductsClassifications.Remove(g);
            }
            mse.SaveChanges();

            var q = (from n in mse.Products
                    where n.ProductID == x
                    select n).FirstOrDefault();

            mse.Products.Remove(q);
            mse.SaveChanges();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Product pd = new Product();

            pd.ProductName =this.txtProductName.Text;
            pd.Description =this.txtDescription.Text;
            pd.License =this.txtLicense.Text;
            pd.Ingredient=this.txtIngredient.Text;
            pd.UnitPrice=int.Parse(this.txtPrice.Text);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox2.Image.Save(ms, ImageFormat.Jpeg);
            pd.Photo = ms.GetBuffer();
            
            mse.Products.Add(pd);
            mse.SaveChanges();
            Read_RefreshDataGridView("product");
            bindProduct();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog op =new OpenFileDialog();
            System.IO.MemoryStream ms = new MemoryStream();
            if(op.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = Image.FromFile(op.FileName);
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            int x = (int)this.dataGridView4.CurrentRow.Cells[0].Value;

            var q = (from n in mse.Products
                    where n.ProductID == x
                    select n).FirstOrDefault();
            
            q.Description = this.txtDescription.Text;
            q.ProductName = this.txtProductName.Text;
            q.UnitPrice =int.Parse(this.txtPrice.Text);
            q.Ingredient =txtIngredient.Text;
            System.IO.MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, ImageFormat.Jpeg);
            q.Photo = ms.GetBuffer();
            q.License= this.txtLicense.Text;
            mse.SaveChanges();
            Read_RefreshDataGridView("product");
            bindProduct();
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                bindProduct();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabOrders);

            Order_Refresh();
            //var q2 = (from O in mse.Orders
            //          select O.Member.memberName).Distinct();

            //cBoxOrderName.DataSource = q2.ToList();

            ////----------------------

            //var q = from O in mse.Orders
            //        from Od in mse.OrderDetails
            //        where Od.orderID == O.orderID
            //        orderby O.orderID
            //        select new
            //        {
            //            訂單編號 = O.orderID,
            //            姓名 = O.Member.memberName,
            //            訂單日期 = O.orderDate,
            //            產品 = Od.Product.ProductName,
            //            價格 = Od.Product.UnitPrice,
            //            庫存 = Od.quantity,
            //            物流 = O.OrderShip.shipName,
            //            付款方式 = O.OrderPay.PayName,
            //            訂單狀態 = O.OrderState.stateName,
            //        };

            //this.bindingSourceOrders.DataSource = q.ToList();
            //this.bindingNavigatorOrders.BindingSource = this.bindingSourceOrders;
            //this.dGVOrders.DataSource = this.bindingSourceOrders;
            //this.bindingSource2.Position = 0;
        }

        private void btnOrderSearch_Click(object sender, EventArgs e)
        {
            var q = from o in mse.Orders
                    from od in mse.OrderDetails
                    where o.Member.memberName == cBoxOrderName.Text && od.orderID == o.orderID
                    orderby o.orderID
                    select new
                    {
                        訂單編號 = o.orderID,
                        姓名 = o.Member.memberName,
                        訂單日期 = o.orderDate,
                        產品 = od.Product.ProductName,
                        價格 = od.Product.UnitPrice,
                        庫存 = od.quantity,
                        物流 = o.OrderShip.shipName,
                        付款方式 = o.OrderPay.PayName,
                        訂單狀態 = o.OrderState.stateName,
                    };

            this.bindingSourceOrders.DataSource = q.ToList();
            this.bindingNavigatorOrders.BindingSource = this.bindingSourceOrders;
            this.dGVOrders.DataSource = this.bindingSourceOrders;
            this.bindingSource2.Position = 0;
        }

        private void btnOrderSearchDate_Click(object sender, EventArgs e)
        {
            var q = from o in mse.Orders
                    from od in mse.OrderDetails
                    where o.orderDate <= dateOrderdateMin.Value && o.orderDate >= dateOrderdateMax.Value && od.orderID == o.orderID
                    orderby o.orderID
                    select new
                    {
                        訂單編號 = o.orderID,
                        姓名 = o.Member.memberName,
                        訂單日期 = o.orderDate,
                        產品 = od.Product.ProductName,
                        價格 = od.Product.UnitPrice,
                        庫存 = od.quantity,
                        物流 = o.OrderShip.shipName,
                        付款方式 = o.OrderPay.PayName,
                        訂單狀態 = o.OrderState.stateName,
                    };

            this.bindingSourceOrders.DataSource = q.ToList();
            this.bindingNavigatorOrders.BindingSource = this.bindingSourceOrders;
            this.dGVOrders.DataSource = this.bindingSourceOrders;
            this.bindingSource2.Position = 0;
        }

        private void toolbtnOrderDelete_Click(object sender, EventArgs e)
        {
            int deleteid = (int)dGVOrders.CurrentRow.Cells[0].Value;


            DialogResult dr = MessageBox.Show($"確定要刪除編號 {deleteid} 的訂單嗎?", "警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var qod = from od in mse.OrderDetails
                          where od.orderID == deleteid
                          select od;

                foreach (var d in qod)
                {
                    mse.OrderDetails.Remove(d);
                }

                //------------------------------

                var q = from d in mse.Orders
                        where d.orderID == deleteid
                        select d;

                foreach (var d in q)
                {
                    mse.Orders.Remove(d);
                }

                mse.SaveChanges();

                Order_Refresh();
            }

        }
        private void Order_Refresh()
        {
            var q2 = (from O in mse.Orders
                      select O.Member.memberName).Distinct();

            cBoxOrderName.DataSource = q2.ToList();

            //----------------------

            var q = from O in mse.Orders
                    from Od in mse.OrderDetails
                    where Od.orderID == O.orderID
                    orderby O.orderID
                    select new
                    {
                        訂單編號 = O.orderID,
                        姓名 = O.Member.memberName,
                        訂單日期 = O.orderDate,
                        產品 = Od.Product.ProductName,
                        價格 = Od.Product.UnitPrice,
                        庫存 = Od.quantity,
                        物流 = O.OrderShip.shipName,
                        付款方式 = O.OrderPay.PayName,
                        訂單狀態 = O.OrderState.stateName,
                    };

            this.bindingSourceOrders.DataSource = q.ToList();
            this.bindingNavigatorOrders.BindingSource = this.bindingSourceOrders;
            this.dGVOrders.DataSource = this.bindingSourceOrders;
            this.bindingSource2.Position = 0;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabPage1);
            label22.Text = "產品上架狀態";

            comboBox2.Text = "產品名稱";
            comboBox2.Items.Clear();
            var q2 = from n2 in mse.Products
                     select n2.ProductName;


            foreach (var i in q2)
            {
                comboBox2.Items.Add(i.ToString());
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from n in mse.Products
                    where n.ProductName == comboBox2.Text
                    select new
                    {
                        status = n.Discontinued== true ? "上架中" : "已下架"
                    };


            var result = q.FirstOrDefault();
            if (result != null)
            {
                label25.Text = result.status;
            }


            string selectedProductName = comboBox2.SelectedItem as string;
            var product = mse.Products.FirstOrDefault(p => p.ProductName == selectedProductName);
            if (product != null)
            {
                textBox4.Text = product.UnitsInStock.ToString();
            }
            else
            {
                textBox4.Text = string.Empty;
            }


            var q2 = (from n2 in mse.Products
                      where n2.ProductName == selectedProductName
                      select new
                      {
                          n2.Photo
                      }).FirstOrDefault();


            if (q2 != null)
            {

                using (MemoryStream ms = new MemoryStream(product.Photo))
                {
                    this.pictureBox4.Image = Image.FromStream(ms);
                }
            }
            else
            {

                this.pictureBox4.Image = null;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string selectedProductName = comboBox2.SelectedItem as string;
            var product = mse.Products.FirstOrDefault(p => p.ProductName == selectedProductName);
            if (product != null)
            {
                product.Discontinued = true;
                mse.SaveChanges();

                var q = from n in mse.Products
                        where n.ProductName == comboBox2.Text
                        select new
                        {
                            status = n.Discontinued == true ? "上架中" : "已下架"
                        };
                var result = q.FirstOrDefault();
                if (result != null)
                {
                    label25.Text = result.status;
                }
                MessageBox.Show(comboBox2.Text + "商品已上架");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            string selectedProductName = comboBox2.SelectedItem as string;
            var product = mse.Products.FirstOrDefault(p => p.ProductName == selectedProductName);
            if (product != null)
            {
                product.Discontinued = false;
                mse.SaveChanges();
            }

            var q = from n in mse.Products
                    where n.ProductName == comboBox2.Text
                    select new
                    {
                        status = n.Discontinued == true ? "上架中" : "已下架"
                    };
            var result = q.FirstOrDefault();
            if (result != null)
            {
                label25.Text = result.status;
            }
            MessageBox.Show(comboBox2.Text + "商品已下架");
        }

        private void button16_Click(object sender, EventArgs e)
        {

            string selectedProductName = comboBox2.SelectedItem as string;
            var product = mse.Products.FirstOrDefault(p => p.ProductName == selectedProductName);

            if (product != null)
            {
                int additionalUnits = 0;
                if (int.TryParse(textBox3.Text, out additionalUnits))
                {

                    product.UnitsInStock += additionalUnits;
                    mse.SaveChanges();


                    var updatedProduct = mse.Products.FirstOrDefault(p => p.ProductName == selectedProductName);
                    if (updatedProduct != null)
                    {
                        textBox4.Text = updatedProduct.UnitsInStock.ToString();
                        MessageBox.Show("進貨成功，" + comboBox2.Text + "目前庫存:" + textBox4.Text);
                    }
                    else
                    {
                        textBox4.Text = "查詢產品時發生錯誤";
                    }
                }
                else
                {

                    textBox4.Text = "無效的數字";
                }
            }
            else
            {
                textBox4.Text = string.Empty;
            }
            textBox3.Text = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {

            string selectedProductName = comboBox2.SelectedItem as string;
            var product = mse.Products.FirstOrDefault(p => p.ProductName == selectedProductName);

            if (product != null)
            {
                int additionalUnits = 0;
                if (int.TryParse(textBox4.Text, out additionalUnits))
                {

                    var q = from p in mse.Products
                            where p.ProductName == selectedProductName
                            select new
                            {
                                p.UnitsInStock
                            };
                    product.UnitsInStock = additionalUnits;


                    mse.SaveChanges();

                    textBox4.Text = product.UnitsInStock.ToString();
                    MessageBox.Show("修改庫存數量成功，" + comboBox2.Text + "目前庫存:" + textBox4.Text);
                }
                else
                {

                    textBox4.Text = "無效的數字";
                }
            }
            else
            {
                textBox4.Text = string.Empty;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}


