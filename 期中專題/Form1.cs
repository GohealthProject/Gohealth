using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專題.Model;
using 期中專題.Properties;

namespace 期中專題
{
    public partial class Form1 : Form
    {
        bool flag = true;
        string[] st = null;
        int cbListCountMax = 0;
        int memberID = 0;
        int _Rcount = 0;
        int cbListPosition = 0;
        string gender = "男";
        int cbListCount = 0;
        bool gogo1 = true;
        int totalP = 0;
        public int plan = 0;
        MedSysEntities ms = new MedSysEntities();
        List<customBlog> cbList = null;
        CustomBlogManager cbM = new CustomBlogManager();
        BlogManage bg = new BlogManage();
        CCommentsManager coManager = new CCommentsManager();
        public Form1(int ID)
        {
            InitializeComponent();
            this.tabControl1.SelectTab(tabIndex);
            memberID = ID;
            var q = from n in ms.Members
                    where n.memberId == memberID
                    select n.memberName;
            this.label7.Text = $"{q.ToList()[0]} ";
            this.label15.Text = $"{q.ToList()[0]} 你好";

            //=======================
            listViewItemsAll.Columns.Add("檢查項目", 100);
            listViewItemsAll.Columns.Add("項目價格", 100);


            loaditems();
            combo_load();
            //===========================
            RPview1.View = View.Details;
            RPview2.View = View.Details;

            RPview1.Scrollable = true;

            RPview1.MultiSelect = false;
            RPview1.Columns.Add("項目", 150, HorizontalAlignment.Right);
            RPview1.Columns.Add("檢查結果", 70, HorizontalAlignment.Center);
            RPview1.Columns.Add("標準值", 70, HorizontalAlignment.Center);

            RPview2.Scrollable = true;

            RPview2.MultiSelect = false;
            RPview2.Columns.Add("項目", 150, HorizontalAlignment.Right);
            RPview2.Columns.Add("檢查結果", 70, HorizontalAlignment.Center);
            RPview2.Columns.Add("標準值", 70, HorizontalAlignment.Center);

        }

        private void combo_load()
        {
            var com = from p in ms.Projects
                      select new { Project = p.ProjectName, Price = p.projectPrice };
            foreach (var p in com)
            {

                this.comboboxProject.Items.Add($"{p.Project}------價格{p.Price:c2}"
                );
            }
            var com2 = from p in ms.Plans
                       select new { plans = p.planName };
            foreach (var p in com2)
            {
                this.comboboxPlan.Items.Add($"{p.plans}");
            }
        }

        private void loaditems()
        {
            var its = from p in ms.Items
                      select new { item = p.itemName, price = p.itemPrice };
            foreach (var p in its)
            {
                this.ItemCheck.Items.Add($"{p.item}|價格{p.price:c2}");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabReport);

            this.tabControl1.SelectTab(tabReport);
            MedSysEntities ms = new MedSysEntities();
            //memberID ;
            RPbox1.Items.Clear();
            var q = from ss in ms.HealthReports
                    where ss.MemberID == memberID
                    select new { ss.Reserve.ReserveDate, ss.ReportID, ss.Member.memberGender, ss.Member.memberName };
            //bool isMale = true;

            foreach (var r in q)
            {
                this.label26.Text = r.memberName;
                RPbox1.Items.Add($"{r.ReportID}-{r.ReserveDate.Value.ToShortDateString()}");
                if (r.memberGender != "男")
                {
                    gender = r.memberGender;
                    //isMale = false;
                }
            }
        }

        private void totalSum()
        {
            int x = 0;
            int sum = 0;
            for (int i = 0; i < listViewItemsAll.Items.Count; i++)
            {

                x = int.Parse(listViewItemsAll.Items[i].SubItems[1].Text);
                sum += x;
            }
            labelSum.Text = sum.ToString();
            totalP = sum;////

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabBlog);

            var q2 = bg.AllCat;
            //comboBox index 0 放入一個All選項
            cbBlogCategory.Items.Add("All");
            foreach (var n in q2)
            {//之後依序加入資料庫中的文章分類(這樣BlogCategory id會跟comboBox3的index對上)
                cbBlogCategory.Items.Add(n.BlogCategory1);
            }
            this.cbBlogCategory.SelectedIndex = 0;
            checkCategoryBlog("All");
        }

        private void checkCategoryBlog(string cat)
        {
            
            lbCommentID.Items.Clear();
            lbBlogComments.Items.Clear();

            getCheckCategoryBlog( cat);

        }
        /// <summary>
        /// 切換不同Blog
        /// </summary>
        private void ChangePosition()
        {
            this.lbBlogComments.Items.Clear();
            this.lbCommentID.Items.Clear();
            System.IO.MemoryStream mss = null;
            int x = 0;
            lblTitle.Text = cbM.currentCustomerBlog.title;
            mss = new System.IO.MemoryStream(cbM.currentCustomerBlog.BlogImage);
            pictureBox2.Image = Image.FromStream(mss);
            richTextBox1.Text = cbM.currentCustomerBlog.Content;
            labelCat.Text = cbM.currentCustomerBlog.BlogClass;
            lblAuthorDate.Text = $"{cbM.currentCustomerBlog.author}  {cbM.currentCustomerBlog.CreatedAt}  瀏覽人數：{cbM.currentCustomerBlog.view}";
            x=cbM.currentCustomerBlog.BlogID;
            ShowBlogComments(x);
            this.label8.Text = $"{cbM.nowPage+1}/{cbM.CatcustomerBlog.Count}";
        }

        private void checklistview() //to do檢查重複項目
        {
            string[] ch = null;
            int n = listViewItemsAll.Items.IndexOfKey(Text);

            for (int i = 0; i < listViewItemsAll.Items.Count; i++)
            {

                var reapeatName = from p in ms.Items.AsEnumerable()
                                  where listViewItemsAll.Items[i].Text == p.itemName
                                  select p.itemName;
                //MessageBox.Show($"{reapeatName}");
                if (reapeatName.Count() > 1)
                {
                    listViewItemsAll.Items.RemoveAt(i);
                }

            }
        }

        private void checklistviewGender()
        {//to do 檢查性別

            var checkgenderF = from p in ms.Items.AsEnumerable()
                               where p.Mmax == null && p.Fmax > 0
                               select new { genderName = p.itemName, genderID = p.itemID };
            var checkgenderM = from p in ms.Items.AsEnumerable()
                               where p.Fmax == null && p.Mmax > 0
                               select new { genderName = p.itemName, genferID = p.itemID };

            string[] chF = checkgenderF.ToList().ToString().Split(',');
            string[] chM = checkgenderM.ToList().ToString().Split(',');


            for (int i = 0; i < listViewItemsAll.Items.Count; i++)
            {
                if (listViewItemsAll.Items[i].Text == chF[0])
                {
                    for (int d = 0; d < listViewItemsAll.Items.Count; d++)
                    {
                        if (listViewItemsAll.Items[d].Text == chM[0])
                        {
                            listViewItemsAll.Items.RemoveAt(d);
                        }
                    }

                }
            }


            for (int i = 0; i < listViewItemsAll.Items.Count; i++)
            {
                if (listViewItemsAll.Items[i].Text == chM[0])
                {
                    for (int d = 0; d < listViewItemsAll.Items.Count; d++)
                    {
                        if (listViewItemsAll.Items[d].Text == chF[0])
                        {
                            listViewItemsAll.Items.RemoveAt(d);
                        }
                    }

                }


            }
        }


        /// <summary>
        /// 顯示留言
        /// </summary>
        /// <param name="CurrentBlogID"></param>
        private void ShowBlogComments(int CurrentBlogID)
        {
            this.lbBlogComments.Items.Add(" ");
            this.lbCommentID.Items.Add("0");
            //New Idea
            //取全部
            var comments = from c in ms.Comments
                           where c.BlogID == CurrentBlogID
                           orderby c.CommentID
                           select new { c.CommentID, c.ParentCommentID, c.MemberID, mNickName = c.Member.memberNickname, c.Content, c.EmployeeID, c.Employee.EmployeeName, c.CreatedAt, JobTitle = c.Employee.EmployeeClass.Class };

          
            foreach (var comment in comments)
            {
                //主留言
                if (comment.ParentCommentID == null)
                {
                    if (comment.EmployeeID == null)
                    {
                        this.lbBlogComments.Items.Add($"{comment.CommentID}主留言{comment.mNickName}於{comment.CreatedAt}留言:{comment.Content}");
                        this.lbCommentID.Items.Add(comment.CommentID);
                    }
                    else
                    {
                        this.lbBlogComments.Items.Add($"{comment.CommentID}主留言({comment.JobTitle}){comment.EmployeeName}於{comment.CreatedAt}留言:{comment.Content}");
                        this.lbCommentID.Items.Add(comment.CommentID);
                    }

                }
                else
                {
                    var subcomments = from cSub in ms.Comments
                                      join cMain in ms.Comments
                                      on cSub.ParentCommentID equals cMain.CommentID
                                      select new
                                      {
                                          //回覆別人
                                          cSub.CommentID,
                                          cSub.ParentCommentID,
                                          cSub.MemberID,
                                          cSub.Member.memberNickname,
                                          cSub.EmployeeID,
                                          EmployeeName = cSub.Employee.EmployeeName,
                                          cSub.Employee.EmployeeClass.Class,
                                          cSub.Content,
                                          cSub.CreatedAt,
                                          //被回覆的CommentID
                                          cMainID = cMain.CommentID,
                                          cMainMemberID = cMain.MemberID,
                                          cMainMemberNickName = cMain.Member.memberNickname,
                                          cMainEmpID = cMain.EmployeeID,
                                          cMainEmpName = cMain.Employee.EmployeeName,
                                          cMainEmpJob = cMain.Employee.EmployeeClass.Class
                                      };
                    foreach (var scomment in subcomments)
                    {
                        int lbCommentIDTotal = this.lbCommentID.Items.Count;
                        int subParentNum = (int)scomment.ParentCommentID;
                        for (int i = 0; i < lbCommentIDTotal; i++)
                        {//檢視listBox中要插入的位置
                            string strID = lbCommentID.Items[i].ToString();
                            if (int.Parse(strID) == subParentNum)
                            {
                                if (lbCommentID.Items.Contains(scomment.CommentID)) { continue; };
                                if (scomment.MemberID == null)
                                {
                                    if (scomment.cMainEmpID == null)
                                    {//員工回覆會員
                                        this.lbBlogComments.Items.Insert(i + 1, $"   =>({scomment.Class}){scomment.EmployeeName}於{scomment.CreatedAt}回復{scomment.cMainMemberNickName}:{scomment.Content}");
                                        this.lbCommentID.Items.Insert(i + 1, scomment.CommentID);
                                    }
                                    else
                                    {//員工回覆員工
                                        this.lbBlogComments.Items.Insert(i + 1, $"   =>({scomment.Class}){scomment.EmployeeName}於{scomment.CreatedAt}回復({scomment.cMainEmpJob}){scomment.cMainEmpName}:{scomment.Content}");
                                        this.lbCommentID.Items.Insert(i + 1, scomment.CommentID);
                                    }
                                }
                                else
                                {
                                    if (scomment.cMainEmpID == null)
                                    {//會員to會員
                                        this.lbBlogComments.Items.Insert(i + 1, $"   =>{scomment.memberNickname}於{scomment.CreatedAt}回復{scomment.cMainMemberNickName}:{scomment.Content}");
                                        this.lbCommentID.Items.Insert(i + 1, scomment.CommentID);
                                    }
                                    else
                                    {//會員to員工
                                        this.lbBlogComments.Items.Insert(i + 1, $"   =>{scomment.memberNickname}於{scomment.CreatedAt}回復({scomment.cMainEmpJob}){scomment.cMainEmpName}:{scomment.Content}");
                                        this.lbCommentID.Items.Insert(i + 1, scomment.CommentID);
                                    }
                                }
                                //當找到要插入的位置，離開迴圈
                                break;
                            }
                        }
                    }
                }
            }

        }
        public int showInfomation()
        {
            lblTitle.Text = cbM.CatcustomerBlog[0].title;
            System.IO.MemoryStream mss = new System.IO.MemoryStream(cbM.CatcustomerBlog[0].BlogImage);
            pictureBox2.Image = Image.FromStream(mss);
            richTextBox1.Text = cbM.CatcustomerBlog[0].Content;
            labelCat.Text = cbM.CatcustomerBlog[0].BlogClass;
            lblAuthorDate.Text = $"{cbM.CatcustomerBlog[0].author}  {cbM.CatcustomerBlog[0].CreatedAt}  瀏覽人數：{cbM.CatcustomerBlog[0].view}";
            return cbM.CatcustomerBlog[0].BlogID;
        }
        private void getCheckCategoryBlog(string cs)
        {

            if (cs == "All")
            {
                cbListCount = 0;
                cbListCountMax = 0;
                lbCommentID.Items.Clear();
                lbBlogComments.Items.Clear();
                cbM.CatByCustomerBlog();
                int x = showInfomation();
                this.label8.Text = $"{cbListCount + 1}/{cbM.AllcustomerBlog.Count}";
                timer1.Enabled = true;
                ShowBlogComments(x);
                //return cbM.AllcustomerBlog;
            }
            else if (cs == "活動快訊")
            {
                cbListCount = 0;
                cbListCountMax = 0;
                lbCommentID.Items.Clear();
                lbBlogComments.Items.Clear();
                cbM.CatByCustomerBlog(cs);
                int x = showInfomation();
                this.label8.Text = $"{cbListCount + 1}/{cbM.CatcustomerBlog.Count}";
                ShowBlogComments(x);
                //return cbM.CatcustomerBlog;

            }
            else if (cs == "醫療新知")
            {
                cbListCount = 0;
                cbListCountMax = 0;
                lbCommentID.Items.Clear();
                lbBlogComments.Items.Clear();
                
                cbM.CatByCustomerBlog(cs);
                int x = showInfomation();
                this.label8.Text = $"{cbListCount + 1}/{cbM.CatcustomerBlog.Count}";
                ShowBlogComments(x);
                //return cbM.CatcustomerBlog;
            }
            else if (cs == "名人分享會")
            {
                cbListCount = 0;
                cbListCountMax = 0;
                lbCommentID.Items.Clear();
                lbBlogComments.Items.Clear();
                cbM.CatByCustomerBlog(cs);
                int x = showInfomation();
                this.label8.Text = $"{cbListCount + 1}/{cbM.CatcustomerBlog.Count}";
                ShowBlogComments(x);
                //return cbM.CatcustomerBlog;
            }
            else if (cs == "媒體報導")
            {
                cbListCountMax = 0;
                lbCommentID.Items.Clear();
                lbBlogComments.Items.Clear();
                cbM.CatByCustomerBlog(cs);
                int x = showInfomation();
                this.label8.Text = $"{cbListCount + 1}/{cbM.CatcustomerBlog.Count}";
                ShowBlogComments(x);
                //return cbM.CatcustomerBlog;
            }
            else if (cs == "企業責任")
            {
                cbListCountMax = 0;
                cbListCount = 0;
                lbBlogComments.Items.Clear();
                cbM.CatByCustomerBlog(cs);
                int x = showInfomation();
                this.label8.Text = $"{cbListCount + 1}/{cbM.CatcustomerBlog.Count}";
                ShowBlogComments(x);
                //return cbList;
            }
            else
            {
                cbList = new List<customBlog>();
                //return cbList;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabMember);
            var q = from n in ms.Members
                    where n.memberId == memberID
                    select new
                    {
                        n.memberAddress,
                        n.memberPassword,
                        n.memberId,
                        n.memberName,
                        n.memberNickname,
                        n.memberEmail,
                        n.memberPhone,
                        n.memberContactNumber,
                        n.memberGender
                    };
            foreach (var n in q)
            {
                txtAcc.Text = n.memberAddress;
                txtPass.Text = n.memberPassword;
                txtCN.Text = n.memberContactNumber;
                txtGender.Text = n.memberGender;
                txtEmail.Text = n.memberEmail;
                txtName.Text = n.memberName;
                txtNN.Text = n.memberNickname;
                txtPhoto.Text = n.memberPhone;
                txtAdd.Text = n.memberAddress;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabreserve);
        }
        
        /// <summary>
        /// 瀏覽數增加
        /// </summary>
        /// <param name="CurrentBlogID"></param>
        private void AddCurrentBlogView(int CurrentBlogID)
        {
            var query = ms.Blogs.Where(n => n.BlogID == CurrentBlogID).Select(n => n).FirstOrDefault();
            query.Views++;
            string BlogCategoey = query.BlogCategory.BlogCategory1;

            this.ms.SaveChanges();

            ///需要做refresh，
            //checkCategoryBlog("All");
            //checkCategoryBlog(BlogCategoey);
        }

        #region 文章切換
        private void btnFirst_Click(object sender, EventArgs e)
        {
            cbM.FirstBlog();
            AddCurrentBlogView(cbM.currentCustomerBlog.BlogID);
            ChangePosition();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            cbM.PreviousBlog();
            AddCurrentBlogView(cbM.currentCustomerBlog.BlogID);
            ChangePosition();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            cbM.NextBlog();
            AddCurrentBlogView(cbM.currentCustomerBlog.BlogID);
            ChangePosition();
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            cbM.LastBlog();
            AddCurrentBlogView(cbM.currentCustomerBlog.BlogID);
            ChangePosition();
        }
        #endregion


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbList = new List<customBlog>();
            checkCategoryBlog(this.cbBlogCategory.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(cbM.AllcustomerBlog.Count);
            System.IO.MemoryStream mse = new System.IO.MemoryStream(cbM.AllcustomerBlog[r].BlogImage);
            this.pictureBox3.Image = Image.FromStream(mse);
            this.label10.Text = cbM.AllcustomerBlog[r].title;
            r = rnd.Next(cbM.AllcustomerBlog.Count);
            mse = new System.IO.MemoryStream(cbM.AllcustomerBlog[r].BlogImage);
            this.pictureBox4.Image = Image.FromStream(mse);
            this.label11.Text = cbM.AllcustomerBlog[r].title;
            r = rnd.Next(cbM.AllcustomerBlog.Count);
            mse = new System.IO.MemoryStream(cbM.AllcustomerBlog[r].BlogImage);
            this.pictureBox5.Image = Image.FromStream(mse);
            this.label12.Text = cbM.AllcustomerBlog[r].title;
        }
        public void help()
        {
            var q = ms.Comments.Where(n => n.Blog.Title == lblTitle.Text).Select(n => n);
            foreach (var n in q)
            {
                if (n.MemberID.ToString() == "")
                {
                    this.lbBlogComments.Items.Add($"{n.Content} 作者：{n.Employee.EmployeeName}");
                }
                else
                {
                    this.lbBlogComments.Items.Add($"{n.Content} 作者：{n.Member.memberName}");
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var q = ms.Comments.Where(n => n.Blog.Title == lblTitle.Text).Select(n => n);
            var q2 = ms.Blogs.Where(n => n.Title == lblTitle.Text).Select(n => n.BlogID);
            Comment com = new Comment();
            com.BlogID = q2.ToList()[0];
            com.MemberID = memberID;
            com.Content = textBox1.Text;
            com.CreatedAt = DateTime.Now;
            ms.Comments.Add(com);
            ms.SaveChanges();
            this.lbBlogComments.Items.Clear();
            help();
        }
        public void timerTK(string x)
        {
            label4.Text = x;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            var qqqq = from n in ms.Blogs
                       select n.Title;
            Random rnd = new Random();
            int r = rnd.Next(qqqq.ToList().Count);
            timerTK(qqqq.ToList()[r]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabcar);
            var q = ms.Products.Select(p => new { p.ProductID, p.ProductName, p.UnitPrice, p.Description });
            this.bindingSource1.DataSource = q.ToList();
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.dataGridView2.DataSource = this.bindingSource1;
            this.ListViewCart.Columns.Add("產品名稱");
            this.ListViewCart.Columns.Add("數量");
            this.ListViewCart.Columns.Add("價格");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int x = (int)this.dataGridView2.CurrentRow.Cells[0].Value;
                var q = ms.Products.Where(n => n.ProductID == x).Select(n => n);
                System.IO.MemoryStream mss = new System.IO.MemoryStream(q.First().Photo);
                pictureBox1.Image = Image.FromStream(mss);
                this.label1.Text = q.First().ProductName;
                this.textBox2.Text = q.First().Description;
                this.label2.Text = q.First().UnitPrice.ToString();

            }
        }
        public void bindProduct()
        {
            this.label1.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            this.textBox2.Text = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            this.label2.Text = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            string s = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            var q = ms.Products.Where(n => n.ProductName == s).Select(n => n.Photo).FirstOrDefault();
            System.IO.MemoryStream mss = new System.IO.MemoryStream(q);
            this.pictureBox1.Image = Image.FromStream(mss);

        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bindProduct();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string[] st = null;
            st = label2.Text.Split('.');
            ListViewItem lvi = new ListViewItem();
            lvi.Text = label1.Text;
            ListViewItem.ListViewSubItem lvisub = new ListViewItem.ListViewSubItem();
            lvisub.Text = textBox3.Text;
            lvi.SubItems.Add(lvisub);
            lvisub = new ListViewItem.ListViewSubItem();
            lvisub.Text = (int.Parse(st[0]) * int.Parse(textBox3.Text)).ToString();
            lvi.SubItems.Add(lvisub);
            this.ListViewCart.Items.Add(lvi);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            new FrmCar(this.ListViewCart, memberID).Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddComments_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lbCommentID.SelectedIndex == 0)
                {
                    Comment comment = new Comment();
                    comment.MemberID = this.memberID;
                    comment.BlogID = cbList[cbListPosition].BlogID;
                    comment.Content = textBox1.Text;
                    comment.CreatedAt = DateTime.Now;
                    comment.ParentCommentID = null;
                    this.ms.Comments.Add(comment);
                    ms.SaveChanges();
                    MessageBox.Show("新增留言成功");
                }
                else
                {
                    Comment comment = new Comment();
                    comment.MemberID = this.memberID;
                    comment.BlogID = cbList[cbListPosition].BlogID;
                    comment.Content = textBox1.Text;
                    comment.CreatedAt = DateTime.Now;
                    int IWantToReply = int.Parse(this.lbCommentID.SelectedItem.ToString());
                    comment.ParentCommentID = IWantToReply;
                    this.ms.Comments.Add(comment);
                    ms.SaveChanges();
                    MessageBox.Show("已成功回覆");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCommentDelete_Click(object sender, EventArgs e)
        {
            //只能刪除自己的留言
            //刪除前還要檢查子留言
            //當前選擇要刪的
            var query = (from q in this.ms.Comments.AsEnumerable()
                         where (q.BlogID == cbList[cbListPosition].BlogID) && (q.MemberID == this.memberID) && (q.CommentID == int.Parse(this.lbCommentID.SelectedItem.ToString()))
                         select q).FirstOrDefault();
            if (query != null)
            {
                DeleteCommentAndReply(query);
                ms.SaveChanges();
            }
            else { MessageBox.Show("只能刪除自己的留言!"); }
        }
        private void DeleteCommentAndReply(Comment comment)
        {
            var subReplies = this.ms.Comments.Where(subq => subq.ParentCommentID == comment.CommentID).ToList();
            foreach (var subq in subReplies)
            {
                DeleteCommentAndReply(subq);
            }
            this.ms.Comments.Remove(comment);
        }

        private void btnCommentUpdate_Click(object sender, EventArgs e)
        {
            var query = (from q in ms.Comments.AsEnumerable()
                         where q.CommentID == int.Parse(this.lbCommentID.SelectedItem.ToString()) && q.MemberID == this.memberID && q.BlogID == cbList[cbListPosition].BlogID
                         select q).FirstOrDefault();
            query.Content = this.textBox1.Text;
            ms.SaveChanges();
            MessageBox.Show("hi");
        }

        private void lblBlogComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbCommentID.SelectedIndex = this.lbBlogComments.SelectedIndex;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            var q = (from n in ms.Members
                     where n.memberId == memberID
                     select n).FirstOrDefault();
            if (q == null) { return; }
            q.memberName = txtName.Text;
            q.memberContactNumber = txtCN.Text;
            q.memberEmail = txtEmail.Text;
            q.memberNickname = txtNN.Text;
            q.memberPhone = txtPhoto.Text;
            q.memberAddress = txtAdd.Text;
            q.memberPassword = txtPass.Text;
            q.memberAccount = txtAcc.Text;
            ms.SaveChanges();
        }

        private void comboboxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            plan = comboboxPlan.SelectedIndex + 2;
            //MessageBox.Show(plan.ToString());
            listViewItemsAll.Items.Clear();
            var plans = from p in ms.PlanRefs
                        where comboboxPlan.Text == p.Plan.planName
                        select p.Project.ProjectName;
            var plans2 = from p in ms.Items.AsEnumerable()
                         where plans.Contains(p.Project.ProjectName)
                         select new { itemname = p.itemName, itemprice = p.itemPrice };
            var plans3 = from p in ms.Plans.AsEnumerable()
                         where p.planName == this.comboboxPlan.Text
                         select new { p.planDescription };
            testLbl.Text = plan.ToString();
            foreach (var p in plans2)
            {

                listViewItemsAll.Items.Add($"{p.itemname}").SubItems.Add($"{p.itemprice}");
            };
            //to do 加入套餐內容形容


            foreach (var p in plans3)
            {
                // this.listBox2.DataSource=p.planDescription.ToList();
                this.PlanDescription.Text = p.planDescription.ToString();
            }

            totalSum();
            checklistview();
            checklistviewGender();
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            flag = !flag;
            this.radioProjectAll.Checked = flag;

        }
        private void radioProjectAll_CheckedChanged(object sender, EventArgs e)
        {

            if (radioProjectAll.Checked == true && flag == true)
            {
                string[] comsplit = this.comboboxProject.Text.Split('-');
                var projectall = from p in this.ms.Items.AsEnumerable()
                                 where p.Project.ProjectName == comsplit[0]
                                 select new { itemname = p.itemName, itemsprice = p.itemPrice };




                foreach (var p in projectall)
                {
                    listViewItemsAll.Items.Add($"{p.itemname} ").SubItems.Add($"{p.itemsprice}");

                }

            }


            this.radioProjectAll.Click += radioButton2_Click;
            totalSum();
            checklistview();
            checklistviewGender();

        }

        private void btnItemClear_Click(object sender, EventArgs e)
        {
            plan = 0;
            listViewItemsAll.Items.Clear();
            totalSum();

            this.radioProjectAll.Checked = false;
            this.radioItemAll.Checked = false;
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            int x = 0;
            int sum = 0;
            for (int i = 0; i < listViewItemsAll.Items.Count; i++)
            {

                // MessageBox.Show(this.listViewItemsAll.Items[i].SubItems[1].Text);

                x = int.Parse(listViewItemsAll.Items[i].SubItems[1].Text);
                sum += x;
            }
            //MessageBox.Show(sum + "");
            //====================================================================
            totalP = sum;////
            FrmReserved f = new FrmReserved(listViewItemsAll, memberID, totalP, plan);
            f.Show();
        }

        private void btnItemCompare_Click(object sender, EventArgs e)
        {
            FrmCompared f = new FrmCompared(listViewItemsAll, memberID, totalP, plan);
            f.Show();
        }

        private void RPbtn1_Click(object sender, EventArgs e)
        {
            this.RPview1.Items.Clear();
            string[] st = null;
            st = RPbox1.Text.Split('-');
            //string st2 = RPbox1.Text.Replace("/", "-");



            MedSysEntities ms = new MedSysEntities();
            var q = from s in ms.ReportDetails.AsEnumerable()

                    where s.ReportID.ToString() == st[0].ToString()

                    select new
                    {
                        項目 = s.Item.itemName,
                        檢查結果 = s.result,
                        男性標準值min = s.Item.Mmin,
                        男性標準值max = s.Item.Mmax,
                        女性標準值min = s.Item.Fmin,
                        女性標準值max = s.Item.Fmax,
                        單位 = s.Item.itemUnit,
                        標準值 = s.Item.itemRange,
                        標準值min = s.Item.itemRangeMin,
                        標準值max = s.Item.itemRangeMax,
                    };


            int count = 0;
            foreach (var r in q)
            {

                RPview1.Items.Add(r.項目);
                if (r.檢查結果 != null)
                    RPview1.Items[count].SubItems.Add($"{r.檢查結果.ToString()} {r.單位}");

                if (gender.Equals('男'))
                {
                    if (r.男性標準值min == null && r.男性標準值max == null)
                    {
                        if (r.標準值 == null)
                        {

                            RPview1.Items[count].SubItems.Add($"{r.標準值min} ~ {r.標準值max}");

                        }
                        else
                        {
                            RPview1.Items[count].SubItems.Add(r.標準值);
                        }
                    }
                    else
                    {
                        RPview1.Items[count].SubItems.Add($"{r.男性標準值min} ~ {r.男性標準值max}");
                    }
                }
                else
                {
                    if (r.女性標準值min == null && r.女性標準值max == null)
                    {
                        if (r.標準值 == null)
                        {
                            RPview1.Items[count].SubItems.Add($"{r.標準值min} ~ {r.標準值max}");
                        }
                        else
                        {
                            RPview1.Items[count].SubItems.Add(r.標準值);
                        }
                    }
                    else
                    {
                        RPview1.Items[count].SubItems.Add($"{r.女性標準值min} ~ {r.女性標準值max}");
                    }
                }
                count++;

            }





        }

        private void RPbtn2_Click(object sender, EventArgs e)
        {
            this.RPview2.Items.Clear();
            string[] st = null;
            st = RPbox1.Text.Split('-');
            //string st2 = listBox1.Text.Replace("/", "-");

            //MessageBox.Show(st[1]);

            MedSysEntities ms = new MedSysEntities();
            var q = from s in ms.ReportDetails.AsEnumerable()
                        /*where s.HealthReport.Reserve.ReserveDate.Value.ToString("yyyy/mm/dd")== comboBox1.Text*/
                        /*s.ReportID.ToString() == comboBox1.Text*/
                        //where s.HealthReport.Member.memberName == st[0]
                    where s.ReportID.ToString() == st[0].ToString()////OK
                                                                   //where s.HealthReport.Reserve.ReserveDate.ToString().Contains(st[1])


                    select new
                    {
                        項目 = s.Item.itemName,
                        檢查結果 = s.result,
                        男性標準值min = s.Item.Mmin,
                        男性標準值max = s.Item.Mmax,
                        女性標準值min = s.Item.Fmin,
                        女性標準值max = s.Item.Fmax,
                        單位 = s.Item.itemUnit,
                        標準值 = s.Item.itemRange,
                        標準值min = s.Item.itemRangeMin,
                        標準值max = s.Item.itemRangeMax,
                    };

            //dataGridView1.DataSource = q.ToList();
            int count = 0;
            foreach (var r in q)
            {

                RPview2.Items.Add(r.項目);
                if (r.檢查結果 != null)
                    RPview2.Items[count].SubItems.Add($"{r.檢查結果.ToString()} {r.單位}");

                if (gender.Equals('男'))
                {
                    if (r.男性標準值min == null && r.男性標準值max == null)
                    {
                        if (r.標準值 == null)
                        {

                            RPview2.Items[count].SubItems.Add($"{r.標準值min} ~ {r.標準值max}");

                        }
                        else
                        {
                            RPview2.Items[count].SubItems.Add(r.標準值);
                        }
                    }
                    else
                    {
                        RPview2.Items[count].SubItems.Add($"{r.男性標準值min} ~ {r.男性標準值max}");
                    }
                }
                else
                {
                    if (r.女性標準值min == null && r.女性標準值max == null)
                    {
                        if (r.標準值 == null)
                        {
                            RPview2.Items[count].SubItems.Add($"{r.標準值min} ~ {r.標準值max}");
                        }
                        else
                        {
                            RPview2.Items[count].SubItems.Add(r.標準值);
                        }
                    }
                    else
                    {
                        RPview2.Items[count].SubItems.Add($"{r.女性標準值min} ~ {r.女性標準值max}");
                    }
                }
                count++;
                //                listView1.Items[count+1].SubItems.Add(r.男性標準值);
                //                listView1.Items[count+2].SubItems.Add(r.女性標準值); 
                //.
            }

        }

        private void RPbox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ItemCheck.SelectedIndex;
            totalSum();
            checklistview();
            checklistviewGender();
        }

        private void radioItemAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioItemAll.Checked == true && flag == true)
            {
                var radio = from p in ms.Items.AsEnumerable()
                            select new { itemsAll = p.itemName, itemsPrice = p.itemPrice, };
                foreach (var p in radio)
                {
                    listViewItemsAll.Items.Add($"{p.itemsAll}").SubItems.Add($"{p.itemsPrice}");

                }
            }
            this.radioItemAll.Click += radioButton1_Click;
            totalSum();
            checklistview();
            checklistviewGender();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboboxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            this.listBoxProjectItem.Items.Clear();
            string[] comsplit = comboBox.Text.Split('-');
            var cDetail = from p in this.ms.Items.AsEnumerable()

                          where comsplit[0] == (p.Project.ProjectName)
                          select new { Ditem = p.itemName, PitemsPrice = p.itemPrice };
            //this.dataGridView1.DataSource=cDetail.ToList();
            foreach (var p in cDetail)
            {

                this.listBoxProjectItem.Items.Add($"{p.Ditem} |   {p.PitemsPrice:c2}");

            }
            this.radioProjectAll.Click += radioButton2_Click;
            totalSum();
            checklistview();
            checklistviewGender();
        }

        private void ItemCheck_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            CheckState cs = e.CurrentValue;
            int i = ItemCheck.SelectedIndex;
            st = this.ItemCheck.Items[i].ToString().Split('|');


            if (cs == CheckState.Checked)
            {
                for (int xx = 0; xx < listViewItemsAll.Items.Count; xx++)
                {
                    string ste = listViewItemsAll.Items[xx].Text;
                    if (ste == st[0])
                    {
                        listViewItemsAll.Items.RemoveAt(xx);
                    }
                }
            }
            else if (cs == CheckState.Unchecked)
            {
                var checkItems = from p in ms.Items.AsEnumerable()
                                 where p.itemID == i + 1
                                 select new { itemsName = p.itemName, itemsPrice = p.itemPrice };
                foreach (var p in checkItems)
                {
                    listViewItemsAll.Items.Add($"{p.itemsName}").SubItems.Add($"{p.itemsPrice}");

                }
            }
        }
    }
    }
    

