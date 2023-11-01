using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專題
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        MedSysEntities ms = new MedSysEntities();
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x =new FrmRegister().ShowDialog();
            //MessageBox.Show(x.ToString());
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        int memberID=0;
        private void button2_Click(object sender, EventArgs e)
        {
            var q = from n in ms.Members
                    where n.memberAccount ==txtAdd.Text &&  n.memberPassword==txtPass.Text
                    select new
                    {
                        n.memberAddress,
                        n.memberPassword,
                        n.memberId
                    };
            foreach(var n in q)
            {
                memberID = n.memberId;
            }
            //MessageBox.Show(memberID.ToString());
            if (q.ToList().Count() == 0)
            {
                MessageBox.Show("帳號密碼錯誤!") ;
            }
            else
            {
                MessageBox.Show("登入成功");
                new Form1(memberID).Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtAdd.Text = "Test";
            this.txtPass.Text = "Test";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from n in ms.Employees
                    where n.EmployeeEmail == txtEyEmaill.Text && n.EmployeePassWord ==txtEyPassword.Text
                    select new
                    {
                        n.EmployeeEmail,
                        n.EmployeePassWord,
                        n.EmployeeID
                    };
            
            if(q.ToList().Count() == 0)
            {
                MessageBox.Show("帳號密碼輸入錯誤");
            }
            else
            {
                new Form2(q.ToList()[0].EmployeeID).Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txtEyEmaill.Text = "James555@gmail.com";
            this.txtEyPassword.Text = "James555";
        }
    }
}
