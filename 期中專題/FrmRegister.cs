using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專題
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
            var q = from n in mscontext.Corporations
                    select n.corporation1;

            foreach (var n in q)
            {
                comboTax.Items.Add(n);
            }
        }
        MedSysEntities mscontext = new MedSysEntities();
        public bool IsSpecialChar(string str)
        {
            Regex regExp = new Regex("[^0-9a-zA-Z\u4e00-\u9fa5]");
            if (regExp.IsMatch(str))
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool accsp = false;
            bool accemail = false;
            int txtAccCk = this.txtAcc.Text.Length;
            char[] txtaccckk = txtAcc.Text.ToCharArray();
            foreach (char a in txtaccckk)
            {
                if (IsSpecialChar(a.ToString()))
                {
                    accsp = true;
                }
            }
            int txtAccmail = this.txtEmail.Text.Length;
            char[] txtmailckk = txtEmail.Text.ToCharArray();
            foreach (char a in txtmailckk)
            {
                if (a.ToString() == "@")
                {
                    accemail = true;
                }
            }
            string numberP = txtPhone.Text;
            string numberCN = txtCN.Text;
            int numchkP = 0;
            int numchkCN = 0;
            bool chkP = int.TryParse(numberP, out numchkP);
            bool chkCN = int.TryParse(numberCN, out numchkCN);

            if (txtAcc.Text == "" || txtPassword.Text == "" || txtName.Text == "" || txtCN.Text == "" || txtEmail.Text == "" || txtAdd.Text == "" || txtNickName.Text == "" || comboGender.Text == "" || comboTax.Text == "")
            {
                MessageBox.Show("有空白");
            }
            else if (chkP != true)
            {
                MessageBox.Show("輸入手機無效");
            }
            else if (chkCN != true)
            {
                MessageBox.Show("輸入電話無效");
            }
            else if (accemail != true)
            {
                MessageBox.Show("電子郵件格式不正確");
            }
            else if (accsp)
            {
                MessageBox.Show("會員帳號中含有特殊字元");
            }
            else if (txtAcc.Text=="" || txtPassword.Text == "" || txtName.Text == "" || txtCN.Text == "" || txtEmail.Text == "" || txtAdd.Text == "" || txtNickName.Text == "" || comboGender.Text == "" || comboTax.Text == "")
            {
                MessageBox.Show("有空白");
            }
            else
            {
                int l = 0;
                var q = from n in mscontext.Corporations
                        where n.corporation1 == comboTax.Text
                        select n.taxID;
                var q2 = from n in mscontext.Members
                         where n.memberAccount == txtAcc.Text || n.memberPassword == txtPassword.Text
                         select new
                         {
                             n.memberAccount,
                             n.memberPassword
                         };
                if (q2.ToList().Count != 0)
                {
                    MessageBox.Show("會員帳號密碼已重複");
                }
                else
                {
                    foreach (var x in q)
                    {
                        l = x;
                    }
                    Member nM = new Member();
                    nM.memberAccount = this.txtAcc.Text;
                    nM.memberName = this.txtName.Text;
                    nM.memberGender = this.comboGender.Text;
                    nM.memberBirthdate = this.dateTimePicker1.Value;
                    nM.memberPhone = this.txtPhone.Text;
                    nM.memberEmail = this.txtEmail.Text;
                    nM.memberContactNumber = this.txtCN.Text;
                    nM.memberNickname = this.txtNickName.Text;
                    nM.memberPassword = this.txtPassword.Text;
                    nM.memberAddress = this.txtAdd.Text;
                    nM.taxID = l;
                    mscontext.Members.Add(nM);
                    mscontext.SaveChanges();
                    MessageBox.Show("註冊會員成功");
                    this.Close();
                }
           
            }
        }



        private void textBox7_Leave(object sender, EventArgs e)
        {
           this.errorADD.Text = "no";
        }

        private void TEst_Click(object sender, EventArgs e)
        {
            txtAcc.Text = "Test";
            txtPassword.Text = "Test";
            txtEmail.Text = "xxx";
            txtCN.Text = "xxx";
            txtName.Text = "Test";
            txtNickName.Text = "Test"; 
            txtPhone.Text = "Test";
        }
    }
}
