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
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult x =new FrmRegister().ShowDialog();
        }
        int memberID=0;
        private void button2_Click(object sender, EventArgs e)
        {
            var q2 = ms.Members.Where(n => n.memberAccount == txtAdd.Text && n.memberPassword == txtPass.Text).Select(n => new{n.memberAddress,n.memberPassword,n.memberId});
            foreach(var n in q2)
            {
                memberID = n.memberId;
            }
            //MessageBox.Show(memberID.ToString());
            if (q2.ToList().Count() == 0)
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
            var q2 = ms.Employees.Where(n => n.EmployeeEmail == txtEyEmaill.Text && n.EmployeePassWord == txtEyPassword.Text).Select(n => new { n.EmployeeID,n.EmployeeEmail,n.EmployeePassWord });
            if (q2.ToList().Count() == 0)
            {
                MessageBox.Show("帳號密碼輸入錯誤");
            }
            else
            {
                new Form2(q2.ToList()[0].EmployeeID).Show();
            }
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.txtEyEmaill.Text = "James555@gmail.com";
            this.txtEyPassword.Text = "James555";
        }
    }
}
