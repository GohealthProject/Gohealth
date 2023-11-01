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
   
    public partial class FrmCar : Form
    {
        MedSysEntities mse =new MedSysEntities();
        int memberID = 0;
        ListView x = null;
        public FrmCar(ListView lviss ,int id)
        {
            
            InitializeComponent();
            this.ListViewCart.Columns.Add("產品名稱");
            this.ListViewCart.Columns.Add("數量");
            this.ListViewCart.Columns.Add("價格");
            x = lviss;
            memberID = id;
            foreach(ListViewItem item in x.Items)
            {
                ListViewItem item2 = new ListViewItem();
                item2.Text= item.Text;
                item2.SubItems.Add(item.SubItems[1]);
                item2.SubItems.Add(item.SubItems[2]);
                this.ListViewCart.Items.Add(item2);
            }

            var q = from n in mse.OrderShips
                    select n;
            foreach(var n in q)
            {
                comboBox1.Items.Add(n.shipName);
            }
            var q2 = from n in mse.OrderPays
                     select n;
            foreach(var n in q2)
            {
                comboBox3.Items.Add(n.PayName);
            }
            MessageBox.Show("ccc");
        }

        private void FrmCar_Load(object sender, EventArgs e)
        {
            int x = 0;
            foreach (ListViewItem item in this.ListViewCart.Items)
            {
                x = x+int.Parse(item.SubItems[2].Text);
            }
            this.label1.Text = x.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order od = new Order();
            
            var odp = mse.OrderPays.Where(n => n.PayName == comboBox3.Text).Select(n => n.PayID).FirstOrDefault();
            var ods = mse.OrderShips.Where(n => n.shipName == comboBox1.Text).Select(n => n.shipID).FirstOrDefault();
            od.memberId = memberID;
            od.payID = odp;
            od.shipID = ods;
            od.orderDate = DateTime.Now;
            od.shipDate = DateTime.Now;
            od.deliveryDate = DateTime.Today.AddDays(1);
            od.stateID = 6;
            mse.Orders.Add(od);
            mse.SaveChanges();
            OrderDetailnew();
            mse.SaveChanges();
        }

        private void OrderDetailnew()
        {
            var q = mse.Orders.Where(n => n.memberId == memberID).OrderByDescending(n => n.orderID).Select(n => n.orderID).FirstOrDefault();
            MessageBox.Show(q+"");
            OrderDetail ord = new OrderDetail();
            string s = "";
            int x = 0;
            for (int i = 0; i < ListViewCart.Items.Count ; i++)
            {
                ord = new OrderDetail();
                s = this.ListViewCart.Items[i].Text;
                x = int.Parse(this.ListViewCart.Items[i].SubItems[2].Text);
                var q2 = (from n in mse.Products
                         where n.ProductName == s
                         select new
                         {
                             n.ProductID,
                             n.UnitPrice
                         }).FirstOrDefault();
                ord.productID = q2.ProductID;
                ord.unitPrice = q2.UnitPrice;
                ord.quantity = x;
                ord.orderID = q;
                mse.OrderDetails.Add(ord);
            }
        }
    }
}
