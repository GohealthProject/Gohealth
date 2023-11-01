using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專題
{
    public partial class FrmCompared : Form
    {
        List<string> strings = new List<string> { };
        int plan = 0;
        int templ = 0;
        bool flag = false;
        MedSysEntities ms = new MedSysEntities();
        public FrmCompared(ListView l, int memID, int Price, int pl)
        {
            InitializeComponent();
            plan = pl;
            listView1.View = View.Details;
            //MessageBox.Show(plan.ToString());
            listView1.Scrollable = true;

            listView1.MultiSelect = false;
            //ColumnHeader header1, header2;
            //header1 = new ColumnHeader();
            //header2 = new ColumnHeader();

            //header1.Width = 157;
            //header2.Width = 74;
            listView1.Columns.Add("項目", 157);
            listView1.Columns.Add("價格", 74);

            //listview2 文字顏色不改變////
            int itemCount = 0;
            //ListViewItem sum;
            int count = 1;
            foreach (ListViewItem item in l.Items)
            {
                //sum = item.SubItems[1];
                //MessageBox.Show(item.SubItems[1].ToString());
                listView1.Items.Add($"{item.Text}").SubItems.Add(item.SubItems[1]);//// 

                //listView1.Items.Add(item.SubItems[0].ToString()).SubItems.Add(item.SubItems[1]);itemname 需split
                itemCount++;
                count++;


            }
            lblItems1.Text = $"共 {itemCount.ToString()} 項";
            lblPrices1.Text = $"共 {Price.ToString()} 元";

            //foreach (ListViewItem Item in l.Items)
            //{
            //    listView1.Items.Add(Item.Clone() as ListViewItem);
            //}



            listView2.View = View.Details;

            listView2.Scrollable = true;

            listView2.MultiSelect = false;
            listView2.Columns.Add("項目", 157);
            listView2.Columns.Add("價格", 74);


            MedSysEntities ms = new MedSysEntities();
            var q = from s in ms.Plans
                    select s.planName;
            foreach (var p in q)
            {
                comboBox1.Items.Add(p);
            }


            for (int i = 0; i < listView1.Items.Count; i++)
            {

                ListViewItem Item = listView1.Items[i];
                strings.Add(Item.Text);

                //MessageBox.Show(Item.SubItems[i].ToString());//////////Test

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Application.OpenForms["Form1"];

            if (flag)//清空Form1 listview items
            { f.listViewItemsAll.Items.Clear(); }

            //Form1 listview 方法1
            //f.lv = this.listView1;
            //foreach (ListViewItem Item in f.lv.Items)
            //{
            //    f.listViewItemsAll.Items.Add(Item.Clone() as ListViewItem);//TODO 待修
            //}


            f.labelSum.Text = lblPrices1.Text;
            plan = templ;
            //MessageBox.Show(plan + "");
            //MessageBox.Show(templ + "");
            //Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f.plan = this.plan;
            f.testLbl.Text = f.plan.ToString();

            //Form1 listview 方法2
            if (plan >= 2)
            {
                f.comboboxPlan.SelectedIndex = plan - 2;
            }
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from s in ms.PlanRefs.AsEnumerable()//兩段式qurey?
                    where s.Plan.planName == comboBox1.Text
                    select s.Project.projectID;


            var qq = from s in ms.Items.AsEnumerable()
                     where q.Contains(s.Project.projectID)
                     group q by new { s.itemID, s.itemPrice, s.itemName } into g
                     select new { g.Key.itemName, g.Key.itemPrice, Count = g.Key.itemName.Count(), };

            //var qq = from s in ms.Items.AsEnumerable()
            //         where q.Contains(s.Project.projectID)
            //         select new { s.itemName, s.itemPrice };

            //MessageBox.Show(listView1.Items[0].Text.ToString());
            listView2.Items.Clear();
            int itemsCount = 0;
            int sum = 0;
            int count = 1;


            foreach (var p in qq)
            {

                //if (strings[count].Split('.').Equals(p.itemName))
                if (strings.Contains(p.itemName))
                {
                    listView2.Items.Add($"{count}. {p.itemName}").ForeColor = Color.Brown;
                    listView2.Items[itemsCount].SubItems.Add(p.itemPrice.ToString()).ForeColor = Color.Brown;

                    //listView2.Items[this].Add(p.itemPrice.ToString());//同時新增
                    //SubItems.Add(p.itemPrice.ToString()).BackColor=Color.Black;//無效?
                }
                else
                {
                    listView2.Items.Add($"{count}. {p.itemName} ").SubItems.Add(p.itemPrice.ToString());
                }
                itemsCount++;
                sum += (int)p.itemPrice;
                count++;
            }

            lblItems2.Text = $"共 {qq.Count().ToString()} 項";
            lblPrices2.Text = $"共 {sum.ToString()} 元";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (ListViewItem Item in listView2.Items)
            {
                listView1.Items.Add(Item.Clone() as ListViewItem).ForeColor = Color.Black;
                //listView1.Items.Add(Item.Clone() as ListViewItem);
                //listView1.Items[0].ForeColor = Color.Aqua;//顏色調整
            }

            listView1.AutoArrange = true;

            listView1.ForeColor = Color.Black;
            //listView1.BackColor= Color.Black;

            lblItems1.Text = lblItems2.Text;
            lblPrices1.Text = lblPrices2.Text;
            templ = comboBox1.SelectedIndex + 2;
            flag = true;
            //MessageBox.Show(plan+"");
            //MessageBox.Show(templ + "");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
