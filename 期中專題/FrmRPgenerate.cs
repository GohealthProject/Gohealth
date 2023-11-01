using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專題.MedSysDataSetTableAdapters;
using static System.Net.Mime.MediaTypeNames;

namespace 期中專題
{
    public partial class FrmRPgenerate : Form
    {
        MedSysEntities ms = new MedSysEntities();
        MedSysDataSet md = new MedSysDataSet();
        ReserveTableAdapter r1 = new ReserveTableAdapter();
        ReservedSubTableAdapter rs1 = new ReservedSubTableAdapter();
        HealthReportTableAdapter ht1 = new HealthReportTableAdapter();
        ReportDetailTableAdapter rd1 = new ReportDetailTableAdapter();
        
        public FrmRPgenerate()
        {
            InitializeComponent();
            
            rbtReserved.Checked = true;
           
            
            
            

        }

        private void healthreportdetailCbTrue()
        {
            //rpComboBox.Items.Clear();
            rpComboBox.Items.Add("健檢詳細編號");
            rpComboBox.Items.Add("健檢報告編號");
            rpComboBox.Items.Add("項目編號");
            rpComboBox.Items.Add("健檢結果");
        }

        private void healthreportCbTrue()
        {
            //rpComboBox.Items.Clear();
            rpComboBox.Items.Add("健檢報告編號");
            rpComboBox.Items.Add("會員編號");
            rpComboBox.Items.Add("健檢報告日期");
            rpComboBox.Items.Add("選擇方案");
            rpComboBox.Items.Add("預約編號");
            //rpComboBox.Items.Add("付款狀態");


        }

        private void reversedsubCbTrue()
        {
            //rpComboBox.Items.Clear();
            rpComboBox.Items.Add("預約詳細編號");
            rpComboBox.Items.Add("預約號碼");
            rpComboBox.Items.Add("項目編號");
        }

        private void reverseCbTrue()
        {
            //rpComboBox.Items.Clear();
            rpComboBox.Items.Add("預約編號");
            rpComboBox.Items.Add("會員號碼");
            rpComboBox.Items.Add("選擇方案");
            rpComboBox.Items.Add("預約日期");
            //rpComboBox.Items.Add("預約狀態");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbtReserved.Checked)
            {
                if (rpComboBox.SelectedIndex == 0)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.Reserves
                                where rpTbx.Text == s.ReserveID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的ReserveID");
                    }
                }
                else if (rpComboBox.SelectedIndex == 1)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.Reserves
                                where rpTbx.Text == s.memberID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的MemberID");
                    }

                }
                else if (rpComboBox.SelectedIndex == 2)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.Reserves
                                where rpTbx.Text == s.planID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的PlanID");
                    }

                }
                else if (rpComboBox.SelectedIndex == 3)
                {
                    DateTime dt;

                    if (DateTime.TryParse(rpTbx.Text, out dt))
                    {
                        var q = from s in ms.Reserves.AsEnumerable()
                                where rpTbx.Text == s.ReserveDate.Value.ToShortDateString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的預約日期");
                    }

                }

            }

            else if (rbtReserveSub.Checked) ///////////多出兩欄???
            {
                int temp = 0;

                if (int.TryParse(rpTbx.Text, out temp))
                {
                    if (rpComboBox.SelectedIndex == 0)
                    {
                        var q = from s in ms.ReservedSubs
                                where rpTbx.Text == s.subreservedID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else if (rpComboBox.SelectedIndex == 1)
                    {
                        var q = from s in ms.ReservedSubs
                                where rpTbx.Text == s.reservedID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else if (rpComboBox.SelectedIndex == 2)
                    {
                        var q = from s in ms.ReservedSubs
                                where rpTbx.Text == s.itemID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                }
                else 
                {
                    MessageBox.Show("請輸入正確的數值");
                }
            }

            else if (rbtHealthReport.Checked) //////////預約>健檢報告  排序問題?????////日期Null
            {
                if (rpComboBox.SelectedIndex == 0)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.HealthReports
                                where rpTbx.Text == s.ReportID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else 
                    {
                        MessageBox.Show("請輸入正確的ReportID");
                    }
                }
                else if (rpComboBox.SelectedIndex == 1)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.HealthReports
                                where rpTbx.Text == s.MemberID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的MemberID");
                    }
                }
                else if (rpComboBox.SelectedIndex == 2)
                {
                    //DateTime temp ;

                    //if (DateTime.TryParse(textBox1.Text, out temp))
                    //{
                        var q = from s in ms.HealthReports.AsEnumerable()
                                where rpTbx.Text == s.ReportDate.Value.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("請輸入正確的ReportDate");
                    //}
                }
                else if (rpComboBox.SelectedIndex == 3)
                {

                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.HealthReports
                                where rpTbx.Text == s.PlanID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的PlanID");

                    }
                }
                else if (rpComboBox.SelectedIndex == 4)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.HealthReports
                                where rpTbx.Text == s.ReserveID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的ReserveID");
                    }
                }
            }

            else if (rbtHealthReportDetail.Checked)
            {
                if (rpComboBox.SelectedIndex == 0)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.ReportDetails
                                where rpTbx.Text == s.ReportDetailID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的ReportDetailID");
                    }
                }
                else if (rpComboBox.SelectedIndex == 1)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.ReportDetails
                                where rpTbx.Text == s.ReportID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的ReportID");

                    }
                }
                else if (rpComboBox.SelectedIndex == 2)
                {
                    int temp = 0;

                    if (int.TryParse(rpTbx.Text, out temp))
                    {
                        var q = from s in ms.ReportDetails
                                where rpTbx.Text == s.itemID.ToString()
                                select s;
                        dataGridView1.DataSource = q.ToList();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的ItemID");
                    }
                }
                else if (rpComboBox.SelectedIndex == 3)
                {
                   
                    var q = from s in ms.ReportDetails
                                where rpTbx.Text == s.result.ToString()
                                select s;
                    dataGridView1.DataSource = q.ToList();
                  
                

                }
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbtReserved_CheckedChanged(object sender, EventArgs e)
        {
            r1.Fill(md.Reserve);
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = md.Reserve;
            rpComboBox.Items.Clear();
            reverseCbTrue();

        }

        private void rbtReservedSub_CheckedChanged(object sender, EventArgs e)
        {
            rs1.Fill(md.ReservedSub);
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = md.ReservedSub;
            rpComboBox.Items.Clear();
            reversedsubCbTrue();
        }

        private void rbtHealthReport_CheckedChanged(object sender, EventArgs e)
        {
            ht1.Fill(md.HealthReport);
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = md.HealthReport;
            rpComboBox.Items.Clear();
            healthreportCbTrue();
        }

        private void rbtHealthReportDetail_CheckedChanged(object sender, EventArgs e)
        {
            rd1.Fill(md.ReportDetail);
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = md.ReportDetail;
            rpComboBox.Items.Clear();
            healthreportdetailCbTrue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ms.SaveChanges();
            ReserveTableAdapter rt = new ReserveTableAdapter();
            ReservedSubTableAdapter rta = new ReservedSubTableAdapter();
            HealthReportTableAdapter hrt = new HealthReportTableAdapter();
            ReportDetailTableAdapter rd = new ReportDetailTableAdapter();
            rt.Update(md);
            rta.Update(md);
            hrt.Update(md);
            rd.Update(md);
            //Binding b = new Binding("text", ms.Plans, "planid");
            //textBox1.DataBindings.Add(b);

        }

        private void rpComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
      



        }

        private void Q(string ss)
        {
            var q = from s in ms.Reserves
                    where rpTbx.Text == ss
                    select s;
            dataGridView1.DataSource = q.ToList();

        }

    }
}
