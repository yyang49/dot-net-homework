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
    public partial class DetailForm : Form
    {
        private bool isEdit;
        OrderService orderService = MainForm.orderService;
        Order.Order order = new Order.Order();
        public DetailForm(bool isEdit, int index)
        {
            InitializeComponent();
            this.isEdit = isEdit;
            switch (isEdit)
            {
                case true:
                    order= (Order.Order)orderService.orderList[index];
                    break;
                case false:
                    break;
            }
            bindingSource1.DataSource = order;
            bindingSource1.DataMember = "orderDetails";
            textNo.DataBindings.Add("Text", order, "orderNO");
            textName.DataBindings.Add("Text", order, "customerName");
            textInfo.DataBindings.Add("Text", order, "customerInfo");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            switch (isEdit)
            {
                case true:
                    this.Close();
                    break;
                case false:
                    orderService.AddOrder(order);
                    this.Close();
                    break;
            }
        }
    }
}
