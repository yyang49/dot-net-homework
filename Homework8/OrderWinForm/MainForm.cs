using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Order;

namespace OrderWinForm
{
    public partial class MainForm : Form
    {
        public static OrderService orderService = new OrderService();
        public MainForm()
        {
            InitializeComponent();
            orderService.AddOrder(1, new Customer("yyang", "111-1111"), new OrderDetails(new Commodity("1001", "护摩之杖", 5000), 1), new OrderDetails(new Commodity("1002", "狼的末路", 3000), 2));
            orderService.AddOrder(2, new Customer("Amber", "222-2222"), new OrderDetails(new Commodity("1003", "四风原典", 4000), 1), new OrderDetails(new Commodity("1004", "决斗之枪", 2000), 1));
            orderService.AddOrder(3, new Customer("Kaeya", "333-3333"), new OrderDetails(new Commodity("1001", "护摩之杖", 5000), 1), new OrderDetails(new Commodity("1005", "天空之翼", 3000), 1));
            orderService.AddOrder(4, new Customer("Hutao", "444-4444"), new OrderDetails(new Commodity("1002", "狼的末路", 3000), 1), new OrderDetails(new Commodity("1006", "火之高兴", 5000), 1));
            orderService.AddOrder(5, new Customer("Klee", "555-5555"), new OrderDetails(new Commodity("1003", "四风原典", 4000), 1), new OrderDetails(new Commodity("1007", "阿莫斯之弓", 4000), 1));
            orderBindingSource.DataSource = orderService.orderList;
        }
        private void addOrder_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm(false, 0);
            detailForm.ShowDialog();
            orderBindingSource.ResetBindings(false);
        }

        private void editOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int index = orderService.orderList.IndexOf(new Order.Order() { orderNo = (int)dataGridView1.CurrentRow.Cells[0].Value });
                DetailForm detailForm = new DetailForm(true, index);
                detailForm.ShowDialog();
                orderBindingSource.ResetBindings(false);
            }
        }

        private void deleteOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                orderService.DeleteOrder((int)dataGridView1.CurrentRow.Cells[0].Value);
                orderBindingSource.DataSource = orderService.orderList;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void importOrder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open";
            openFileDialog.Filter = "XML File|*.xml";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = System.IO.Path.GetFullPath(openFileDialog.FileName);
                orderService.Import(path);
                orderBindingSource.DataSource = orderService.orderList;
            }
        }

        private void outputOrder_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export";
            saveFileDialog.Filter = "XML File|*.xml";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = System.IO.Path.GetFullPath(saveFileDialog.FileName);
                orderService.Export(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchType.Text !="" && filter.Text !="")
            {
                List<Order.Order> searchResult = new List<Order.Order>();
                switch (searchType.Text)
                {
                    case "订单号":
                        searchResult = orderService.SelectOrder(1, filter.Text).ToList();
                        break;
                    case "商品名":
                        searchResult = orderService.SelectOrder(2, filter.Text).ToList();
                        break;
                    case "收货人":
                        searchResult = orderService.SelectOrder(3, filter.Text).ToList();
                        break;
                    case "总价":
                        double total;
                        double.TryParse(filter.Text, out total);
                        searchResult = orderService.SelectOrder(4, total.ToString()).ToList();
                        break;
                }
                orderBindingSource.DataSource = searchResult;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orderService.orderList;
        }
    }
}
