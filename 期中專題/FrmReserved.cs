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
    public partial class FrmReserved : Form
    {
        int memid = 0;
        int plan = 0;//TODO DB需增加PLAN
        public FrmReserved(ListView ReservedPlan, int id, int Price, int p)
        {
            InitializeComponent();
            memid = id;
            plan = p;
            comboBox1.Items.Add("信用卡");
            lblPrice.Text = $"總價: {Price.ToString()}元";
            listView1.View = View.Details;
            //MessageBox.Show(plan+"");
            listView1.Scrollable = true;

            listView1.MultiSelect = false;
            listView1.Columns.Add("項目", 157);
            listView1.Columns.Add("價格", 74);

            foreach (ListViewItem Item in ReservedPlan.Items)
            {
                listView1.Items.Add(Item.Clone() as ListViewItem);
            }
            monthCalendar1.MinDate = DateTime.Now;
            //MessageBox.Show(memid+"");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = paymentName.Text;
            string card = paymentCard.Text;
            string CVC = paymentCVC.Text;
            string expire = paymentExpired.Text;
            //CardCheck(card);
            Regex Ncheck = new Regex("[A-Z a-z]");

            plan = 5;///////////////////////////////////////////////////////////TODO 需修

            //TODO update planID payment

            MedSysEntities MedSys = new MedSysEntities();
            Reserve reserve = new Reserve { memberID = memid, planID = plan, ReserveDate = monthCalendar1.SelectionStart, ReserveState = "預約中" };
            //Reserve reserveProject = new Reserve {memberID= };
            //MessageBox.Show($"Date={monthCalendar1.SelectionStart}");
            MedSys.Reserves.Add(reserve);
            MedSys.SaveChanges();

            //Reserves ReservedID(auto),memberID,planID,ReserveDate,ReserveStatus
            List<string> strings = new List<string> { };

            for (int i = 0; i < listView1.Items.Count; i++)
            {

                ListViewItem Item = listView1.Items[i];
                strings.Add(Item.Text);

                //for (int j = 0; j < Item.SubItems.Count; j++)
                //{

                //        strings.Add(Item.SubItems[j].Text);


                //}


            }
            //MessageBox.Show(strings[0]);
            var q = (from s in MedSys.Reserves.AsEnumerable()
                     where s.memberID == reserve.memberID
                     select s.ReserveID).Last();

            //reserve.ReserveID???

            //MessageBox.Show(listView1.Items[0].Text);

            var qq = from s in MedSys.Items.AsEnumerable()
                     where strings.Contains(s.itemName)
                     /*listView1.Items.ToString().Contains(s.itemName)*/
                     select new { s.itemName, s.itemID };





            //dataGridView1.DataSource = qq.ToList();
            foreach (var item in qq) //無法建立ListViewItemCollection型別的常數值
            {
                ReservedSub reservedSub = new ReservedSub { reservedID = q, itemID = item.itemID };
                //MessageBox.Show($"reservedID= {q} itemID= {item} itemname={item.itemName}");
                MedSys.ReservedSubs.Add(reservedSub);

            }
            DateTime dt = new DateTime(2000 - 01 - 01);
            HealthReport Hreport = new HealthReport { MemberID = memid, ReportDate = dt, PlanID = plan, ReserveID = q };
            MedSys.HealthReports.Add(Hreport);
            foreach (var item in qq)
            {
                ReportDetail RD = new ReportDetail { ReportID = Hreport.ReportID, itemID = item.itemID };
                MedSys.ReportDetails.Add(RD);
            }
            MedSys.SaveChanges();
            //reservedSub subreservedID(Auto),reservedID,itemID
            MessageBox.Show("預約成功!!!");
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = $"{monthCalendar1.SelectionStart.ToLongDateString()}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
