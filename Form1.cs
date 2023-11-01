using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專題.Properties;

namespace 期中專題
{
    public partial class Form1 : Form
    {
        int memberID = 0;
        MedSysEntities ms = new MedSysEntities();
        
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabLogin);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabReport);
            var q = from n in ms.Members
                    where n.memberId == memberID
                    select n.memberName;
            this.label26.Text = q.ToList()[0];
            var q2 = from n in ms.HealthReports
                     where n.MemberID == memberID
                     select new
                     {
                         n.Member.memberName,
                         n.ReportDate,
                     };
            this.labReportDate.Text = q2.ToList()[0].ReportDate.ToString();
            var q3 = from n in ms.ReportDetails
                     where n.HealthReport.MemberID == memberID
                     select new
                     {
                         n.itemID,
                         n.Item.itemName,
                         n.result
                     };
            this.dataGridView1.DataSource = q3.ToList();

        }
    

    private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void tabBlog_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(tabBlog);
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
            foreach(var n in q)
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

        private void button10_Click(object sender, EventArgs e)
        {
            var q = (from n in ms.Members
                    where n.memberId == memberID
                    select n).FirstOrDefault();
            if (q == null) { return; }
            q.memberName = txtName.Text;
            q.memberContactNumber =txtCN .Text;
            q.memberEmail = txtEmail.Text;
            q.memberNickname = txtNN.Text;
            q.memberPhone = txtPhoto.Text;
            q.memberAddress =txtAdd.Text;
            q.memberPassword = txtPass.Text;
            q.memberAccount =txtAcc.Text;
            ms.SaveChanges();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Now;
            this.label8.Text = Date.ToString("hh:mm:ss");
        }
    }
}
