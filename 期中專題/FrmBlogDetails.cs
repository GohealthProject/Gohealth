using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專題.Model;

namespace 期中專題
{
    public partial class FrmBlogDetails : Form
    {
        public event Action BlogUpdatedOrDeleted;
        int classid = 0;
        internal int bdBlogID { get; set; }
        byte[] bgImage = null;
        MedSysEntities mse = new MedSysEntities();
        BlogManage bg =new BlogManage();
        private void OnBlogUpdatedOrDeleted()
        {
            BlogUpdatedOrDeleted?.Invoke();
        }
        public FrmBlogDetails(int selectBlogID, int blogPermission)
        {
            InitializeComponent();
            LoadTocbBlogDetailCategory(selectBlogID, ref  classid);
            if (blogPermission == 2) { this.btnDeleteBlog.Enabled = false; }
        }
        private void LoadTocbBlogDetailCategory(int selectBlogID, ref int classid)
        {
            bg.blogIdByBlog(selectBlogID, ref classid);
            var q = bg.nowBlog;

            this.txtBlogDetailID.Text = q.BlogID.ToString();
            this.txtBlogDetailTitle.Text = q.Title;
            this.rtbBlogDetailContent.Text = q.Content;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(q.BlogImage);
            this.pbDetailImage.Image = Image.FromStream(ms);
            classid = q.BlogCategory.BlogClassID;

            var q2 = bg.AllCat;
            foreach (var item in q2.ToList()) { this.cbBlogDetailCategory.Items.Add(item.BlogCategory1); }
            
            this.cbBlogDetailCategory.SelectedIndex = classid - 1;
            int bid = q.BlogID;


            var qr = mse.Comments.Where(n => n.EmployeeID == null && n.BlogID == bid).Select(n => new { n.CommentID, 姓名 = n.Member.memberName, 回覆 = n.Content, 時間 = n.CreatedAt }).ToList();
            var qrr = from c in mse.Comments
                      where c.MemberID == null && c.BlogID == bid
                      select new { c.CommentID, c.ParentCommentID, 姓名 = c.Member.memberName, 回覆 = c.Content, 時間 = c.CreatedAt };
            
            foreach (var co in qr)
            {
                listReply.Items.Add(co.姓名 + "：" + co.回覆 + "　　　　" + co.時間);
                listiD.Items.Add(co.CommentID);
                foreach (var item in qrr)
                {
                    if (co.CommentID == item.ParentCommentID)
                    {
                        listReply.Items.Add(item.姓名 + "：" + $"(回覆{co.姓名}的評論)" + item.回覆 + "　　　　" + co.時間);
                        listiD.Items.Add(item.CommentID);
                    }
                }

            }
            listReply.Items.Add(" ");
            listiD.Items.Add(" ");
        }

        private void FrmBlogDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnUpDateBlog_Click(object sender, EventArgs e)
        {
            int temp = int.Parse(this.txtBlogDetailID.Text);

            bg.blogIdByBlog(temp,ref mse);
            var q = bg.nowBlog;

            q.Title = this.txtBlogDetailTitle.Text;
            q.ArticleClassID = this.cbBlogDetailCategory.SelectedIndex + 1;
            q.Content = this.rtbBlogDetailContent.Text;
            MemoryStream ms = new MemoryStream();
            pbDetailImage.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            bgImage =ms.GetBuffer();
            q.BlogImage = ms.GetBuffer();
            mse.SaveChanges();
            MessageBox.Show("修改成功!");
            OnBlogUpdatedOrDeleted();
            this.Close();
        }

        private void btnBrowseChangePic_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.pbDetailImage.Image = Image.FromFile(ofd.FileName);
                this.pbDetailImage.Image.Save(ms, ImageFormat.Jpeg);
                bgImage = ms.GetBuffer();
                ms.Close();
            }
        }

        private void btnDeleteBlog_Click(object sender, EventArgs e)
        {
            

            int temp = int.Parse(this.txtBlogDetailID.Text);
            var q2 = mse.Comments.Where(n => n.BlogID == temp).Select(n => n);
            foreach(var n in q2)
            {
                mse.Comments.Remove(n);
            }
            mse.SaveChanges();
            var q = mse.Blogs.Where(n => n.BlogID == temp).Select(n => n).ToList();
            mse.Blogs.Remove(q[0]);
            mse.SaveChanges();
            MessageBox.Show("已成功刪除!");
            OnBlogUpdatedOrDeleted();
            this.Close();
        }

        private void listReply_SelectedIndexChanged(object sender, EventArgs e)
        {
            listiD.SelectedIndex = listReply.SelectedIndex;
        }

        private void btnReply_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show($"確定送出?", "問題", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                var qq = new Comment
                {
                    BlogID = bdBlogID,
                    MemberID = null,
                    EmployeeID = 1,
                    ParentCommentID = (int)listiD.SelectedItem,
                    Content = this.textBox1.Text,
                    CreatedAt = DateTime.Now,
                };

                mse.Comments.Add(qq);
                mse.SaveChanges();
                //}

                var qqq = from n in mse.Comments
                          where n.Content == this.listReply.SelectedItem
                          select n;

                //刷新

                this.listReply.Items.Insert(listReply.SelectedIndex + 1, "：" + $"(回覆評論)" + this.textBox1.Text + "　　　　" + DateTime.Now);
                this.listReply.SelectedItem = this.textBox1.Text;



                foreach (var n in qqq)
                {
                    this.listiD.Items.Insert(listiD.SelectedIndex, n.CommentID);
                }

            }
        }

        private void btnReplyDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"確定要刪除此評論嗎?", "警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {

                var q = mse.Comments.Where(n => n.CommentID == (int)listiD.SelectedItem).Select(n => n);
                foreach (var d in q)
                {
                    mse.Comments.Remove(d);
                }

                mse.SaveChanges();

                listiD.Items.Remove(listiD.SelectedItem);
                listReply.Items.Remove(listReply.SelectedItem);

                //Comment_Refresh();
            }
        }

        private void listiD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
